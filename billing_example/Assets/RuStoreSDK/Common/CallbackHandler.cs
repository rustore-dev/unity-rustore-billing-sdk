using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RuStore {

    public class CallbackHandler : MonoBehaviour {

        private object _lockObject;
        private List<Action> _callbacks = new List<Action>();

        private static CallbackHandler _instance;

        private static bool _destroyed;

        private static bool HasInstance {
            get { return !_destroyed && _isInstanceCreated; }
        }

        private static bool _isInstanceCreated;

        private static CallbackHandler Instance {
            get {
                if (!_isInstanceCreated && !_destroyed) {
                    InitInstance();
                }

                return _instance;
            }
        }


        void Awake() {
            _lockObject = new object();
            _isInstanceCreated = true;
            _instance = GetComponent<CallbackHandler>();
        }

        private void OnApplicationQuit() {
            _destroyed = true;
        }

        void Update() {
            lock (_lockObject) {
                if (_callbacks.Any()) {
                    foreach (var c in _callbacks) {
                        c.Invoke();
                    }
                    _callbacks.Clear();
                }
            }
        }

        private void AddCallbackInternal(Action callback) {
            lock (_lockObject) {
                _callbacks.Add(callback);
            }
        }

        public static void InitInstance() {
            if (!_isInstanceCreated && !_destroyed) {
                _isInstanceCreated = true;
                _instance = FindObjectOfType<CallbackHandler>();
                if (_instance == null) {
                    _instance = new GameObject("RuStoreCallbackHandler").AddComponent<CallbackHandler>();
                }

                if (Application.isPlaying) {
                    DontDestroyOnLoad(_instance.gameObject);
                }
            }
        }

        public static void AddCallback(Action callback) {
            Instance.AddCallbackInternal(callback);
        }
    }
}