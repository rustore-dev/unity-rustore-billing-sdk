RuStoreBillingClient.Instance.PurchaseProduct(
    productId: "product_123",
    quantity: 2,
    developerPayload: "custom_payload_data",
    onFailure: (error) => {
        // Process error
    },
    onSuccess: (result) => {
        // Process result
    }
);