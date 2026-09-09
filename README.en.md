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

### <span style="color:red;">BillingClient SDK is marked as deprecated</span>

The **BillingClient SDK** continues to work, but resolving issues affecting payment functionality may take more time. New features are no longer being added to the SDK. We recommend using the Pay SDK in new and existing projects. To migrate to the Pay SDK, follow the [migration guide](https://www.rustore.ru/help/en/sdk/pay/migration).

### Unity Plugin for RuStore for accepting payments through third-party applications

#### [🔗 Developer Documentation][10]

The **RuStoreBillingClient** plugin helps integrate a payment mechanism into your project.

The repository contains the **RuStoreBillingClient** and **RuStoreCore** plugins, as well as a demo application with usage examples and configurations. Unity 6000+ versions are supported.

#### Building the Demo Application

You can explore the demo application that showcases all SDK methods:
- [billing_example](https://gitflic.ru/project/rustore/unity-rustore-billing-sdk/file?file=billing_example) — a Unity 6000.0.66f2 demo project (can be automatically converted to newer Unity versions).

#### Installing the Plugin in Your Project

**Connecting the UPM package via Package Manager**:
   - **Add package from tarball...** — recommended installation method.
   
   1. Download the <code>ru.rustore.core-<em>version</em>.tgz</code> and <code>ru.rustore.billing-<em>version</em>.tgz</code> files from the [releases page][20].
   1. Import the downloaded packages into your project via **Package Manager** (**Window → Package Manager → __+__ → Add package from tarball...**).
   1. Follow the steps in the **Project Setup** section below.

   - **Add package from disk...** — for custom modifications, see [README](https://gitflic.ru/project/rustore/unity-rustore-billing-sdk/file/?file=ru.rustore.billing);

**Importing \*.unitypackage via Import Assets** — legacy installation method.

   1. Download the <code>RuStoreUnityBillingSDK-<em>version</em>.unitypackage</code> file from the [releases page][20].
   1. Import the downloaded package into your project: **Assets → Import Package → Custom Package...**.
   1. Follow the steps in the **Project Setup** section below.

#### Project Configuration

1. Open project settings: **Edit → Project Settings → Player → Android Settings**.
1. In the **Publishing Settings** section, enable:
   - Custom Main Manifest.
   - Custom Main Gradle Template.
   - Custom Gradle Properties Template.
1. In the **Other Settings** section, configure:
   - Package name.
   - Minimum API Level = 24.
   - Target API Level = 34.
1. Update project dependencies using [**External Dependency Manager**](README_EDM.en.md): **Assets → External Dependency Manager → Android Resolver → Force Resolve**.

#### Change Log

[CHANGELOG](CHANGELOG.en.md)

#### Licensing Terms

This software, including source code, binary libraries, and other files, is distributed under the MIT license. Licensing information is available in the [MIT-LICENSE](MIT-LICENSE.txt) document.

#### Technical Support

Additional help and instructions are available in the [RuStore documentation](https://www.rustore.ru/help/en/) and by email at support@rustore.ru.

[10]: https://www.rustore.ru/help/en/sdk/payments/unity/10-5-0
[20]: https://gitflic.ru/project/rustore/unity-rustore-billing-sdk/release

[ru]: README.md
