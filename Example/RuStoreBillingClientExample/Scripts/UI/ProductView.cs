using RuStore.BillingClient;
using UnityEngine;
using UnityEngine.UI;

namespace RuStore.Example.UI {

    public class ProductView : DataView<Product> {

        [SerializeField]
        private Text _productTitle;
        [SerializeField]
        private Text _priceLabel;

        protected override void OnDataUpdate() {
            base.OnDataUpdate();

            _productTitle.text = Data.title;
            _priceLabel.text = Data.priceLabel;
        }

        public void BuyProduct() {
            ExampleController.Instance.BuyProduct(Data.productId);
        }
    }
}
