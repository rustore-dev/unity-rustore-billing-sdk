using System;
using UnityEngine;
using UnityEngine.UI;

namespace RuStore.BillingExample.UI {

    public class MessageBox : MonoBehaviour {

        [SerializeField]
        private Text _title;

        [SerializeField]
        private Text _message;

        private Action _onClose;

        public void Show(string title = null, string message = null, Action onClose = null) {
            if (_title != null && title != null) _title.text = title;
            if (_message != null && message != null) _message.text = message;

            _onClose = onClose;

            gameObject.SetActive(true);
        }

        public void Close() {
            gameObject.SetActive(false);
            _onClose?.Invoke();
        }
    }
}
