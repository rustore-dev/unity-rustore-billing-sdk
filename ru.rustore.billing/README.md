<!-- ── Language switch (RU active) ──────────────────────────────────── -->
<div align="left" style="margin:0 0 14px 0;">

  <span style="display:inline-block;
               padding:.28rem .6rem;
               border:1px solid rgba(0,0,0,.18);
               border-radius:10px 0 0 10px;
               font-weight:400;
               font-size:12px;
               letter-spacing:.06em;
               color:#111827;
               background:linear-gradient(180deg,#e9edf2,#ffffff);
               box-shadow:inset 0 2px 6px rgba(0,0,0,.10);">
    RU
  </span><span style="display:inline-block;
               margin-left:-1px;
               padding:.28rem .6rem;
               border:1px solid rgba(0,0,0,.14);
               border-radius:0 10px 10px 0;
               font-weight:400;
               font-size:12px;
               letter-spacing:.06em;
               background:linear-gradient(180deg,#ffffff,#f3f4f6);
               box-shadow:0 1px 0 rgba(0,0,0,.06);">
    [EN][en]
  </span>

</div>
<!-- ────────────────────────────────────────────────────────────────── -->

> ⚠️ Не используйте кнопку "Код → Скачать" на сайте GitFlic – этот метод не загружает файлы из Git LFS. [Инструкция по клонированию](../README_CLONE.md).

### Unity-плагин RuStore для приёма платежей через сторонние приложения

#### [🔗 Документация разработчика][10]

#### Установка плагина в свой проект

Поддерживаются версии Unity 6000+. Для установки выполните следующие действия.

1. Выполните клонирование репозитрия пакета **RuStore Core**. [Инструкция по клонированию](https://gitflic.ru/project/rustore/unity-rustore-core-sdk/README_CLONE.md).
1. Выполните клонирование репозитрия пакета **RuStore Billing**. [Инструкция по клонированию](../README_CLONE.md).
1. Импортируйте пакеты из папок `ru.rustore.core` и `ru.rustore.billing` в проект через **Package Manager** (**Window → Package Manager → __+__ → Add package from disk...**).
1. Обновите зависимости проекта с помощью [External Dependency Manager](../README_EDM.md) (**Assets → External Dependency Manager → Android Resolver → Force Resolve**).
1. Выполните шаги раздела [Настройка проекта](../README.md).

#### История изменений

[CHANGELOG](../CHANGELOG.md)

#### Условия распространения

Данное программное обеспечение, включая исходные коды, бинарные библиотеки и другие файлы, распространяется под лицензией MIT. Информация о лицензировании доступна в документе [MIT-LICENSE](../MIT-LICENSE.txt).

#### Техническая поддержка

Дополнительная помощь и инструкции доступны в [документации RuStore](https://www.rustore.ru/help/) и по электронной почте support@rustore.ru.

[10]: https://www.rustore.ru/help/sdk/payments/unity/10-5-0

[en]: README.en.md
