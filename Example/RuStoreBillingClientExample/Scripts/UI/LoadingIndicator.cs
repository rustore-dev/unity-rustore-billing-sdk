using UnityEngine;
using UnityEngine.UI;

namespace RuStore.Example.UI {

    public class LoadingIndicator : MonoBehaviour {

        [SerializeField]
        private RectTransform _indicator;

        [SerializeField]
        private Image _indicatorFillImage;

        [SerializeField]
        private float _rotationSpeed;

        [SerializeField]
        private float _fillSpeed;

        [SerializeField]
        private float _fillStart;

        [SerializeField]
        private float _hideTime;

        private float _hideTimer;
        private float _currentFillSpeed;

        private void Awake() {
            ResetIndicator();
        }

        private void Update() {

            var dt = Time.deltaTime;
            var fill = _indicatorFillImage.fillAmount + _currentFillSpeed * dt;

            if (fill < 0f || fill > 1f) {
                _currentFillSpeed = -_currentFillSpeed;
                var scale = _indicator.localScale;
                scale.x = -scale.x;
                _indicator.localScale = scale;
            }

            _indicatorFillImage.fillAmount = fill;
            _indicator.Rotate(new Vector3(0f, 0f, _rotationSpeed * dt));

            if (_hideTimer > 0f) {
                _hideTimer -= dt;
                if(_hideTimer < 0f) {
                    gameObject.SetActive(false);
                }
            }
        }

        public void Show() {
            if (!gameObject.activeSelf) {
                ResetIndicator();
                gameObject.SetActive(true);
            }
            _hideTimer = 0f;
        }

        public void Hide() {
            _hideTimer = _hideTime;            
        }

        private void ResetIndicator() {
            _currentFillSpeed = _fillSpeed;
            _indicatorFillImage.fillAmount = _fillStart;
            _indicator.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
