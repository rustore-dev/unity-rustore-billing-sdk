namespace RuStore.BillingClient {

    public class Product {

        public enum ProductStatus {

            ACTIVE,
            INACTIVE
        }

        public enum ProductType {

            NON_CONSUMABLE,
            CONSUMABLE,
            SUBSCRIPTION
        }

        public string productId;
        public ProductType productType;
        public ProductStatus productStatus;
        public string priceLabel;
        public int price;
        public string currency;
        public string language;
        public string title;
        public string description;
        public string imageUrl;
        public string promoImageUrl;
        public ProductSubscription subscription;
    }
}
