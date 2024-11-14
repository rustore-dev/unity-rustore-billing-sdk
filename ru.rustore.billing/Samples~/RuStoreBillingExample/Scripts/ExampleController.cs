using System;
using UnityEngine;
using RuStore.BillingExample.UI;
using RuStore.BillingClient;
using UnityEngine.UI;

namespace RuStore.BillingExample {

    public class ExampleController : MonoBehaviour {

        public const string ExampleVersion = "7.0.0";

        [SerializeField]
        private string[] _productIds;

        [SerializeField]
        private CardsView productsView;

        [SerializeField]
        private CardsView purchasesView;

        [SerializeField]
        private MessageBox _messageBox;

        [SerializeField]
        private LoadingIndicator _loadingIndicator;

        [SerializeField]
        private Text isRuStoreInstalledLabel;

        private void Awake() {
            RuStoreBillingClient.Instance.Init();
        }

        private void Start() {
            ProductCardView.OnBuyProduct += ProductCardView_OnBuyProduct;

            PurchaseCardView.OnConfirmPurchase += PurchaseCardView_OnConfirmPurchase;
            PurchaseCardView.OnDeletePurchase += PurchaseCardView_OnDeletePurchase;
            PurchaseCardView.OnGetPurchaseInfo += PurchaseCardView_OnGetPurchaseInfo;

            var isRuStoreInstalled = RuStoreBillingClient.Instance.IsRuStoreInstalled();
            var message = isRuStoreInstalled ? "RuStore is installed [v]" : "RuStore is not installed [x]";
            isRuStoreInstalledLabel.text = message;
        }

        private void ProductCardView_OnBuyProduct(object sender, EventArgs e) {
            var product = (sender as ICardView<Product>).GetData();
            BuyProduct(product.productId);
        }

        private void PurchaseCardView_OnConfirmPurchase(object sender, EventArgs e) {
            var purchase = (sender as ICardView<Purchase>).GetData();
            ConsumePurchase(purchase.purchaseId);
        }

        private void PurchaseCardView_OnDeletePurchase(object sender, EventArgs e) {
            var purchase = (sender as ICardView<Purchase>).GetData();
            DeletePurchase(purchase.purchaseId);
        }

        private void PurchaseCardView_OnGetPurchaseInfo(object sender, EventArgs e) {
            var purchase = (sender as ICardView<Purchase>).GetData();
            GetPurchaseInfo(purchase.purchaseId);
        }

        private void Update() {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                Application.Quit();
            }
        }

        public void CheckTheme(bool value) {
            var theme = value ? BillingClientTheme.Dark : BillingClientTheme.Light;
            RuStoreBillingClient.Instance.SetTheme(theme);
        }

        public void CheckPurchasesAvailability() {
            _loadingIndicator.Show();

            RuStoreBillingClient.Instance.CheckPurchasesAvailability(
                onFailure: (error) => {
                    _loadingIndicator.Hide();
                    OnError(error);
                },
                onSuccess: (result) => {
                    _loadingIndicator.Hide();

                    if (result.isAvailable) {
                        _messageBox.Show("Availability", "True");
                    } else {
                        OnError(result.cause);
                    }
                });
        }

        public void LoadProducts() {
            _loadingIndicator.Show();

            productsView.gameObject.SetActive(true);
            purchasesView.gameObject.SetActive(false);

            RuStoreBillingClient.Instance.GetProducts(
                productIds: _productIds,
                onFailure: (error) => {
                    _loadingIndicator.Hide();
                    OnError(error);
                },
                onSuccess: (result) => {
                    _loadingIndicator.Hide();
                    productsView.SetData(result);
                });
        }

        public void LoadPurchases() {
            _loadingIndicator.Show();

            productsView.gameObject.SetActive(false);
            purchasesView.gameObject.SetActive(true);

            RuStoreBillingClient.Instance.GetPurchases(
                onFailure: (error) => {
                    _loadingIndicator.Hide();
                    OnError(error);
                },
                onSuccess: (result) => {
                    _loadingIndicator.Hide();
                    purchasesView.SetData(result);
                });
        }

        public void BuyProduct(string productId) {
            _loadingIndicator.Show();
            RuStoreBillingClient.Instance.PurchaseProduct(
                productId: productId,
                quantity: 1,
                developerPayload: "test payload",
                onFailure: (error) => {
                    _loadingIndicator.Hide();
                    OnError(error);
                },
                onSuccess: (result) => {
                    _loadingIndicator.Hide();

                    bool isSandbox = false;
                    switch (result) {
                        case PaymentSuccess paymentSuccess:
                            isSandbox = paymentSuccess.sandbox;
                            break;
                        case PaymentCancelled paymentCancelled:
                            isSandbox = paymentCancelled.sandbox;
                            break;
                        case PaymentFailure paymentFailure:
                            isSandbox = paymentFailure.sandbox;
                            break;
                    }

                    if (isSandbox) {
                        ShowToast(string.Format("isSandbox: {0}", isSandbox.ToString()));
                    }
                });
        }

        public void ShowToast(string message) {
            using (AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            using (AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity"))
            using (AndroidJavaObject utils = new AndroidJavaObject("com.plugins.billingexample.RuStoreBillingAndroidUtils")) {
                utils.Call("showToast", currentActivity, message);
            }
        }

        public void ConsumePurchase(string purchaseId) {
            _loadingIndicator.Show();
            RuStoreBillingClient.Instance.ConfirmPurchase(
                purchaseId: purchaseId,
                onFailure: (error) => {
                    _loadingIndicator.Hide();
                    OnError(error);
                },
                onSuccess: () => {
                    _loadingIndicator.Hide();
                    LoadPurchases();
                });
        }

        public void DeletePurchase(string purchaseId)
        {
            _loadingIndicator.Show();
            RuStoreBillingClient.Instance.DeletePurchase(
                purchaseId: purchaseId,
                onFailure: (error) => {
                    _loadingIndicator.Hide();
                    OnError(error);
                },
                onSuccess: () => {
                    _loadingIndicator.Hide();
                    LoadPurchases();
                });
        }

        public void GetPurchaseInfo(string purchaseId)
        {
            _loadingIndicator.Show();
            RuStoreBillingClient.Instance.GetPurchaseInfo(
                purchaseId: purchaseId,
                onFailure: (error) => {
                    _loadingIndicator.Hide();
                    OnError(error);
                },
                onSuccess: (response) => {
                    _loadingIndicator.Hide();
                    _messageBox.Show("Purchase", string.Format("Purchase id: {0}", response.purchaseId));
                });
        }

        private void OnError(RuStoreError error) {
            _messageBox.Show("Error", error.description);

            Debug.LogErrorFormat("{0} : {1}", error.name, error.description);
        }
    }
}
