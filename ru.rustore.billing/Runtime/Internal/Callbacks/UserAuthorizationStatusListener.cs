using RuStore.Internal;
using System;
using UnityEngine;

namespace RuStore.BillingClient.Internal {

    public class UserAuthorizationStatusListener : ResponseListener<UserAuthorizationStatus> {

        private const string javaClassName = "ru.rustore.unitysdk.billingclient.callbacks.AuthorizationStatusListener";

        public UserAuthorizationStatusListener(Action<RuStoreError> onFailure, Action<UserAuthorizationStatus> onSuccess) : base(javaClassName, onFailure, onSuccess) {
        }

        protected override UserAuthorizationStatus ConvertResponse(AndroidJavaObject responseObject) =>
            DataConverter.ConvertUserAuthorizationStatus(responseObject);
    }
}
