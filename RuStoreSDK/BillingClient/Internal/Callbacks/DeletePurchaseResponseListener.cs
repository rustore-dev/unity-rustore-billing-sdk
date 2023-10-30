using RuStore.Internal;
using System;
using UnityEngine;

namespace RuStore.BillingClient.Internal {

    public class DeletePurchaseResponseListener : SimpleResponseListener {

        private const string javaClassName = "ru.rustore.unitysdk.billingclient.callbacks.DeletePurchaseListener";

        public DeletePurchaseResponseListener(Action<RuStoreError> onFailure, Action onSuccess) : base(javaClassName, onFailure, onSuccess) {
        }
    }
}
