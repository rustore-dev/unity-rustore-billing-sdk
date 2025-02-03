namespace RuStore.BillingClient {

    /// <summary>
    /// Информация о продукте.
    /// </summary>
    public class Product {

        /// <summary>
        /// Статус продукта.
        /// </summary>
        public enum ProductStatus {

            /// <summary>
            /// Продукт доступен.
            /// </summary>
            ACTIVE,

            /// <summary>
            /// Продукт недоступен.
            /// </summary>
            INACTIVE
        }

        /// <summary>
        /// Тип продукта.
        /// </summary>
        public enum ProductType {

            /// <summary>
            /// Непотребляемый продукт (может быть приобретен один раз).
            /// </summary>
            NON_CONSUMABLE,

            /// <summary>
            /// Потребляемый продукт.
            /// </summary>
            CONSUMABLE,

            /// <summary>
            /// Подписка.
            /// </summary>
            SUBSCRIPTION
        }

        /// <summary>
        /// Идентификатор продукта, который был присвоен продукту в RuStore Консоли.
        /// </summary>
        public string productId;

        /// <summary>
        /// Тип продукта (необязательный параметр).
        /// </summary>
        public ProductType? productType;

        /// <summary>
        /// Статус продукта.
        /// </summary>
        public ProductStatus productStatus;

        /// <summary>
        /// Отформатированная цена товара, включая валютный знак на языке language.
        /// </summary>
        public string priceLabel;

        /// <summary>
        /// Цена в минимальных единицах (например в копейках) (необязательный параметр).
        /// </summary>
        public int? price;

        /// <summary>
        /// Код валюты ISO 4217.
        /// </summary>
        public string currency;

        /// <summary>
        /// Язык, указанный с помощью BCP 47 кодирования.
        /// </summary>
        public string language;

        /// <summary>
        /// Название продукта на языке language.
        /// </summary>
        public string title;

        /// <summary>
        /// Описание на языке language.
        /// </summary>
        public string description;

        /// <summary>
        /// Ссылка на картинку.
        /// </summary>
        public string imageUrl;

        /// <summary>
        /// Ссылка на промокартинку.
        /// </summary>
        public string promoImageUrl;

        /// <summary>
        /// Описание подписки, возвращается только для продуктов с типом RuStore.BillingClient.Product.ProductType.SUBSCRIPTION.
        /// </summary>
        public ProductSubscription subscription;
    }
}
