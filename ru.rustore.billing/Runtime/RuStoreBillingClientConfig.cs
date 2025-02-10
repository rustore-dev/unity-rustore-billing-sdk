using System;

namespace RuStore.BillingClient {

    /// <summary>
    /// Параметры инициализации платежного клиента.
    /// </summary>
    public class RuStoreBillingClientConfig {

        /// <summary>
        /// Идентификатор приложения из консоли RuStore.
        /// </summary>
        public string consoleApplicationId;

        /// <summary>
        /// URL-адрес для использования deeplink.
        /// В качестве названия может быть использовано любое уникальное имя (например: yourappscheme).
        /// </summary>
        public string deeplinkScheme;

        /// <summary>
        /// Разрешить обработку ошибок в нативном SDK.
        /// </summary>
        [Obsolete("This field is deprecated. Error handling must be performed on the application side.")]
        public bool allowNativeErrorHandling;

        /// <summary>
        /// Включить ведение журнала событий.
        /// </summary>
        public bool enableLogs;
    }
}
