using UnityEngine;
using System;
using RuStore.BillingClient.Internal;
using RuStore.Internal;
using System.Collections.Generic;

namespace RuStore.BillingClient {

    public class RuStoreBillingClient {

        public static string PluginVersion = "6.1.0";

        private static RuStoreBillingClient _instance;
        private static bool _isInstanceInitialized;

        private bool _isInitialized;
        public bool IsInitialized => _isInitialized;
        private AndroidJavaObject _clientWrapper;

        private bool _allowNativeErrorHandling;

        public static RuStoreBillingClient Instance {
            get {
                if (!_isInstanceInitialized) {
                    _isInstanceInitialized = true;
                    _instance = new RuStoreBillingClient();
                }
                return _instance;
            }
        }

        public bool AllowNativeErrorHandling {
            get {
                return _allowNativeErrorHandling;
            }
            set {
                _allowNativeErrorHandling = value;

                if (_isInitialized) {
                    _clientWrapper.Call("setErrorHandling", value);
                }
            }
        }

        private RuStoreBillingClient() {
        }

        public bool Init(RuStoreBillingClientConfig config) {
            if (_isInitialized) {
                Debug.LogError("Error: RuStore Billing Client is already initialized");
                return false;
            }

            if (Application.platform != RuntimePlatform.Android) {
                return false;
            }

            _allowNativeErrorHandling = config.allowNativeErrorHandling;

            InitWrapper();

            _clientWrapper.Call("init", config.consoleApplicationId, config.deeplinkScheme, config.allowNativeErrorHandling, config.enableLogs, "unity");
            _isInitialized = true;

            return true;
        }

        public bool Init() {
            if (_isInitialized) {
                Debug.LogError("Error: RuStore Billing Client is already initialized");
                return false;
            }

            if (Application.platform != RuntimePlatform.Android) {
                return false;
            }

            InitWrapper();

            _clientWrapper.Call("init");
            _isInitialized = true;

            _allowNativeErrorHandling = _clientWrapper.Call<bool>("getErrorHandling");

            return true;
        }

        public void CheckPurchasesAvailability(Action<RuStoreError> onFailure, Action<FeatureAvailabilityResult> onSuccess) {
            if (!IsPlatformSupported(onFailure)) {
                return;
            }

            var listener = new FeatureAvailabilityListener(onFailure, onSuccess);
            _clientWrapper.Call("checkPurchasesAvailability", listener);

        }

        public void GetProducts(string[] productIds, Action<RuStoreError> onFailure, Action<List<Product>> onSuccess) {
            if (!IsPlatformSupported(onFailure)) {
                return;
            }

            var listener = new ProductsResponseListener(onFailure, onSuccess);
            _clientWrapper.Call("getProducts", productIds, listener);
        }

        public void GetPurchases(Action<RuStoreError> onFailure, Action<List<Purchase>> onSuccess) {
            if (!IsPlatformSupported(onFailure)) {
                return;
            }

            var listener = new PurchasesResponseListener(onFailure, onSuccess);
            _clientWrapper.Call("getPurchases", listener);
        }

        public void GetPurchaseInfo(string purchaseId, Action<RuStoreError> onFailure, Action<Purchase> onSuccess) {
            if (!IsPlatformSupported(onFailure)) {
                return;
            }

            var listener = new PurchaseInfoResponseListener(onFailure, onSuccess);
            _clientWrapper.Call("getPurchaseInfo", purchaseId, listener);
        }

        public void PurchaseProduct(string productId, int quantity, string developerPayload, Action<RuStoreError> onFailure, Action<PaymentResult> onSuccess) {
            if (!IsPlatformSupported(onFailure)) {
                return;
            }

            var listener = new PaymentResultListener(onFailure, onSuccess);
            _clientWrapper.Call("purchaseProduct", productId, null, quantity, developerPayload, listener);
        }


        public void PurchaseProduct(string productId, string orderId, int quantity, string developerPayload, Action<RuStoreError> onFailure, Action<PaymentResult> onSuccess) {
            if (!IsPlatformSupported(onFailure)) {
                return;
            }

            var listener = new PaymentResultListener(onFailure, onSuccess);
            _clientWrapper.Call("purchaseProduct", productId, orderId, quantity, developerPayload, listener);
        }

        public void ConfirmPurchase(string purchaseId, Action<RuStoreError> onFailure, Action onSuccess) {
            if (!IsPlatformSupported(onFailure)) {
                return;
            }

            var listener = new ConfirmPurchaseResponseListener(onFailure, onSuccess);
            _clientWrapper.Call("confirmPurchase", purchaseId, listener);
        }

        public void DeletePurchase(string purchaseId, Action<RuStoreError> onFailure, Action onSuccess) {
            if (!IsPlatformSupported(onFailure)) {
                return;
            }

            var listener = new DeletePurchaseResponseListener(onFailure, onSuccess);
            _clientWrapper.Call("deletePurchase", purchaseId, listener);
        }

        public void SetTheme(BillingClientTheme theme) {
            if (!IsPlatformSupported((error) => { })) {
                return;
            }

            _clientWrapper.Call("setThemeCode", (int)theme);
        }

        public BillingClientTheme GetTheme() {
            if (!IsPlatformSupported((error) => { })) {
                return BillingClientTheme.Light;
            }

            return (BillingClientTheme)_clientWrapper.Call<int>("getThemeCode");
        }

        private void InitWrapper() {
            CallbackHandler.InitInstance();
            using (var clientJavaClass = new AndroidJavaClass("ru.rustore.unitysdk.billingclient.RuStoreUnityBillingClient")) {
                _clientWrapper = clientJavaClass.GetStatic<AndroidJavaObject>("INSTANCE");
            }
        }

        private bool IsPlatformSupported(Action<RuStoreError> onFailure) {
            if(Application.platform != RuntimePlatform.Android) {
                onFailure?.Invoke(new RuStoreError() {
                    name = "RuStoreBillingClientError",
                    description = "Unsupported platform"
                });
                return false;
            }

            return true;
        }
    }
}
