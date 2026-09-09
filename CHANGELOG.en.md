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

## Changelog

### Master branch
- SDK Billing version 10.5.0.
- Added `link.xml` with `preserve="all"` to protect against Managed Code Stripping.
- Added ProGuard/R8 rules in `consumer-rules.pro` to protect JNI bridge from minification.

### Release 10.5.0
- SDK Billing version 10.5.0.

### Release 10.3.1
- SDK Billing version 10.3.1.

### Release 10.3.0
- SDK Billing version 10.3.0.

### Release 10.2.0
- SDK Billing version 10.2.0.
- The package is tested and supported on Unity 6000+.

### Release 10.1.0
- SDK Billing version 10.1.0.
- Removed deprecated field `AllowNativeErrorHandling` in the `RuStoreBillingClient` class.
- Removed deprecated field `allowNativeErrorHandling` in the `RuStoreBillingClientConfig` class.

### Release 10.0.1
- SDK Billing version 10.0.0.
- Updated `AndroidManifest.xml` formatting rules for correct deeplink handling.

### Release 10.0.0
- SDK Billing version 10.0.0.

### Release 9.1.0
- SDK Billing version 9.1.0.
- Fixed namespace declaration in RuStoreSDKSettings.androidlib Android manifest.

### Release 9.0.2
- SDK Billing version 9.0.2.

### Release 9.0.1
- SDK Billing version 9.0.1.

### Release 8.0.1
- SDK Billing version 8.0.0.
- Added method `GetAuthorizationStatus`.

### Release 8.0.0
- SDK Billing version 8.0.0.
- Method `CheckPurchasesAvailability` in the `RuStoreBillingClient` class is marked as deprecated.
- Method `CheckPurchasesAvailability` in the `onSuccess` event returns a `PurchaseAvailabilityResult` object.
- Field `AllowNativeErrorHandling` in the `RuStoreBillingClient` class is marked as deprecated.
- Field `allowNativeErrorHandling` in the `RuStoreBillingClientConfig` class is marked as deprecated.

### Release 7.0.0
- SDK Billing version 7.0.0.

### Release 6.1.1
- SDK Billing version 6.1.0.
- Fixed parsing of the `sandbox` field in `PaymentResult`.

### Release 6.1.0
- SDK Billing version 6.1.0.

### Release 6.0.0
- SDK Billing version 6.+.
- Added `sandbox` field to purchase result models `PaymentResult`.
- Removed `description` field from the `Purchase` model.
- Changed repository structure.
- Added project with source code of `.aar` packages.
- RuStoreSDK moved to a separate `assembly`.

### Release 5.0.3
- Fixed SDK dependencies.

### Release 5.0.2
- Fixed the `CheckPurchasesAvailability` method.

### Release 5.0.1
- Fixed the `CheckPurchasesAvailability` method.

### Release 5.0.0
- SDK Billing version 5.+.

### Release 3.1.0
- SDK Billing version 3.1.0.

### Release 2.2.1
- Fixed SDK dependencies.

### Release 2.2.0
- SDK Billing version 2.2.0.

[ru]: CHANGELOG.md
[en]: CHANGELOG.en.md
