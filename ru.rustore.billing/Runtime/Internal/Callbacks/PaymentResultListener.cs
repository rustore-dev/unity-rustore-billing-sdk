using RuStore.Internal;
using System;
using UnityEngine;

namespace RuStore.BillingClient.Internal {

    public class PaymentResultListener : ResponseListener<PaymentResult> {

        private const string javaClassName = "ru.rustore.unitysdk.billingclient.callbacks.PaymentResultListener";

        public PaymentResultListener(Action<RuStoreError> onFailure, Action<PaymentResult> onSuccess) : base(javaClassName, onFailure, onSuccess) {
        }

        protected override PaymentResult ConvertResponse(AndroidJavaObject responseObject) {
            var resultType = "";
            if (responseObject != null) {
                using (var javaClass = responseObject.Call<AndroidJavaObject>("getClass")) {
                    var className = javaClass.Call<string>("getName").Split('$');
                    resultType = className[className.Length - 1];
                }
            }

            switch (resultType) {
                case "Success":
                    return new PaymentSuccess() {
                        orderId = responseObject.Get<string>("orderId"),
                        purchaseId = responseObject.Get<string>("purchaseId"),
                        productId = responseObject.Get<string>("productId"),
                        invoiceId = responseObject.Get<string>("invoiceId"),
                        subscriptionToken = responseObject.Get<string>("subscriptionToken"),
                        sandbox = responseObject.Get<bool>("sandbox")
                    };
                case "Cancelled":
                    return new PaymentCancelled() {
                        purchaseId = responseObject.Get<string>("purchaseId"),
                        sandbox = responseObject.Get<bool>("sandbox")
                    };
                case "Failure":
                    return new PaymentFailure() {
                        orderId = responseObject.Get<string>("orderId"),
                        purchaseId = responseObject.Get<string>("purchaseId"),
                        productId = responseObject.Get<string>("productId"),
                        invoiceId = responseObject.Get<string>("invoiceId"),
                        quantity = responseObject.Get<AndroidJavaObject>("quantity")?.Call<int>("intValue"),
                        errorCode = responseObject.Get<AndroidJavaObject>("errorCode")?.Call<int>("intValue"),
                        sandbox = responseObject.Get<bool>("sandbox")
                    };
                default:
                    return new InvalidPaymentState();
            }
        }
    }
}
