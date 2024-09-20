### RuStore Unity плагин для приема платежей через сторонние приложения

#### [🔗 Документация разработчика][10]

#### Условия работы SDK{#Условия-работы-SDK}

Для работы SDK проведения платежей необходимо соблюдение следующих условий:

1. Пользователь и приложение не должны быть заблокированы в RuStore.

2. Для приложения включена возможность покупок в системе [RuStore Консоль](https://console.rustore.ru/).

> ⚠️ Сервис имеет ограничения на работу за пределами РФ.

Поддерживаются версии Unity 2022+.

#### Подготовка требуемых параметров

Перед настройкой примера приложения необходимо подготовить следующие данные:

1. `applicationId` — уникальный идентификатор приложения в системе Android в формате обратного доменного имени (пример: ru.rustore.sdk.example).

2. `*.keystore` — файл ключа, который используется для [подписи и аутентификации Android приложения](https://www.rustore.ru/help/developers/publishing-and-verifying-apps/app-publication/apk-signature/).

3. `consoleApplicationId` — код приложения из консоли разработчика RuStore (пример: https://console.rustore.ru/apps/123456, `consoleApplicationId` = 123456). Подробная информация о публикации приложений в RuStore доступна на странице [help](https://help.rustore.ru/rustore/for_developers/publishing_and_verifying_apps).

4. `productIds` — [подписки](https://www.rustore.ru/help/developers/monetization/create-app-subscription/) и [разовые покупки](https://www.rustore.ru/help/developers/monetization/create-paid-product-in-application/) доступные в вашем приложении.

5. `deeplinkScheme` — URL-адрес для использования deeplink. В качестве названия может быть использовано любое уникальное имя (например: example).


#### Настройка примера приложения

Для проверки работы приложения вы можете воспользоваться функционалом [тестовых платежей](https://www.rustore.ru/help/developers/monetization/sandbox).

1. Откройте проект Unity из папки _“billing_example”_.

2. Откройте настройки RuStore Billing SDK: Window → RuStoreSDK → Settings → BillingClient.

3. В поле _“Console Application Id”_ укажите значение `consoleApplicationId` — код приложения из консоли разработчика RuStore.

4. В поле _“Deeplink Scheme”_ укажите значение `deeplinkScheme` — URL-адрес для использования deeplink.

5. Откройте сцену _“BillingClientSampleScene”_ в списке Product Ids: объект _“ExampleController”_ → Example Controller (Script) перечислите [подписки](https://www.rustore.ru/help/developers/monetization/create-app-subscription/) и [разовые покупки](https://www.rustore.ru/help/developers/monetization/create-paid-product-in-application/) доступные в вашем приложении.

6. В разделе Publishing Settings: Edit → Project Settings → Player → Android Settings выберите вариант _“Custom Keystore”_ и задайте параметры “Path / Password”, “Alias / Password” подготовленного файла `*.keystore`.

7. В разделе Other Settings: Edit → Project Settings → Player → Android Settings настройте раздел “Identification”, отметив опцию “Override Default Package Name” и указав `applicationId` в поле “Package Name”.

8. Выполните сборку проекта командой Build: File → Build Settings и проверьте работу приложения.


#### Сценарий использования

##### Проверка доступности работы с платежами

Начальный экран приложения не содержит загруженных данных и уведомлений. Тап по кнопке `Availability` выполняет [проверку доступности платежей][20].

![Проверка доступности платежей](images/02_check_purchases_availability.png)


##### Получение списка продуктов

Тап по кнопке `Products` выполняет получение и отображение [списка продуктов][30].

![Получение списка продуктов](images/03_update_products_list.png)


##### Покупка продукта

Тап по кнопке `Buy` выполняет запуск сценария [покупки продукта][40] с отображением шторки выбора метода оплаты.

![Покупка продукта](images/04_purchase.png)


#### История изменений

[CHANGELOG](../CHANGELOG.md)


#### Условия распространения

Данное программное обеспечение, включая исходные коды, бинарные библиотеки и другие файлы распространяется под лицензией MIT. Информация о лицензировании доступна в документе [MIT-LICENSE](../MIT-LICENSE.txt).


#### Техническая поддержка

Дополнительная помощь и инструкции доступны на странице [rustore.ru/help/](https://www.rustore.ru/help/) и по электронной почте __support@rustore.ru__.

[10]: https://www.rustore.ru/help/sdk/payments/unity/6-1-1
[20]: https://www.rustore.ru/help/sdk/payments/unity/6-1-1#checkpurchasesavailability
[30]: https://www.rustore.ru/help/sdk/payments/unity/6-1-1#getproducts
[40]: https://www.rustore.ru/help/sdk/payments/unity/6-1-1#purchaseproduct
