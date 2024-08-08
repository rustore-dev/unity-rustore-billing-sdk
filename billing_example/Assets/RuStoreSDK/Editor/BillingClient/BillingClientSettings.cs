using UnityEditor;
using UnityEngine;

namespace RuStore.Editor {

    public class BillingClientSettings : RuStoreModuleSettings {

        [Header("Billing Client SDK")]
        public string consoleApplicationId;
        public string deeplinkScheme;
        public bool allowNativeErrorHandling;
        public bool enableLogs;

        [MenuItem("Window/RuStoreSDK/Settings/BillingClient")]
        public static void EditBillingClientSettings() {
            EditSettings<BillingClientSettings>();
        }
    }
}