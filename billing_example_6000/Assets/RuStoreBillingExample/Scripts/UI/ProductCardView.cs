using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using RuStore.BillingClient;
using UnityEngine.Networking;

namespace RuStore.BillingExample.UI {

    public class ProductCardView : MonoBehaviour, ICardView<Product> {

        [SerializeField]
        private RawImage productImage;

        [SerializeField]
        private Text productId;

        [SerializeField]
        private Text productTitle;

        [SerializeField]
        private Text productType;

        [SerializeField]
        private Text productStatus;

        [SerializeField]
        private Text productPrice;

        public static event EventHandler OnBuyProduct;

        private Product product = null;

        public void SetData(Product product) {
            this.product = product;

            StartCoroutine(LoadImage(product.imageUrl));

            if (productId != null) productId.text = product.productId;
            if (productTitle != null) productTitle.text = product.title;
            if (productType != null) productType.text = product.productType.ToString();
            if (productStatus != null) productStatus.text = product.productStatus.ToString();
            if (productPrice != null) productPrice.text = product.priceLabel;
        }

        public Product GetData() {
            return product;
        }

        public void BuyProduct() {
            OnBuyProduct?.Invoke(this, EventArgs.Empty);
        }

        IEnumerator LoadImage(string url) {
            using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(url)) {
                yield return www.SendWebRequest();

                if (www.result == UnityWebRequest.Result.Success){
                    productImage.texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
                }
            }
        }
    }
}
