using RuStore.Internal;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace RuStore.BillingClient.Internal {

    public class PurchasesResponseListener : ResponseListener<List<Purchase>> {

        private const string javaClassName = "ru.rustore.unitysdk.billingclient.callbacks.PurchasesResponseListener";

        public PurchasesResponseListener(Action<RuStoreError> onFailure, Action<List<Purchase>> onSuccess) : base(javaClassName, onFailure, onSuccess) {
        }

        protected override List<Purchase> ConvertResponse(AndroidJavaObject responseObject)  {
            var response = new List<Purchase>();

            if (responseObject != null) {
                var size = responseObject.Call<int>("size");
                for (var i = 0; i < size; i++) {
                    using (var p = responseObject.Call<AndroidJavaObject>("get", i)) {
                        if (p != null) {
                            response.Add(DataConverter.ConvertPurchase(p));
                        }
                    }
                }
            }

            return response;
        }
    }
}
