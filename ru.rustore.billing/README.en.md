<!-- ── Language switch (EN active) ──────────────────────────────────── -->
<div align="left" style="margin:0 0 14px 0;">

  <span style="display:inline-block;
               padding:.28rem .6rem;
               border:1px solid rgba(0,0,0,.18);
               border-radius:10px 0 0 10px;
               font-weight:400;
               font-size:12px;
               letter-spacing:.06em;
               color:#111827;
               background:linear-gradient(180deg,#ffffff,#f3f4f6);
               box-shadow:0 1px 0 rgba(0,0,0,.06);">
    [RU][ru]
  </span><span style="display:inline-block;
               margin-left:-1px;
               padding:.28rem .6rem;
               border:1px solid rgba(0,0,0,.14);
               border-radius:0 10px 10px 0;
               font-weight:400;
               font-size:12px;
               letter-spacing:.06em;
               background:linear-gradient(180deg,#e9edf2,#ffffff);
               box-shadow:inset 0 2px 6px rgba(0,0,0,.10);">
    EN
  </span>

</div>
<!-- ────────────────────────────────────────────────────────────────── -->

> ⚠️ Do not use the "Code → Download" button on the GitFlic website – this method does not download files from Git LFS. [Cloning instructions](../README_CLONE.md).

### Unity plugin for RuStore to accept payments through third-party apps

#### [🔗 Developer documentation][10]

#### Installing the plugin in your project

Unity versions 6000+ are supported. To install, follow these steps.

1. Clone the **RuStore Core** package repository. [Cloning instructions](https://gitflic.ru/project/rustore/unity-rustore-core-sdk/README_CLONE.md).
1. Clone the **RuStore Billing** package repository. [Cloning instructions](../README_CLONE.md).
1. Import packages from `ru.rustore.core` and `ru.rustore.billing` folders into your project via **Package Manager** (**Window → Package Manager → __+__ → Add package from disk...**).
1. Update project dependencies using [External Dependency Manager](../README_EDM.md) (**Assets → External Dependency Manager → Android Resolver → Force Resolve**).
1. Follow the steps in the [Project Setup](../README.md) section.

#### Changelog

[CHANGELOG](../CHANGELOG.md)

#### Licensing Terms

This software, including source codes, binary libraries, and other files, is distributed under the MIT license. Licensing information is available in the [MIT-LICENSE](../MIT-LICENSE.txt) document.

#### Technical Support

Additional help and instructions are available in the [RuStore documentation](https://www.rustore.ru/help/en/) and by email at support@rustore.ru.

[10]: https://www.rustore.ru/help/en/sdk/payments/unity/10-5-0

[ru]: README.md
[en]: README.en.md
