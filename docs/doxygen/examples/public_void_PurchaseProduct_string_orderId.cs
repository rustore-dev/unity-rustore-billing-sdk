RuStoreBillingClient.Instance.PurchaseProduct(
    productId: "product_123",
    orderId: "order_456",
    quantity: 1,
    developerPayload: "additional_info",
    onFailure: (error) => {
        // Process error
    },
    onSuccess: (result) => {
        // Process result
    }
);