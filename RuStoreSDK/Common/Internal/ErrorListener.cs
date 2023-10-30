using System;
using UnityEngine;

namespace RuStore.Internal {


    public class ErrorListener : AndroidJavaProxy {

        protected const string ClassName = "ru.rustore.unitysdk.core.callbacks.ErrorListener";

        protected Action<RuStoreError> _onFailure;

        public ErrorListener(Action<RuStoreError> onFailure) : base(ClassName) {
            _onFailure = onFailure;
        }

        public void OnFailure(AndroidJavaObject errorObject) {
            var error = ConvertError(errorObject);
            CallbackHandler.AddCallback(() => {
                _onFailure(error);
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
