namespace RuStore.BillingClient {

    /// <summary>
    /// Родительский класс результатов покупки.
    /// </summary>
    public class PaymentResult {
    }

    /// <summary>
    /// Результат успешного завершения покупки цифрового товара.
    /// </summary>
    public class PaymentSuccess : PaymentResult {

        /// <summary>
        /// Уникальный идентификатор оплаты, сформированный приложением (опциональный параметр).
        /// Если вы укажете этот параметр в вашей системе, вы получите его в ответе при работе с API.
        /// Если не укажете, он будет сгенерирован автоматически (uuid).
        /// Максимальная длина 150 символов.
        /// </summary>
        public string orderId;

        /// <summary>
        /// Идентификатор покупки.
        /// </summary>
        public string purchaseId;

        /// <summary>
        /// Идентификатор продукта, который был присвоен продукту в RuStore Консоли.
        /// </summary>
        public string productId;

        /// <summary>
        /// Идентификатор счёта.
        /// </summary>
        public string invoiceId;

        /// <summary>
        /// Токен для валидации покупки на сервере.
        /// </summary>
        public string subscriptionToken;

        /// <summary>
        /// Определяет, является ли платёж тестовым.
        /// Значения могут быть true или false, где true обозначает тестовый платёж, а false – реальный.
        /// </summary>
        public bool sandbox;
    }

    /// <summary>
    /// Запрос на покупку отправлен, при этом пользователь закрыл «платёжную шторку» на своём устройстве, и результат оплаты неизвестен.
    /// </summary>
    public class PaymentCancelled : PaymentResult {

        /// <summary>
        /// Идентификатор покупки.
        /// </summary>
        public string purchaseId;

        /// <summary>
        /// Определяет, является ли платёж тестовым.
        /// Значения могут быть true или false, где true обозначает тестовый платёж, а false – реальный.
        /// </summary>
        public bool sandbox;
    }

    /// <summary>
    /// При отправке запроса на оплату или получения статуса оплаты возникла проблема, невозможно установить статус покупки.
    /// </summary>
    public class PaymentFailure : PaymentResult {

        /// <summary>
        /// Идентификатор покупки.
        /// </summary>
        public string purchaseId;

        /// <summary>
        /// Идентификатор счёта.
        /// </summary>
        public string invoiceId;

        /// <summary>
        /// Уникальный идентификатор оплаты, сформированный приложением (опциональный параметр).
        /// Если вы укажете этот параметр в вашей системе, вы получите его в ответе при работе с API.
        /// Если не укажете, он будет сгенерирован автоматически (uuid).
        /// Максимальная длина 150 символов.
        /// </summary>
        public string orderId;

        /// <summary>
        /// Количество продукта (необязательный параметр).
        /// </summary>
        public int? quantity;

        /// <summary>
        /// Идентификатор продукта, который был присвоен продукту в RuStore Консоли.
        /// </summary>
        public string productId;

        /// <summary>
        /// Код ошибки (необязательный параметр).
        /// </summary>
        public int? errorCode;

        /// <summary>
        /// Определяет, является ли платёж тестовым.
        /// Значения могут быть true или false, где true обозначает тестовый платёж, а false – реальный.
        /// </summary>
        public bool sandbox;
    }

    /// <summary>
    /// Ошибка работы SDK платежей.
    /// Может возникнуть, в случае некорректного обратного deeplink.
    /// </summary>
    public class InvalidPaymentState : PaymentResult {
    }
}
