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

1. Скачайте пакет [`RuStoreUnityBillingSDK-x.y.z.unitypackage`][20] и импортируйте в проект (**Assets → Import Package → Custom Package...**).
1. Откройте настройки проекта: **Edit → Project Settings → Player → Android Settings**.
1. В pазделе **Publishing Settings** включите настройки **Custom Main Manifest**, **Custom Main Gradle Template**, **Custom Gradle Properties Template**.
1. В разделе **Other Settings** настройте **package name**, **Minimum API Level** = **24**, **Target API Level** = **34**.
1. Обновите зависимости проекта: **Assets → External Dependency Manager → Android Resolver → Force Resolve**.

#### История изменений

[CHANGELOG](../CHANGELOG.md)

#### Условия распространения

Данное программное обеспечение, включая исходные коды, бинарные библиотеки и другие файлы, распространяется под лицензией MIT. Информация о лицензировании доступна в документе [MIT-LICENSE](../MIT-LICENSE.txt).

#### Техническая поддержка

Дополнительная помощь и инструкции доступны в [документации RuStore](https://www.rustore.ru/help/) и по электронной почте support@rustore.ru.

[10]: https://www.rustore.ru/help/sdk/payments/unity/10-5-0
[20]: https://gitflic.ru/project/rustore/unity-rustore-billing-sdk/blob/raw?file=unitypackages%2FRuStoreUnityBillingSDK-10.5.0.unitypackage&inline=false

[en]: README.en.md
