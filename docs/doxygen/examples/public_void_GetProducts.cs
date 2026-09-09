RuStoreBillingClient.Instance.GetProducts(
    productIds: new string[] { "product_id_1", "product_id_2" },
    onFailure: (error) => {
        // Process error
    },
    onSuccess: (products) => {
        // Process products list
    }
);