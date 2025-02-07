using RuStore.Internal;
using System;
using UnityEngine;

namespace RuStore.BillingClient.Internal {

    public class PurchaseAvailabilityListener : ResponseListener<PurchaseAvailabilityResult> {

        private const string javaClassName = "ru.rustore.unitysdk.billingclient.callbacks.PurchaseAvailabilityListener";

        public PurchaseAvailabilityListener(Action<RuStoreError> onFailure, Action<PurchaseAvailabilityResult> onSuccess) : base(javaClassName, onFailure, onSuccess) {
        }

        protected override PurchaseAvailabilityResult ConvertResponse(AndroidJavaObject responseObject) {
            var resultType = "";
            using (var javaClass = responseObject.Call<AndroidJavaObject>("getClass")) {
                var className = javaClass.Call<string>("getName").Split('$');
                resultType = className[className.Length - 1];
            }

            var response = new PurchaseAvailabilityResult();

            switch (resultType) {
                case "Unavailable":
                    response.isAvailable = false;
                    using (var causeObject = responseObject.Get<AndroidJavaObject>("cause")) {
                        response.cause = ErrorDataConverter.ConvertError(causeObject);
                    }
                    break;
                case "Available":
                    response.isAvailable = true;
                    break;
                default:
                    response.isAvailable = false;
                    response.cause = new RuStoreError() {
                        name = "Error",
                        description = "Invalid response type"
                    };
                    break;
            }

            return response;
        }
    }
}
