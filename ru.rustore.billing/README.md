### Unity-плагин RuStore для приёма платежей через сторонние приложения

#### [🔗 Документация разработчика][10]

#### Установка плагина в свой проект

Поддерживаются версии Unity 2022+. Для установки выполните следующие действия.

1. Импортируйте пакет **RuStore Core** в проект через **Package Manager** (**Window → Package Manager → __+__ → Add package from git URL...**). Для подключения используйте ссылку [https://gitflic.ru/project/rustore/unity-rustore-core-sdk.git?path=ru.rustore.core](https://gitflic.ru/project/rustore/unity-rustore-core-sdk.git?path=ru.rustore.core)
1. Импортируйте пакет **RuStore Billing** в проект через **Package Manager** (**Window → Package Manager → __+__ → Add package from git URL...**). Для подключения используйте ссылку [https://gitflic.ru/project/rustore/unity-rustore-billing-sdk.git?path=ru.rustore.billing](https://gitflic.ru/project/rustore/unity-rustore-billing-sdk.git?path=ru.rustore.billing)
1. Обновите зависимости проекта с помощью [**External Dependency Manager**](https://github.com/googlesamples/unity-jar-resolver.git?path=/upm) (**Assets → External Dependency Manager → Android Resolver → Force Resolve**).

#### Установка External Dependency Manager

**External Dependency Manager** для Android поставляется в составе пакета **RuStore Core**. Для установки выполните следующие действия.

1. Откройте **RuStore Core** в окне менеджера пакетов (**Window → Package Manager → Packages RuStore → RuStore Core**).
1. Перейдите на вкладку **Sample**.
1. Импортируйте сэмпл **External Dependency Manager**.

Вы также можете установить последнюю версию **External Dependency Manager** из официального репозитория на [GitHub](https://github.com/googlesamples/unity-jar-resolver.git?path=/upm).

#### История изменений

[CHANGELOG](../CHANGELOG.md)

#### Условия распространения

Данное программное обеспечение, включая исходные коды, бинарные библиотеки и другие файлы, распространяется под лицензией MIT. Информация о лицензировании доступна в документе [MIT-LICENSE](../MIT-LICENSE.txt).

#### Техническая поддержка

Дополнительная помощь и инструкции доступны в [документации RuStore](https://www.rustore.ru/help/) и по электронной почте support@rustore.ru.

[10]: https://www.rustore.ru/help/sdk/payments/unity/7-0-0
