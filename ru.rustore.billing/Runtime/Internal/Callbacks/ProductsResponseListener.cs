using RuStore.Internal;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace RuStore.BillingClient.Internal {

    public class ProductsResponseListener : ResponseListener<List<Product>> {

        private const string javaClassName = "ru.rustore.unitysdk.billingclient.callbacks.ProductsResponseListener";

        public ProductsResponseListener(Action<RuStoreError> onFailure, Action<List<Product>> onSuccess) : base(javaClassName, onFailure, onSuccess) {
        }

        protected override List<Product> ConvertResponse(AndroidJavaObject responseObject) {
            var response = new List<Product>();

            if (responseObject != null) {
                var size = responseObject.Call<int>("size");
                for (var i = 0; i < size; i++) {
                    using (var p = responseObject.Call<AndroidJavaObject>("get", i)) {
                        if (p != null) {
                            response.Add(DataConverter.ConvertProduct(p));
                        }
                    }
                }
            }

            return response;
        }
    }
}
