using UnityEngine;

namespace RuStore.BillingClient {

    public class ProductSubscription {

        public SubscriptionPeriod subscriptionPeriod;
        public SubscriptionPeriod freeTrialPeriod;
        public SubscriptionPeriod gracePeriod;
        public string introductoryPrice;
        public string introductoryPriceAmount;
        public SubscriptionPeriod introductoryPricePeriod;
    }
}
