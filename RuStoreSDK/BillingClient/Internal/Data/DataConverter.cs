using UnityEngine;
using System.Collections.Generic;
using System;

namespace RuStore.BillingClient.Internal {

    public static class DataConverter
    {

        public static Product ConvertProduct(AndroidJavaObject obj) {
            if (obj == null) {
                return null;
            }

            var product = new Product() {
                productId = obj.Get<string>("productId"),
                productType = (Product.ProductType)Enum.Parse(typeof(Product.ProductType), obj.Get<AndroidJavaObject>("productType").Call<string>("toString"), true),
                productStatus = (Product.ProductStatus)Enum.Parse(typeof(Product.ProductStatus), obj.Get<AndroidJavaObject>("productStatus").Call<string>("toString"), true),
                priceLabel = obj.Get<string>("priceLabel"),
                price = obj.Get<AndroidJavaObject>("price")?.Call<int>("intValue") ?? 0,
                currency = obj.Get<string>("currency"),
                language = obj.Get<string>("language"),
                title = obj.Get<string>("title"),
                description = obj.Get<string>("description"),
                imageUrl = obj.Get<AndroidJavaObject>("imageUrl")?.Call<string>("toString"),
                promoImageUrl = obj.Get<AndroidJavaObject>("promoImageUrl")?.Call<string>("toString")
            };

            using (var subscription = obj.Get<AndroidJavaObject>("subscription")) {
                if (subscription != null) {
                    product.subscription = ConvertProductSubscription(subscription);
                }
            }

            return product;
        }

        public static DigitalShopGeneralError ConvertDigitalShopGeneralError(AndroidJavaObject obj) {
            if (obj == null) {
                return null;
            }

            var error = new DigitalShopGeneralError() {
                name = obj.Get<string>("name"),
                code = obj.Get<AndroidJavaObject>("code")?.Call<int>("intValue") ?? 0,
                description = obj.Get<string>("description")
            };

            return error;
        }

        public static ProductSubscription ConvertProductSubscription(AndroidJavaObject obj) {
            if (obj == null) {
                return null;
            }

            var subscription = new ProductSubscription() {
                subscriptionPeriod = ConvertSubscriptionPeriod(obj.Get<AndroidJavaObject>("subscriptionPeriod")),
                freeTrialPeriod = ConvertSubscriptionPeriod(obj.Get<AndroidJavaObject>("freeTrialPeriod")),
                gracePeriod = ConvertSubscriptionPeriod(obj.Get<AndroidJavaObject>("gracePeriod")),
                introductoryPrice = obj.Get<string>("introductoryPrice"),
                introductoryPriceAmount = obj.Get<string>("introductoryPriceAmount"),
                introductoryPricePeriod = ConvertSubscriptionPeriod(obj.Get<AndroidJavaObject>("introductoryPricePeriod"))
            };

            return subscription;
        }

        public static SubscriptionPeriod ConvertSubscriptionPeriod(AndroidJavaObject obj) {
            if (obj == null) {
                return null;
            }

            var subscriptionPeriod = new SubscriptionPeriod() {
                years = obj.Get<int>("years"),
                months = obj.Get<int>("months"),
                days = obj.Get<int>("days")
            };
            return subscriptionPeriod;
        }

        public static Purchase ConvertPurchase(AndroidJavaObject obj) {
            if (obj == null) {
                return null;
            }

            var startDate = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

            var purchase = new Purchase() {
                purchaseId = obj.Get<string>("purchaseId"),
                productId = obj.Get<string>("productId"),
                productType = (Product.ProductType)Enum.Parse(typeof(Product.ProductType), obj.Get<AndroidJavaObject>("productType").Call<string>("toString"), true),
                invoiceId = obj.Get<string>("invoiceId"),
                description = obj.Get<string>("description"),
                language = obj.Get<string>("language"),
                purchaseTime = startDate.AddMilliseconds(obj.Get<AndroidJavaObject>("purchaseTime").Call<long>("getTime")),
                orderId = obj.Get<string>("orderId"),
                amountLabel = obj.Get<string>("amountLabel"),
                amount = obj.Get<AndroidJavaObject>("amount")?.Call<int>("intValue") ?? 0,
                currency = obj.Get<string>("currency"),
                quantity = obj.Get<AndroidJavaObject>("quantity")?.Call<int>("intValue") ?? 0,
                purchaseState = (Purchase.PurchaseState)Enum.Parse(typeof(Purchase.PurchaseState), obj.Get<AndroidJavaObject>("purchaseState").Call<string>("toString"), true),
                developerPayload = obj.Get<string>("developerPayload"),
                subscriptionToken = obj.Get<string>("subscriptionToken")
            };

            return purchase;
        }

        public static void InitResponseWithCode(AndroidJavaObject obj, ResponseWithCode response) {
            response.code = obj.Get<int>("code");
            response.errorMessage = obj.Get<string>("errorMessage");
            response.errorDescription = obj.Get<string>("errorDescription");
            response.errors = new List<DigitalShopGeneralError>();

            using (var meta = obj.Get<AndroidJavaObject>("meta")) {
                if (meta != null) {
                    response.meta = new RequestMeta() {
                        traceId = meta.Get<string>("traceId")
                    };
                }
            }

            using (var errors = obj.Get<AndroidJavaObject>("errors")) {
                if (errors != null) {
                    var size = errors.Call<int>("size");
                    for (var i = 0; i < size; i++) {
                        using (var e = errors.Call<AndroidJavaObject>("get", i)) {
                            if (e != null) {
                                response.errors.Add(ConvertDigitalShopGeneralError(e));
                            }
                        }
                    }
                }
            }
        }
    }
}
