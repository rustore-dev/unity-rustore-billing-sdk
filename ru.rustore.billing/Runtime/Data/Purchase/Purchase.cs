using System;

namespace RuStore.BillingClient {

    /// <summary>
    /// Информация о покупке.
    /// </summary>
    public class Purchase {

        /// <summary>
        /// Состояние покупки.
        /// </summary>
        public enum PurchaseState
        {
            /// <summary>
            /// Покупка создана.
            /// </summary>
            CREATED,

            /// <summary>
            /// Создан счёт на оплату, покупка ожидает оплаты.
            /// </summary>
            INVOICE_CREATED,

            /// <summary>
            /// Платеж за непотребляемый товар успешно совершен
            /// </summary>
            CONFIRMED,

            /// <summary>
            /// Покупка ожидает подтверждения от разработчика.
            /// Только покупки потребляемого товара — промежуточный статус, средства на счёте покупателя зарезервированы.
            /// </summary>
            PAID,

            /// <summary>
            /// Покупка отменена — оплата не была произведена или был совершен возврат средств покупателю.
            /// Для подписок после возврата средств покупка не переходит в CANCELLED.
            /// </summary>
            CANCELLED,

            /// <summary>
            /// Платеж за потребляемый товар успешно совершен.
            /// </summary>
            CONSUMED,

            /// <summary>
            /// Для подписок — подписка перешла в HOLD период или закрылась.
            /// </summary>
            CLOSED,

            /// <summary>
            /// Для подписок — подписка перешла в HOLD период.
            /// </summary>
            PAUSED,

            /// <summary>
            /// Подписка закрылась.
            /// </summary>
            TERMINATED
        }

        /// <summary>
        /// Идентификатор покупки.
        /// </summary>
        public string purchaseId;

        /// <summary>
        /// Идентификатор продукта, который был присвоен продукту в консоли RuStore.
        /// </summary>
        public string productId;

        /// <summary>
        /// Тип продукта (необязательный параметр).
        /// </summary>
        public Product.ProductType? productType;

        /// <summary>
        /// Идентификатор счёта.
        /// </summary>
        public string invoiceId;

        /// <summary>
        /// Язык, указанный с помощью BCP 47 кодирования.
        /// </summary>
        public string language;

        /// <summary>
        /// Время покупки (необязательный параметр).
        /// </summary>
        public DateTime? purchaseTime;

        /// <summary>
        /// Уникальный идентификатор оплаты, сформированный приложением (опциональный параметр).
        /// Если вы укажете этот параметр в вашей системе, вы получите его в ответе при работе с API.
        /// Если не укажете, он будет сгенерирован автоматически (uuid).
        /// Максимальная длина 150 символов.
        /// </summary>
        public string orderId;

        /// <summary>
        /// Отформатированная цена покупки, включая валютный знак.
        /// </summary>
        public string amountLabel;

        /// <summary>
        /// Цена в минимальных единицах валюты.
        /// </summary>
        public int? amount;

        /// <summary>
        /// Код валюты ISO 4217.
        /// </summary>
        public string currency;

        /// <summary>
        /// Количество продукта (необязательный параметр).
        /// </summary>
        public int? quantity;

        /// <summary>
        /// Состояние покупки.
        /// </summary>
        public PurchaseState? purchaseState;

        /// <summary>
        /// Строка с дополнительной информацией о заказе, которую вы можете установить при инициализации процесса покупки.
        /// </summary>
        public string developerPayload;

        /// <summary>
        /// Токен для валидации покупки на сервере.
        /// </summary>
        public string subscriptionToken;
    }
}
