using RuStore.BillingClient;
using UnityEngine;
using UnityEngine.UI;

namespace RuStore.Example.UI {

    public class PurchaseView : DataView<Purchase> {

        [SerializeField]
        private Text _title;
        [SerializeField]
        private Button _consumeButton;

        protected override void OnDataUpdate() {
            base.OnDataUpdate();

            _title.text = ExampleController.Instance.GetProductName(Data.productId);

            _consumeButton.gameObject.SetActive(Data.productType == Product.ProductType.CONSUMABLE);
        }

        public void ConsumePurchase() {
            ExampleController.Instance.ConsumePurchase(Data.orderId);
        }
    }
}
