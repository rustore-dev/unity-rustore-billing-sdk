using System;
using UnityEngine;

namespace RuStore.Internal {

    public class FeatureAvailabilityListener : ResponseListener<FeatureAvailabilityResult> {

        private const string javaClassName = "ru.rustore.unitysdk.core.callbacks.FeatureAvailabilityListener";

        public FeatureAvailabilityListener(Action<RuStoreError> onFailure, Action<FeatureAvailabilityResult> onSuccess) : base(javaClassName, onFailure, onSuccess) {
        }

        protected override FeatureAvailabilityResult ConvertResponse(AndroidJavaObject responseObject) {
            var resultType = "";
            using (var javaClass = responseObject.Call<AndroidJavaObject>("getClass")) {
                var className = javaClass.Call<string>("getName").Split('$');
                resultType = className[className.Length - 1];
            }

            var response = new FeatureAvailabilityResult();

            switch (resultType) {
                case "Unavailable":
                    response.isAvailable = false;
                    using (var causeObject = responseObject.Get<AndroidJavaObject>("cause")) {
                        using (var causeJavaClass = causeObject.Call<AndroidJavaObject>("getClass")) {
                            response.cause = new RuStoreError() {
                                name = causeJavaClass.Call<string>("getSimpleName"),
                                description = causeObject.Call<string>("getMessage")
                            };
                        }
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
