RuStoreBillingClient.Instance.ConfirmPurchase(
        purchaseId: "purchase_123",
        onFailure: (error) => {
            // Process error
        },
        onSuccess: () => {
            // Process success
        }
    );