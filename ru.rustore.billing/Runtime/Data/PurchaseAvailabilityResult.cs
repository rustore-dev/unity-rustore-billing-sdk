namespace RuStore.BillingClient {

    /// <summary>
    /// Результат проверки доступности работы с платежами.
    /// </summary>
    public class PurchaseAvailabilityResult {

        /// <summary>
        /// Информация о доступности.
        /// Если все условия выполняются, возвращается RuStore.PayClient.PurchaseAvailabilityResult.isAvailable == true.
        /// В противном случае возвращается RuStore.PayClient.PurchaseAvailabilityResult.isAvailable == false.
        /// </summary>
        public bool isAvailable;

        /// <summary>
        /// Информация об ошибке.
        /// </summary>
        public RuStoreError cause;
    }
}
