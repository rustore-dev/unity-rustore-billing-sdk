RuStoreBillingClient.Instance.GetPurchaseInfo(
    purchaseId: "purchase_123",
    onFailure: (error) => {
        // Process error
    },
    onSuccess: (purchase) => {
        // Process purchase info
    }
);