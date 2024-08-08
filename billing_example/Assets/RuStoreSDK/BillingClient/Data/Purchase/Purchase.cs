using System;

namespace RuStore.BillingClient {

    public class Purchase {

        public enum PurchaseState
        {
            CREATED,
            INVOICE_CREATED,
            CONFIRMED,
            PAID,
            CANCELLED,
            CONSUMED,
            CLOSED,
            PAUSED,
            TERMINATED
        }

        public string purchaseId;
        public string productId;
        public Product.ProductType productType;
        public string invoiceId;
        public string language;
        public DateTime purchaseTime;
        public string orderId;
        public string amountLabel;
        public int amount;
        public string currency;
        public int quantity;
        public PurchaseState purchaseState;
        public string developerPayload;
        public string subscriptionToken;
    }
}
