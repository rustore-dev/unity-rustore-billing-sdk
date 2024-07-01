using RuStore.BillingClient;
using UnityEngine;
using UnityEngine.UI;

namespace RuStore.Example.UI {

    public class PurchaseView : DataView<Purchase> {

        [SerializeField]
        private Text _title;
        [SerializeField]
        private Text _purchaseState;
        [SerializeField]
        private Button _consumeButton;
        [SerializeField]
        private Button _deleteButton;

        protected override void OnDataUpdate() {
            base.OnDataUpdate();

            _title.text = ExampleController.Instance.GetProductName(Data.productId);
            _purchaseState.text = Data.purchaseState.ToString().Replace('_', ' ');

            _consumeButton.gameObject.SetActive(Data.productType == Product.ProductType.CONSUMABLE && Data.purchaseState == Purchase.PurchaseState.PAID);
            _deleteButton.gameObject.SetActive(Data.productType == Product.ProductType.CONSUMABLE && Data.purchaseState == Purchase.PurchaseState.PAID);
        }

        public void ConsumePurchase() {
            ExampleController.Instance.ConsumePurchase(Data.orderId);
        }

        public void DeletePurchase() {
            ExampleController.Instance.DeletePurchase(Data.orderId);
        }
    }
}
