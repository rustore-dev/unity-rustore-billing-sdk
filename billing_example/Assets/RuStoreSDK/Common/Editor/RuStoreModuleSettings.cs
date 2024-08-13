using System.IO;
using UnityEditor;
using UnityEngine;

namespace RuStore.Editor {

    public abstract class RuStoreModuleSettings : ScriptableObject {

        public static string AssetPath = Path.Combine("Assets", "RustoreSDK", "Editor");

        public static string AssetName<T>() where T : RuStoreModuleSettings {
            return typeof(T).Name + ".asset";
        }

        public static T LoadAsset<T>() where T : RuStoreModuleSettings {
            return AssetDatabase.LoadAssetAtPath<T>(Path.Combine(AssetPath,AssetName<T>()));
        }

        public static void EditSettings<T>() where T : RuStoreModuleSettings {
            var asset = LoadAsset<T>();

            if (asset == null) {
                asset = ScriptableObject.CreateInstance<T>();
                if (!Directory.Exists(AssetPath)) {
                    Directory.CreateDirectory(AssetPath);
                }
                AssetDatabase.CreateAsset(asset, Path.Combine(AssetPath, AssetName<T>()));
            }

            Selection.activeObject = asset;
        }
    }
}