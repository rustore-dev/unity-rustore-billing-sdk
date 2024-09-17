using RuStore.Internal;
using System;
using UnityEngine;

namespace RuStore.BillingClient.Internal {

    public class ConfirmPurchaseResponseListener : SimpleResponseListener {

        private const string javaClassName = "ru.rustore.unitysdk.billingclient.callbacks.ConfirmPurchaseListener";

        public ConfirmPurchaseResponseListener(Action<RuStoreError> onFailure, Action onSuccess) : base(javaClassName, onFailure, onSuccess) {
        }
    }
}
