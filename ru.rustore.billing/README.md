### RuStore Unity плагин для приема платежей через сторонние приложения  

#### [🔗 Документация разработчика][10]

#### Установка плагина в свой проект

Поддерживаются версии Unity 2022+. Для установки:

1. Импортируйте пакет `RuStore Core` в проект через Package Manager (Window → Package Manager → __+__ → Add package from git URL...). Для подключения используйте ссылку [https://gitflic.ru/project/rustore/unity-rustore-core-sdk.git?path=ru.rustore.core](https://gitflic.ru/project/rustore/unity-rustore-core-sdk.git?path=ru.rustore.core)

2. Импортируйте пакет `RuStore Billing` в проект через Package Manager (Window → Package Manager → __+__ → Add package from git URL...). Для подключения используйте ссылку [https://gitflic.ru/project/rustore/unity-rustore-billing-sdk.git?path=ru.rustore.billing](https://gitflic.ru/project/rustore/unity-rustore-billing-sdk.git?path=ru.rustore.billing)

3. Обновите зависимости проекта с помощью [External Dependency Manager](https://github.com/googlesamples/unity-jar-resolver.git?path=/upm): Assets → External Dependency Manager → Android Resolver → Force Resolve.


#### Установка External Dependency Manager

_External Dependency Manager_ для Android поставляется в составе пакета _RuStore Core_. Для установки:

1. Откройте `RuStore Core` в окне менеджера пакетов (Window → Package Manager → Packages RuStore → RuStore Core).

2. Перейдите на вкладку `Sample`.

3. Импортируйте сэмпл `External Dependency Manager`.

Вы также можете установить последнюю версию _External Dependency Manager_ из официального репозитория на [github](https://github.com/googlesamples/unity-jar-resolver.git?path=/upm).


#### История изменений

[CHANGELOG](../CHANGELOG.md)


#### Условия распространения

Данное программное обеспечение, включая исходные коды, бинарные библиотеки и другие файлы распространяется под лицензией MIT. Информация о лицензировании доступна в документе [MIT-LICENSE](../MIT-LICENSE.txt).


#### Техническая поддержка

Дополнительная помощь и инструкции доступны на странице [rustore.ru/help/](https://www.rustore.ru/help/) и по электронной почте __support@rustore.ru__.

[10]: https://www.rustore.ru/help/sdk/payments/unity/6-1-1
[20]: https://gitflic.ru/project/rpelmegov/unity-rustore-billing-sdk/blob/raw?file=upm_tgz%2Fru.rustore.core-6.1.0.tgz&inline=false
[30]: https://gitflic.ru/project/rpelmegov/unity-rustore-billing-sdk/blob/raw?file=upm_tgz%2Fru.rustore.billing-6.1.1.tgz.tgz&inline=false
