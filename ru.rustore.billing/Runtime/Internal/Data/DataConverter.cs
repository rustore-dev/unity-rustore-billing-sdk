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
                productType = ConvertEnum<Product.ProductType>(obj.Get<AndroidJavaObject>("productType")),
                productStatus = (Product.ProductStatus)Enum.Parse(typeof(Product.ProductStatus), obj.Get<AndroidJavaObject>("productStatus").Call<string>("toString"), true),
                priceLabel = obj.Get<string>("priceLabel"),
                price = obj.Get<AndroidJavaObject>("price")?.Call<int>("intValue"),
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

            var purchase = new Purchase() {
                purchaseId = obj.Get<string>("purchaseId"),
                productId = obj.Get<string>("productId"),
                productType = ConvertEnum<Product.ProductType>(obj.Get<AndroidJavaObject>("productType")),
                invoiceId = obj.Get<string>("invoiceId"),
                language = obj.Get<string>("language"),
                purchaseTime = ConvertDateTime(obj.Get<AndroidJavaObject>("purchaseTime")),
                orderId = obj.Get<string>("orderId"),
                amountLabel = obj.Get<string>("amountLabel"),
                amount = obj.Get<AndroidJavaObject>("amount")?.Call<int>("intValue"),
                currency = obj.Get<string>("currency"),
                quantity = obj.Get<AndroidJavaObject>("quantity")?.Call<int>("intValue"),
                purchaseState = ConvertEnum<Purchase.PurchaseState>(obj.Get<AndroidJavaObject>("purchaseState")),
                developerPayload = obj.Get<string>("developerPayload"),
                subscriptionToken = obj.Get<string>("subscriptionToken")
            };

            return purchase;
        }

        public static UserAuthorizationStatus ConvertUserAuthorizationStatus(AndroidJavaObject obj) {
            if (obj == null) return null;

            return new UserAuthorizationStatus() {
                authorized = obj.Get<bool>("authorized")
            };
        }

        public static T? ConvertEnum<T>(AndroidJavaObject obj) where T : struct {
            Type type = typeof(T);
            string strValue = obj?.Call<string>("toString");
            object enumValue;

            return Enum.TryParse(type, strValue, true, out enumValue) ? (T?)enumValue : null;
        }

        public static DateTime? ConvertDateTime(AndroidJavaObject obj) {
            DateTime? dateTime = null;
            if (obj != null) {
                long time = obj.Call<long>("getTime");
                dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(time);
            }

            return dateTime;
        }
    }
}
