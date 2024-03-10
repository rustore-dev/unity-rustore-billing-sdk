using UnityEngine;

namespace RuStore.Example.UI {

    public class DataView<T> : MonoBehaviour {

        private T _data;
        public T Data {
            get {
                return _data;
            }

            set {
                _data = value;
                OnDataSet();
            }
        }

        private void OnDataSet() {
            if (_data == null) {
                return;
            }

            OnDataUpdate();
        }

        protected virtual void OnDataUpdate() {
        }
    }
}
