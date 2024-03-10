using System;
using UnityEngine;
using UnityEngine.UI;

namespace RuStore.Example.UI {

    public class MessageBox : MonoBehaviour {

        [SerializeField]
        private Text _title;
        [SerializeField]
        private Text _message;

        private Action _onClose;

        public void Show(string title, string message, Action onClose = null) {
            _title.text = title;
            _message.text = message;

            _onClose = onClose;

            gameObject.SetActive(true);
        }

        public void Close() {
            gameObject.SetActive(false);
            _onClose?.Invoke();
        }
    }
}
