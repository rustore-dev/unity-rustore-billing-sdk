### RuStore Unity плагин для приема платежей через сторонние приложения  

#### [🔗 Документация разработчика][10]  

#### Установка плагина в свой проект

Поддерживаются версии Unity 2022+. Для установки:

1. Скачайте пакет [RuStoreUnityBillingSDK-x.y.z.unitypackage][20] и импортируйте в проект: (Assets → Import Package → Custom Package...).

2. Откройте настройки проекта: Edit → Project Settings → Player → Android Settings.

3. В pазделе Publishing Settings: включите настройки Custom Main Manifest, Custom Main Gradle Template, Custom Gradle Properties Template. 

4. В разделе Other Settings: настройте package name, Minimum API Level = 24, Target API Level = 34.

5. Обновите зависимости проекта: Assets → External Dependency Manager → Android Resolver → Force Resolve.


#### История изменений

[CHANGELOG](../CHANGELOG.md)


#### Условия распространения

Данное программное обеспечение, включая исходные коды, бинарные библиотеки и другие файлы распространяется под лицензией MIT. Информация о лицензировании доступна в документе [MIT-LICENSE](../MIT-LICENSE.txt).


#### Техническая поддержка

Дополнительная помощь и инструкции доступны на странице [rustore.ru/help/](https://www.rustore.ru/help/) и по электронной почте __support@rustore.ru__.

[10]: https://www.rustore.ru/help/sdk/payments/unity/6-1-1
[20]: https://gitflic.ru/project/rpelmegov/unity-rustore-billing-sdk/blob/raw?file=unitypackages%2FRuStoreUnityBillingSDK-6.1.1.unitypackage&inline=false
