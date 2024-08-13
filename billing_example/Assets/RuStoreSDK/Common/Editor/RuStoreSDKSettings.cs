using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;

namespace RuStore.Editor {

    public class RuStoreSDKSettings : IPreprocessBuildWithReport {

        private static readonly string LibPath = Path.Combine("Assets", "Plugins", "Android", "RuStoreSDKSettings.androidlib");
        private static readonly string ValuesPath = Path.Combine(LibPath, "res", "values");
        private static readonly string ValuesFileName = "values.xml";
        private static readonly string PropertiesFileName = "project.properties";
        private static readonly string ValuesFilePath = Path.Combine(ValuesPath, ValuesFileName);
        private static readonly string PropertiesFilePath = Path.Combine(LibPath, PropertiesFileName);

        private static readonly string ManifestFilePath = Path.Combine(LibPath, "AndroidManifest.xml");

        public int callbackOrder => 0;

        public void OnPreprocessBuild(BuildReport report) {
            if (EditorUserBuildSettings.activeBuildTarget != BuildTarget.Android) {
                return;
            }

            GenerateSettingsLibrary();
        }

        [MenuItem("Build/Update Settings")]
        public static void UpdateSettingsLibrary() { 
            var p = new RuStoreSDKSettings();
            p.GenerateSettingsLibrary();
        }

        private void GenerateSettingsLibrary() {
            var baseType = typeof(RuStoreModuleSettings);
            var subclassTypes = Assembly.GetAssembly(baseType).GetTypes().Where(t => t.IsSubclassOf(baseType)).ToArray();

            var settings = new Dictionary<string, string>();

            var loadMethod = baseType.GetMethod(nameof(RuStoreModuleSettings.LoadAsset));

            foreach(var t in subclassTypes) {
                var asset = loadMethod.MakeGenericMethod(t).Invoke(null, null);

                if (asset != null) {
                    var properties = t.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
                    foreach (var p in properties) {
                        settings.Add("rustore_" + t.Name + "_" + p.Name, p.GetValue(asset).ToString());
                    }
                }
            }

            var settingStrings = new StringBuilder();
            foreach (var s in settings) {
                settingStrings.AppendLine(string.Format(ValueStringTemplate, s.Key, s.Value));
            }

            var ValuesContents = string.Format(ValuesTemplate, settingStrings.ToString());

            if (!Directory.Exists(ValuesPath)) {
                Directory.CreateDirectory(ValuesPath);
            }

            if (!File.Exists(ManifestFilePath)) {
                File.WriteAllText(ManifestFilePath, ManifestFileContents);
                AssetDatabase.ImportAsset(ManifestFilePath);
            }

            if (!File.Exists(PropertiesFilePath)) {
                File.WriteAllText(PropertiesFilePath, PropertiesFileContents);
                AssetDatabase.ImportAsset(PropertiesFilePath);
            }

            if (File.Exists(ValuesFilePath)) {
                var oldValuesContents = File.ReadAllText(ValuesFilePath);

                if (ValuesContents == oldValuesContents) {
                    return;
                }
            } 

            File.WriteAllText(ValuesFilePath, ValuesContents);
            AssetDatabase.Refresh();
        }

        private static readonly string ValuesTemplate =
@"<?xml version=""1.0"" encoding=""utf-8""?>
<resources>
{0}
</resources>";

        private static readonly string ValueStringTemplate = @"    <string name=""{0}"" translatable=""false"">{1}</string>";

        private static readonly string ManifestFileContents =
@"<?xml version=""1.0"" encoding=""utf-8""?>
<manifest xmlns:android=""http://schemas.android.com/apk/res/android\""
    package=""ru.rustore.unitysdk.settings""
    android:versionCode=""1""
    android:versionName=""1.0"">
</manifest>";

        private static readonly string PropertiesFileContents =
@"target=android-9
android.library=true";
    }
}