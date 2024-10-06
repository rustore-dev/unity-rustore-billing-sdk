### Unity-плагин RuStore для приёма платежей через сторонние приложения

#### [🔗 Документация разработчика][10]

#### Пересборка библиотеки `.aar`

Если вам необходимо изменить код библиотек плагинов, вы можете внести изменения и пересобрать подключаемые файлы `.aar`.

1. Откройте в вашей IDE проект Android из папки `android_libraries`.
1. Выполните сборку проекта командой `gradle assemble`.

При успешном выполнении сборки в папке `ru.rustore.billing/Runtime/Android` будет обновлён файл `RuStoreUnityBillingClient.aar`.

Для пересборки `RuStoreUnityCore.aar` воспользуйтесь инструкциями из репозитория плагина [RuStore Core](https://gitflic.ru/project/rustore/unity-rustore-core-sdk).

#### Установка плагина в свой проект

Чтобы использовать плагин с обновлённым AAR-файлом, подключите пакет из папки `ru.rustore.billing`. Поддерживаются версии Unity 2022+. Для установки выполните следующие действия.

1. Подключите в проект пакет **RuStore Core** и **External Dependency Manager**. Воспользуйтесь любым подходящим способом из перечня [вариантов установки](../README.md).
1. Импортируйте пакет **RuStore Billing** через **Package Manager** (**Window → Package Manager → __+__ → Add package from disk...**), указав на файл `package.json_` в папке `ru.rustore.billing`.
1. Обновите зависимости проекта с помощью [**External Dependency Manager**](https://github.com/googlesamples/unity-jar-resolver.git?path=/upm) (**Assets → External Dependency Manager → Android Resolver → Force Resolve**).

#### История изменений

[CHANGELOG](../CHANGELOG.md)

#### Условия распространения

Данное программное обеспечение, включая исходные коды, бинарные библиотеки и другие файлы, распространяется под лицензией MIT. Информация о лицензировании доступна в документе [MIT-LICENSE](../MIT-LICENSE.txt).

#### Техническая поддержка

Дополнительная помощь и инструкции доступны в [документации RuStore](https://www.rustore.ru/help/) и по электронной почте support@rustore.ru.

[10]: https://www.rustore.ru/help/sdk/payments/unity/6-1-1
