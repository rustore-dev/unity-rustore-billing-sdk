#if UNITY_ANDROID
using System;
using System.IO;
using System.Text.RegularExpressions;
using UnityEditor.Android;
using UnityEditor.Build;
using UnityEngine;

namespace RuStore.Editor {

    public class RuStoreSDKBuildScript : IPostGenerateGradleAndroidProject {

        private const string KotlinModuleOption = "pickFirst 'META-INF/*.kotlin_module'";

        int IOrderedCallback.callbackOrder => 0;

        void IPostGenerateGradleAndroidProject.OnPostGenerateGradleAndroidProject(string path) {
            var launcherPath = path.Replace("unityLibrary", "launcher");
            var gradlePath = Path.Combine(launcherPath, "build.gradle");

            var regex = new Regex("packagingOptions\\s\\{([\\s\\S]*?)\\}", RegexOptions.Multiline);

            var gradleScript = File.ReadAllText(gradlePath);

            if (!gradleScript.Contains(KotlinModuleOption)) {
                var outputScript = regex.Replace(gradleScript, "packagingOptions {$1    " + KotlinModuleOption + "\n    }");
                File.WriteAllText(gradlePath, outputScript);
            }
        }
    }
}
#endif // UNITY_ANDROID