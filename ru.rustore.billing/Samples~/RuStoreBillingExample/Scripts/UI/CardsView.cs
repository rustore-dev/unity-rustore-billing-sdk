using System.Collections.Generic;
using UnityEngine;

namespace RuStore.BillingExample.UI {
    
    public class CardsView : MonoBehaviour {
        [SerializeField]
        private GameObject prefab;

        private GameObject[] items = { };

        public void SetData<T>(List<T> data) {
            foreach (var i in items) {
                Destroy(i);
            }

            var index = 0;
            items = new GameObject[data.Count];

            foreach (var d in data) {
                var view = items[index++] = Instantiate(prefab, transform).gameObject;

                view.GetComponent<ICardView<T>>().SetData(d);
            }
        }
    }
}
