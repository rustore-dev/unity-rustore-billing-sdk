using System;
using UnityEngine;

namespace RuStore.Internal {


    public class SimpleResponseListener : AndroidJavaProxy {

        protected Action<RuStoreError> _onFailure;
        protected Action _onSuccess;

        public SimpleResponseListener(string className, Action<RuStoreError> onFailure, Action onSuccess) : base(className) {
            _onFailure = onFailure;
            _onSuccess = onSuccess;
        }

        public void OnFailure(AndroidJavaObject errorObject) {
            var error = ConvertError(errorObject);
            CallbackHandler.AddCallback(() => {
                _onFailure(error);
            });
        }

        public void OnSuccess() {
            CallbackHandler.AddCallback(() => {
                _onSuccess();
            });
        }
        protected virtual RuStoreError ConvertError(AndroidJavaObject errorObject) {
            var error = new RuStoreError();
            using (var errorJavaClass = errorObject.Call<AndroidJavaObject>("getClass")) {
                error.name = errorJavaClass.Call<string>("getSimpleName");
                error.description = errorObject.Call<string>("getMessage");
            }
            return error;
        }
    }

    public class SimpleResponseListener<T> : AndroidJavaProxy {

        protected Action<RuStoreError> _onFailure;
        protected Action<T> _onSuccess;

        public SimpleResponseListener(string className, Action<RuStoreError> onFailure, Action<T> onSuccess) : base(className) {
            _onFailure = onFailure;
            _onSuccess = onSuccess;
        }

        public void OnFailure(AndroidJavaObject errorObject) {
            var error = ConvertError(errorObject);
            CallbackHandler.AddCallback(() => {
                _onFailure(error);
            });
        }

        public void OnSuccess(T response) {
            CallbackHandler.AddCallback(() => {
                _onSuccess(response);
            });
        }
        protected virtual RuStoreError ConvertError(AndroidJavaObject errorObject) {
            var error = new RuStoreError();
            using (var errorJavaClass = errorObject.Call<AndroidJavaObject>("getClass")) {
                error.name = errorJavaClass.Call<string>("getSimpleName");
                error.description = errorObject.Call<string>("getMessage");
            }
            return error;
        }
    }
}
