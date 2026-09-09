using RuStore.BillingClient;
using RuStore.BillingExample.Internal;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace RuStore.BillingExample.UI {

    public class ProductInfoBox : MessageBox {

        [SerializeField]
        private Transform _resizibleView;

        public void Show(Product product) {
            var json = DataSerializer.SerializeToJson(product, true).Trim('{', '}');
            var jsonWithLinks = JsonLinkExtractor.AddLinksToJson(json);

            Show(message: jsonWithLinks);

            StartCoroutine(WaitAndUpdate());
        }

        private IEnumerator WaitAndUpdate() {
            yield return new WaitForEndOfFrame();

            LayoutRebuilder.ForceRebuildLayoutImmediate(_resizibleView as RectTransform);
        }
    }
}
