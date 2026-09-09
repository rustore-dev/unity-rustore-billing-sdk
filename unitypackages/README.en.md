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

### Unity plugin for RuStore to accept payments through third-party applications

#### [🔗 Developer documentation][10]

#### Installing the plugin in your project

Unity versions 6000+ are supported. To install, follow these steps.

1. Download the package [`RuStoreUnityBillingSDK-x.y.z.unitypackage`][20] and import it into the project (**Assets → Import Package → Custom Package...**).
1. Open project settings: **Edit → Project Settings → Player → Android Settings**.
1. In the **Publishing Settings** section, enable **Custom Main Manifest**, **Custom Main Gradle Template**, and **Custom Gradle Properties Template** settings.
1. In the **Other Settings** section, configure the **package name**, **Minimum API Level** = **24**, **Target API Level** = **34**.
1. Update project dependencies: **Assets → External Dependency Manager → Android Resolver → Force Resolve**.

#### Change log

[CHANGELOG](../CHANGELOG.md)

#### Licensing terms

This software, including source codes, binary libraries, and other files, is distributed under the MIT license. Licensing information is available in the [MIT-LICENSE](../MIT-LICENSE.txt) document.

#### Technical support

Additional help and instructions are available in the [RuStore documentation](https://www.rustore.ru/help/en/) and by email at support@rustore.ru.

[10]: https://www.rustore.ru/help/en/sdk/payments/unity/10-5-0
[20]: https://gitflic.ru/project/rustore/unity-rustore-billing-sdk/blob/raw?file=unitypackages%2FRuStoreUnityBillingSDK-10.5.0.unitypackage&inline=false

[ru]: README.md
[en]: README.en.md
