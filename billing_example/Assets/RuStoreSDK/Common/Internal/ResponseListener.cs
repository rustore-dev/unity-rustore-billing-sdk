using System;
using UnityEngine;

namespace RuStore.Internal {

    public abstract class ResponseListener<T> : AndroidJavaProxy {

        protected Action<RuStoreError> _onFailure;
        protected Action<T> _onSuccess;

        public ResponseListener(string className, Action<RuStoreError> onFailure, Action<T> onSuccess) : base(className) {
            _onFailure = onFailure;
            _onSuccess = onSuccess;
        }

        public void OnFailure(AndroidJavaObject errorObject) {
            var error = ConvertError(errorObject);
            CallbackHandler.AddCallback(() => {
                _onFailure(error);
            });
        }

        public void OnSuccess(AndroidJavaObject responseObject) {
            var response = ConvertResponse(responseObject);
            CallbackHandler.AddCallback(() => {
                _onSuccess(response);
            });
        }

        protected abstract T ConvertResponse(AndroidJavaObject responseObject);

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
