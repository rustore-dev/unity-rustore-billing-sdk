using System.Collections.Generic;
using UnityEngine;

namespace RuStore.BillingExample.UI {
    
    public class CardsView : MonoBehaviour {
        [SerializeField]
        private GameObject prefab;

        [SerializeField]
        private Transform content;

        private GameObject[] items = { };

        public void SetData<T>(List<T> data) {
            foreach (var i in items) {
                Destroy(i);
            }

            var index = 0;
            items = new GameObject[data.Count];

            if (content == null) content = transform;

            foreach (var d in data) {
                var view = items[index++] = Instantiate(prefab, content).gameObject;

                view.GetComponent<ICardView<T>>().SetData(d);
            }
        }
    }
}
