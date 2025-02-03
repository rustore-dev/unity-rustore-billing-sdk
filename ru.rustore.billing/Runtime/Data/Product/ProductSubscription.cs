using UnityEngine;

namespace RuStore.BillingClient {

    /// <summary>
    /// Информация о подписке.
    /// </summary>
    public class ProductSubscription {

        /// <summary>
        /// Период подписки.
        /// </summary>
        public SubscriptionPeriod subscriptionPeriod;

        /// <summary>
        /// Пробный период подписки.
        /// </summary>
        public SubscriptionPeriod freeTrialPeriod;

        /// <summary>
        /// Льготный период подписки.
        /// </summary>
        public SubscriptionPeriod gracePeriod;

        /// <summary>
        /// Отформатированная вступительная цена подписки, включая знак валюты, на языке RuStore.BillingClient.Product.language.
        /// </summary>
        public string introductoryPrice;

        /// <summary>
        /// Вступительная цена в минимальных единицах валюты (напрмер в копейках).
        /// </summary>
        public string introductoryPriceAmount;

        /// <summary>
        /// Расчётный период вступительной цены.
        /// </summary>
        public SubscriptionPeriod introductoryPricePeriod;
    }
}
