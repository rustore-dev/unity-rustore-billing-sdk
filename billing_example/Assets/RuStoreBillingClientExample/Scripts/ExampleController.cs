using UnityEngine;
using RuStore.Example.UI;
using RuStore.BillingClient;
using System.Collections.Generic;

namespace RuStore.Example {

    public class ExampleController : MonoBehaviour {

        public const string ExampleVersion = "0.2.0";

        [SerializeField]
        private string[] _productIds;

        public static ExampleController Instance { get; private set; }

        [SerializeField]
        private ProductView[] _productViews;
        [SerializeField]
        private PurchaseView[] _purchaseViews;

        [SerializeField]
        private MessageBox _messageBox;
        [SerializeField]
        private LoadingIndicator _loadingIndicator;

        private Dictionary<string, Product> _products = new Dictionary<string, Product>();

        private void Awake() {
            Instance = this;
            RuStoreBillingClient.Instance.Init();
        }

        private void Start() {
            CheckPurchasesAvailability();
        }

        private void Update() {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                Application.Quit();
            }
        }

        public void SetProductIds(string[] productIds) { 
            _productIds = productIds;
        }

        private void CheckPurchasesAvailability() {
            RuStoreBillingClient.Instance.CheckPurchasesAvailability(
                onFailure: (error) => {
                },
                onSuccess: (result) => {
                    if (result.isAvailable) {
                        LoadProducts();
                    } else {
                        _messageBox.Show("Error", result.cause.description, LoadProducts);
                        OnError(result.cause);
                    }
                });
        }

        private void LoadProducts() {
            _loadingIndicator.Show();
            RuStoreBillingClient.Instance.GetProducts(
                productIds: _productIds,
                onFailure: (error) => {
                    _loadingIndicator.Hide();
                    OnError(error);
                },
                onSuccess: (result) => {
                    _loadingIndicator.Hide();

                    _products.Clear();
                    result.ForEach(p => _products.Add(p.productId, p));

                    UpdateProductsData(result);
                    LoadPurchases();
                });
        }

        private void UpdateProductsData(List<Product> products) {
            foreach (var v in _productViews) {
                v.Data = null;
                v.gameObject.SetActive(false);
            }

            var viewIndex = 0;
            foreach (var product in products) {
                if (product.productStatus == Product.ProductStatus.ACTIVE) {
                    _productViews[viewIndex].gameObject.SetActive(true);
                    _productViews[viewIndex].Data = product;
                    if (++viewIndex >= _productViews.Length) {
                        break;
                    }
                }
            }
        }

        private void LoadPurchases() {
            _loadingIndicator.Show();
            RuStoreBillingClient.Instance.GetPurchases(
                onFailure: (error) => {
                    _loadingIndicator.Hide();
                    OnError(error);
                },
                onSuccess: (result) => {
                    _loadingIndicator.Hide();
                    UpdatePurchaseData(result);
                });
        }

        private void UpdatePurchaseData(List<Purchase> purchases) {
            foreach (var v in _purchaseViews) {
                v.Data = null;
                v.gameObject.SetActive(false);
            }

            var viewIndex = 0;
            foreach (var purchase in purchases) {
                _purchaseViews[viewIndex].gameObject.SetActive(true);
                _purchaseViews[viewIndex].Data = purchase;
                if (++viewIndex >= _purchaseViews.Length) {
                    break;
                }
            }
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
                    LoadPurchases();
                });
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

        public string GetProductName(string productId) {
            if (_products.ContainsKey(productId)) {
                return _products[productId].title;
            }

            return "";
        }

        private void OnError(RuStoreError error) {
            Debug.LogErrorFormat("{0} : {1}", error.name, error.description);
        }
    }
}
