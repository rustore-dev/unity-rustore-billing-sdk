### Unity-плагин RuStore для приёма платежей через сторонние приложения

#### [🔗 Документация разработчика][10]

Плагин **RuStoreBillingClient** помогает интегрировать в ваш проект механизм оплаты через сторонние приложения (например: SberPay или СБП).

Репозиторий содержит плагины **RuStoreBillingClient** и **RuStoreCore**, а также демонстрационное приложение с примерами использования и настроек. Поддерживаются версии Unity 2022+.

#### Сборка примера приложения

Вы можете ознакомиться с демонстрационным приложением, содержащим представление работы всех методов SDK:
- [billing_example](https://gitflic.ru/project/rustore/unity-rustore-billing-sdk/file?file=billing_example).

#### Установка плагина в свой проект

Доступные варианты установки:

- подключение UPM-пакета через **Package Manager**:
   - вариант **Add package from tarball...** — рекомендуемый способ установки, см. [README](https://gitflic.ru/project/rustore/unity-rustore-billing-sdk/file?file=upm_tgz);
   - вариант **Add package from git URL...** — для немедленного получения последних изменений, см. [README](https://gitflic.ru/project/rustore/unity-rustore-billing-sdk/file?file=ru.rustore.billing);
   - вариант **Add package from disk...** — при необходимости самостоятельных доработок, см. [README](https://gitflic.ru/project/rustore/unity-rustore-billing-sdk/file?file=android_libraries);
- подключение `unitypackage` через **Import Assets** — устаревший способ установки, см. [README](https://gitflic.ru/project/rustore/unity-rustore-billing-sdk/file?file=unitypackages).

#### История изменений

[CHANGELOG](CHANGELOG.md)

#### Условия распространения

Данное программное обеспечение, включая исходные коды, бинарные библиотеки и другие файлы, распространяется под лицензией MIT. Информация о лицензировании доступна в документе [MIT-LICENSE](MIT-LICENSE.txt).

#### Техническая поддержка

Дополнительная помощь и инструкции доступны в [документации RuStore](https://www.rustore.ru/help/) и по электронной почте support@rustore.ru.

[10]: https://www.rustore.ru/help/sdk/payments/unity/9-0-1
