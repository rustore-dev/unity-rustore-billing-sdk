namespace RuStore.BillingClient {

    /// <summary>
    /// Статус авторизации у пользователя.
    /// </summary>
    public class UserAuthorizationStatus {

        /// <summary>
        /// Значение статуса авторизации у пользователя.
        /// Если true, то пользователь авторизован в RuStore.
        /// Если false, то пользователь не авторизован.
        /// В случае использования SDK вне RuStore результат true также может вернуться,
        /// если в процессе оплаты пользователь авторизовался через VK ID и с момента авторизации прошло менее 15 минут.
        /// </summary>
        public bool authorized;
    }
}
