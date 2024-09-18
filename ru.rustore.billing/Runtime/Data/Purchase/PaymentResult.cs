namespace RuStore.BillingClient {

    public class PaymentResult {
    }

    public class PaymentSuccess : PaymentResult {

        public string orderId;
        public string purchaseId;
        public string productId;
        public string invoiceId;
        public string subscriptionToken;
        public bool sandbox;
    }

    public class PaymentCancelled : PaymentResult {

        public string purchaseId;
        public bool sandbox;
    }

    public class PaymentFailure : PaymentResult {

        public string purchaseId;
        public string invoiceId;
        public string orderId;
        public int quantity;
        public string productId;
        public int errorCode;
        public bool sandbox;
    }

    public class InvalidPaymentState : PaymentResult {
    }
}
