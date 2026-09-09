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

#### Rebuilding the `.aar` library

If you need to modify the plugin library code, you can make changes and rebuild the `.aar` files.

1. Open the Android project in your IDE from the `android_libraries` folder.
1. Build the project using the command `gradle assemble`.

Upon successful completion of the build, the file `RuStoreUnityBillingClient.aar` will be updated in the `ru.rustore.billing/Runtime/Android` folder.

To rebuild `RuStoreUnityCore.aar`, follow the instructions in the [RuStore Core](https://gitflic.ru/project/rustore/unity-rustore-core-sdk) plugin repository.

#### Change log

[CHANGELOG](../CHANGELOG.md)

#### Licensing terms

This software, including source codes, binary libraries, and other files, is distributed under the MIT license. Licensing information is available in the [MIT-LICENSE](../MIT-LICENSE.txt) document.

#### Technical support

Additional help and instructions are available in the [RuStore documentation](https://www.rustore.ru/help/en/) and by email at support@rustore.ru.

[10]: https://www.rustore.ru/help/en/sdk/payments/unity/10-5-0

[ru]: README.md
[en]: README.en.md
