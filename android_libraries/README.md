### RuStore Unity плагин для приема платежей через сторонние приложения

#### [🔗 Документация разработчика][10]

#### Пересборка .aar библиотеки

Если вам необходимо изменить код библиотек плагинов, вы можете внести изменения и пересобрать подключаемые .aar файлы.

1. Откройте в вашей IDE проект Android из папки _“android_libraries”_.

2. Выполните сборку проекта командой gradle assemble.

При успешном выполнении сборки в папке _“ru.rustore.billing / Runtime / Android”_ будет обновлен файл _RuStoreUnityBillingClient.aar_.

Для пересборки _RuStoreUnityCore.aar_ воспользуйтесь инструкциями из репозитрия плагина [RuStore Core](https://gitflic.ru/project/rustore/unity-rustore-core-sdk).


#### Установка плагина в свой проект

Чтобы использовать плагин с обновленным aar-файлом. Подключите пакет из папки _ru.rustore.billing_. Поддерживаются версии Unity 2022+. Для установки:

1. В проект должен быть подключен пакет _RuStore Core_ и _External Dependency Manager_. Воспользуйтесь любым подходящим способом из перечня [вариантов установки](../README.md).

2. Импортируйте пакет _RuStore Billing_ через Package Manager (Window → Package Manager → __+__ → Add package from disk...) указав на файл _package.json_ в папке _ru.rustore.billing_.

3. Обновите зависимости проекта с помощью [External Dependency Manager](https://github.com/googlesamples/unity-jar-resolver.git?path=/upm): Assets → External Dependency Manager → Android Resolver → Force Resolve.


#### История изменений

[CHANGELOG](../CHANGELOG.md)


#### Условия распространения

Данное программное обеспечение, включая исходные коды, бинарные библиотеки и другие файлы распространяется под лицензией MIT. Информация о лицензировании доступна в документе [MIT-LICENSE](../MIT-LICENSE.txt).


#### Техническая поддержка

Дополнительная помощь и инструкции доступны на странице [rustore.ru/help/](https://www.rustore.ru/help/) и по электронной почте __support@rustore.ru__.

[10]: https://www.rustore.ru/help/sdk/payments/unity/6-1-1
