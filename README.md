
[Документация по интеграции SDK.](https://help.rustore.ru/rustore/for_developers/developer-documentation/sdk_payments/sdk_payments_unity)

Пример интеграции SDK.

Импортируйте пакет Example/RuStoreBillingSDKExample.unitypackage в новый проект Unity.

Откройте настройки проекта: File -> Edit -> Project Settings -> Player -> Android Settings.
- pаздел Publishing Settings: включите настройки Custom Main Manifest, Custom Main Gradle Template, Custom Gradle Properties Template, настройте keystore для подписи приложения. 
- раздел Other Settings: настройте package name, Minimum API Level = 24, Target API Level = 33 или выше.

Откройте настройки External Dependency Manager: Assets -> External Dependency Manager -> Android Resolver -> Settings
- включите настройки Use Jetifier, Patch mainTemplate.gradle, Patch gradleTemplate.properties.

Обновите зависимости проекта: Assets -> External Dependency Manager -> Android Resolver -> Force Resolve

Откройте настройки RuStore Billing SDK: Window -> RuStoreSDK -> Settings -> BillingClient. 
- Console Application Id — код приложения из системы RuStore Консоль
- Deeplink Prefix - rustoreunitysdkexample
 
Откройте сцену BillingClientSampleScene и добавьте идентификаторы продуктов для покупки в список в объекте ExampleController: скрипт Example Controller -> Product Ids.
