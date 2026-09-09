bool result = RuStoreBillingClient.Instance.Init(new RuStoreBillingClientConfig {
consoleApplicationId = "test_app_id",
deeplinkScheme = "test_scheme",
enableLogs = true
});