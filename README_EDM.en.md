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

> ⚠️ Do not use the "Code → Download" button on the GitFlic website – this method does not download files from Git LFS. [Cloning instructions](README_CLONE.en.md).

### Unity plugin for RuStore to accept payments through third-party apps

#### [🔗 Developer documentation][10]

#### Installing External Dependency Manager

**External Dependency Manager** for Android is included in the packages <code>ru.rustore.core-<em>version</em>.tgz</code> and <code>RuStoreUnityBillingSDK-<em>version</em>.unitypackage</code>.

When installing RuStore plugins via `*.unitypackage`, **External Dependency Manager** does not require special installation. You can proceed directly to the **Setting up External Dependency Manager** section below.

To install from <code>ru.rustore.core-<em>version</em>.tgz</code>, perform the following steps:

1. Open **RuStore Core** in the package manager window: **Window → Package Manager → Packages RuStore → RuStore Core**.
1. Go to the **Sample** tab.
1. Import the **External Dependency Manager** sample.
1. Follow the steps in the **Setting up External Dependency Manager** section below.

You can also install the latest version of **External Dependency Manager** from the official repository on [GitHub](https://github.com/googlesamples/unity-jar-resolver.git?path=/upm).

#### Setting up External Dependency Manager

Open **External Dependency Manager** settings: **Assets → External Dependency Manager → Android Resolver → Settings**, and enable the following options:
   - Use Jetifier.
   - Patch mainTemplate.gradle.
   - Patch gradleTemplate.properties.

#### Change Log

[CHANGELOG](CHANGELOG.en.md)

#### Licensing Terms

This software, including source codes, binary libraries, and other files, is distributed under the MIT license. Licensing information is available in the [MIT-LICENSE](MIT-LICENSE.txt) document.

#### Technical Support

Additional help and instructions are available in the [RuStore documentation](https://www.rustore.ru/help/en/) or by email at support@rustore.ru.

[10]: https://www.rustore.ru/help/en/sdk/payments/unity/10-5-0

[ru]: README_EDM.md
[en]: README_EDM.en.md
