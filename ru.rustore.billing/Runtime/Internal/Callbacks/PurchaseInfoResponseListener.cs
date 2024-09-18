using RuStore.Internal;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace RuStore.BillingClient.Internal {

    public class PurchaseInfoResponseListener : ResponseListener<Purchase> {

        private const string javaClassName = "ru.rustore.unitysdk.billingclient.callbacks.PurchaseInfoResponseListener";

        public PurchaseInfoResponseListener(Action<RuStoreError> onFailure, Action<Purchase> onSuccess) : base(javaClassName, onFailure, onSuccess) {
        }

        protected override Purchase ConvertResponse(AndroidJavaObject responseObject)  {
            var response = new Purchase();

            if (responseObject != null) {
                response = DataConverter.ConvertPurchase(responseObject);
            }
 
            return response;
        }
    }
}
