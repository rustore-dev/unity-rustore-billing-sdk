using UnityEngine;
using System;
using RuStore.BillingClient.Internal;
using System.Collections.Generic;

namespace RuStore.BillingClient {

    /// <summary>
    /// Класс реализует API для интегрирации платежей в мобильное приложение.
    /// </summary>
    public class RuStoreBillingClient {

        /// <summary>
        /// Версия плагина.
        /// </summary>
        public static string PluginVersion = "8.0.1";

        private static RuStoreBillingClient _instance;
        private static bool _isInstanceInitialized;

        private bool _isInitialized;

        /// <summary>
        /// Возвращает true, если синглтон инициализирован, в противном случае — false.
        /// </summary>
        public bool IsInitialized => _isInitialized;
        private AndroidJavaObject _clientWrapper;

        private bool _allowNativeErrorHandling;

        /// <summary>
        /// Возвращает единственный экземпляр RuStoreBillingClient (реализация паттерна Singleton).
        /// Если экземпляр еще не создан, создает его.
        /// </summary>
        public static RuStoreBillingClient Instance {
            get {
                if (!_isInstanceInitialized) {
                    _isInstanceInitialized = true;
                    _instance = new RuStoreBillingClient();
                }
                return _instance;
            }
        }

        /// <summary>
        /// Обработка ошибок в нативном SDK.
        /// true — разрешает обработку ошибок, false — запрещает.
        /// </summary>
        [Obsolete("This field is deprecated. Error handling must be performed on the application side.")]
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

        /// <summary>
        /// Выполняет инициализацию синглтона RuStoreBillingClient.
        /// Параметры инициализации задаются объектом типа RuStore.BillingClient.RuStoreBillingClientConfig.
        /// </summary>
        /// <param name="config">
        /// Объект класса RuStore.BillingClient.RuStoreBillingClientConfig.
        /// Содержит параметры инициализации платежного клиента.
        /// </param>
        /// <returns>Возвращает true, если инициализация была успешно выполнена, в противном случае — false.</returns>
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

        /// <summary>
        /// Выполняет инициализацию синглтона RuStoreBillingClient.
        /// Параметры инициализации задаются в файле BillingClientSettings.asset.
        /// Для создания файла BillingClientSettings.asset выберите в меню редактора Unity пункт Window → RuStoreSDK → Settings → Billing Client.
        /// </summary>
        /// <returns>Возвращает true, если инициализация была успешно выполнена, в противном случае — false.</returns>
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

        /// <summary>
        /// Проверка доступности платежей.
        /// Если все условия выполняются, возвращается RuStore.FeatureAvailabilityResult.isAvailable == true.
        /// В противном случае возвращается RuStore.FeatureAvailabilityResult.isAvailable == false.
        /// </summary>
        /// <param name="onFailure">
        /// Действие, выполняемое в случае ошибки.
        /// Возвращает объект RuStore.RuStoreError с информацией об ошибке.
        /// </param>
        /// <param name="onSuccess">
        /// Действие, выполняемое при успешном завершении операции.
        /// Возвращает объект RuStore.FeatureAvailabilityResult с информцаией о доступности оплаты.
        /// </param>
        [Obsolete("This method is deprecated. This method only works for flows with an authorized user in RuStore.")]
        public void CheckPurchasesAvailability(Action<RuStoreError> onFailure, Action<PurchaseAvailabilityResult> onSuccess) {
            if (!IsPlatformSupported(onFailure)) {
                return;
            }

            var listener = new PurchaseAvailabilityListener(onFailure, onSuccess);
            _clientWrapper.Call("checkPurchasesAvailability", listener);
        }

        /// <summary>
        /// Проверка установлен ли на устройстве пользователя RuStore.
        /// </summary>
        /// <returns>Возвращает true, если RuStore установлен, в противном случае — false.</returns>
        public bool IsRuStoreInstalled() {
            if (!IsPlatformSupported()) {
                return false;
            }

            return _clientWrapper.Call<bool>("isRuStoreInstalled");
        }

        /// <summary>
        /// Проверка статуса авторизации у пользователя.
        /// </summary>
        /// <param name="onFailure">
        /// Действие, выполняемое в случае ошибки.
        /// Возвращает объект RuStore.RuStoreError с информацией об ошибке.
        /// </param>
        /// <param name="onSuccess">
        /// Действие, выполняемое при успешном завершении операции.
        /// Возвращает объект UserAuthorizationStatus с информцаией о статусе авторизаци у пользователя.
        /// </param>
        public void GetAuthorizationStatus(Action<RuStoreError> onFailure, Action<UserAuthorizationStatus> onSuccess) {
            if (!IsPlatformSupported(onFailure)) return;

            var listener = new UserAuthorizationStatusListener(onFailure, onSuccess);
            _clientWrapper.Call("getAuthorizationStatus", listener);
        }

        /// <summary>
        /// Получение списка продуктов, добавленных в ваше приложение через RuStore консоль.
        /// </summary>
        /// <param name="productIds">Список идентификаторов продуктов (задаются при создании продукта в консоли разработчика).
        /// Список продуктов имеет ограничение в размере 1000 элементов.</param>
        /// <param name="onFailure">
        /// Действие, выполняемое в случае ошибки.
        /// Возвращает объект RuStore.RuStoreError с информацией об ошибке.
        /// </param>
        /// <param name="onSuccess">
        /// Действие, выполняемое при успешном завершении операции.
        /// Возвращает список объектов RuStore.BillingClient.Product с информцаией о продуктах.
        /// </param>
        public void GetProducts(string[] productIds, Action<RuStoreError> onFailure, Action<List<Product>> onSuccess) {
            if (!IsPlatformSupported(onFailure)) {
                return;
            }

            var listener = new ProductsResponseListener(onFailure, onSuccess);
            _clientWrapper.Call("getProducts", productIds, listener);
        }

        /// <summary>
        /// Получение списка покупок пользователя.
        /// </summary>
        /// <param name="onFailure">
        /// Действие, выполняемое в случае ошибки.
        /// Возвращает объект RuStore.RuStoreError с информацией об ошибке.
        /// </param>
        /// <param name="onSuccess">
        /// Действие, выполняемое при успешном завершении операции.
        /// Возвращает список объектов RuStore.BillingClient.Purchase с информцаией о покупках.
        /// </param>
        public void GetPurchases(Action<RuStoreError> onFailure, Action<List<Purchase>> onSuccess) {
            if (!IsPlatformSupported(onFailure)) {
                return;
            }

            var listener = new PurchasesResponseListener(onFailure, onSuccess);
            _clientWrapper.Call("getPurchases", listener);
        }

        /// <summary>
        /// Получение информации о покупке.
        /// </summary>
        /// <param name="purchaseId">
        /// Идентификатор покупки.
        /// </param>
        /// <param name="onFailure">
        /// Действие, выполняемое в случае ошибки.
        /// Возвращает объект RuStore.RuStoreError с информацией об ошибке.
        /// </param>
        /// <param name="onSuccess">
        /// Действие, выполняемое при успешном завершении операции.
        /// Возвращает объект RuStore.BillingClient.Purchase с информцаией о покупке.
        /// </param>
        public void GetPurchaseInfo(string purchaseId, Action<RuStoreError> onFailure, Action<Purchase> onSuccess) {
            if (!IsPlatformSupported(onFailure)) {
                return;
            }

            var listener = new PurchaseInfoResponseListener(onFailure, onSuccess);
            _clientWrapper.Call("getPurchaseInfo", purchaseId, listener);
        }

        /// <summary>
        /// Покупка продукта.
        /// </summary>
        /// <param name="productId">Идентификатор продукта, который был присвоен продукту в консоли RuStore.</param>
        /// <param name="quantity">Количество продукта (необязательный параметр — если не указывать, будет подставлено значение 1).</param>
        /// <param name="developerPayload">Строка с дополнительной информацией о заказе, которую вы можете установить при инициализации процесса покупки.</param>
        /// <param name="onFailure">
        /// Действие, выполняемое в случае ошибки.
        /// Возвращает объект RuStore.RuStoreError с информацией об ошибке.
        /// </param>
        /// <param name="onSuccess">
        /// Действие, выполняемое при успешном завершении операции.
        /// Возвращает объект RuStore.BillingClient.PaymentResult с информцаией о результате покупки.
        /// </param>
        public void PurchaseProduct(string productId, int quantity, string developerPayload, Action<RuStoreError> onFailure, Action<PaymentResult> onSuccess) {
            if (!IsPlatformSupported(onFailure)) {
                return;
            }

            var listener = new PaymentResultListener(onFailure, onSuccess);
            _clientWrapper.Call("purchaseProduct", productId, null, quantity, developerPayload, listener);
        }

        /// <summary>
        /// Покупка продукта.
        /// </summary>
        /// <param name="productId">Идентификатор продукта, который был присвоен продукту в консоли RuStore.</param>
        /// <param name="orderId">
        /// Уникальный идентификатор оплаты, сформированный приложением (опциональный параметр).
        /// Если вы укажете этот параметр в вашей системе, вы получите его в ответе при работе с API.
        /// Если не укажете, он будет сгенерирован автоматически (uuid).
        /// Максимальная длина 150 символов.
        /// </param>
        /// <param name="quantity">Количество продукта (1 или более).</param>
        /// <param name="developerPayload">Строка с дополнительной информацией о заказе, которую вы можете установить при инициализации процесса покупки.</param>
        /// <param name="onFailure">
        /// Действие, выполняемое в случае ошибки.
        /// Возвращает объект RuStore.RuStoreError с информацией об ошибке.
        /// </param>
        /// <param name="onSuccess">
        /// Действие, выполняемое при успешном завершении операции.
        /// Возвращает объект RuStore.BillingClient.PaymentResult с информцаией о текущем наборе данных.
        /// </param>
        public void PurchaseProduct(string productId, string orderId, int quantity, string developerPayload, Action<RuStoreError> onFailure, Action<PaymentResult> onSuccess) {
            if (!IsPlatformSupported(onFailure)) {
                return;
            }

            var listener = new PaymentResultListener(onFailure, onSuccess);
            _clientWrapper.Call("purchaseProduct", productId, orderId, quantity, developerPayload, listener);
        }

        /// <summary>
        /// Потребление (подтверждение) покупки.
        /// Запрос на потребление (подтверждение) покупки должен сопровождаться выдачей товара.
        /// </summary>
        /// <param name="purchaseId">Идентификатор покупки.</param>
        /// <param name="onFailure">
        /// Действие, выполняемое в случае ошибки.
        /// Возвращает объект RuStore.RuStoreError с информацией об ошибке.
        /// </param>
        /// <param name="onSuccess">Действие, выполняемое при успешном завершении операции.</param>
        public void ConfirmPurchase(string purchaseId, Action<RuStoreError> onFailure, Action onSuccess) {
            if (!IsPlatformSupported(onFailure)) {
                return;
            }

            var listener = new ConfirmPurchaseResponseListener(onFailure, onSuccess);
            _clientWrapper.Call("confirmPurchase", purchaseId, listener);
        }

        /// <summary>
        /// Отмена покупки.
        /// </summary>
        /// <param name="purchaseId">Идентификатор покупки.</param>
        /// <param name="onFailure">
        /// Действие, выполняемое в случае ошибки.
        /// Возвращает объект RuStore.RuStoreError с информацией об ошибке.
        /// </param>
        /// <param name="onSuccess">Действие, выполняемое при успешном завершении операции.</param>
        public void DeletePurchase(string purchaseId, Action<RuStoreError> onFailure, Action onSuccess) {
            if (!IsPlatformSupported(onFailure)) {
                return;
            }

            var listener = new DeletePurchaseResponseListener(onFailure, onSuccess);
            _clientWrapper.Call("deletePurchase", purchaseId, listener);
        }

        /// <summary>
        /// SDK поддерживает динамическую смены темы.
        /// Установить тему интерфейса.
        /// </summary>
        /// <param name="theme">Новая тема, заданная значением из перечисления RuStore.BillingClient.BillingClientTheme.</param>
        public void SetTheme(BillingClientTheme theme) {
            if (!IsPlatformSupported((error) => { })) {
                return;
            }

            _clientWrapper.Call("setThemeCode", (int)theme);
        }

        /// <summary>
        /// SDK поддерживает динамическую смены темы.
        /// Получить текущую тему интерфейса.
        /// </summary>
        /// <returns>Текущая тема, заданная значением из перечисления RuStore.BillingClient.BillingClientTheme.</returns>
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

        private bool IsPlatformSupported(Action<RuStoreError> onFailure = null) {
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
