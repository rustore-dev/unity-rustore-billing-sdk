### Unity-плагин RuStore для приёма платежей через сторонние приложения

Плагин **RuStoreBillingClient** помогает интегрировать в ваш проект механизм оплаты через сторонние приложения (например: SberPay или СБП).
Поддерживаются версии Unity 6000+.

#### Установка плагина в свой проект

- Скачайте файлы **ru.rustore.core-x.y.z.tgz** и **ru.rustore.billing-x.y.z.tgz** из <a href="https://gitflic.ru/project/rustore/unity-rustore-billing-sdk/file/?file=upm_tgz" target="_blank">официального репозитория на GitFlic</a>.
- Импортируйте скачанные пакеты в проект через **Package Manager** (Window → Package Manager → + → Add package from tarball…).
- Обновите зависимости проекта с помощью **External Dependency Manager** (Assets → External Dependency Manager → Android Resolver → Force Resolve).

#### Установка External Dependency Manager

**External Dependency Manager** для Android поставляется в составе пакета **RuStoreCore**. Для установки выполните следующие действия.

Откройте **RuStoreCore** в окне менеджера пакетов (Window → Package Manager → Packages RuStore → RuStoreCore).
Перейдите на вкладку **Sample**.
Импортируйте сэмпл **External Dependency Manager**.

#### Настройка проекта

Откройте настройки проекта: Edit → Project Settings → Player → Android Settings.

В pазделе **Publishing Settings** включите следующие настройки.
- Custom Main Manifest.
- Custom Main Gradle Template.
- Custom Gradle Properties Template.

В разделе **Other Settings** настройте:
- package name.
- Minimum API Level = 24.
- Target API Level = 34.

Откройте настройки **External Dependency Manager**: Assets → External Dependency Manager → Android Resolver → Settings, включите следующие настройки.
- Use Jetifier.
- Patch mainTemplate.gradle.
- Patch gradleTemplate.properties.

#### Обработка deeplink

Использование deeplink в RuStore SDK позволяет эффективно взаимодействовать со сторонними приложениями, например, при проведении платежей через банковские приложения (СБП, SberPay, T-Pay и др.). Это позволяет перевести пользователя на экран оплаты, а после завершения транзакции — вернуть в ваше приложение.

Deeplink в RuStore SDK платежей нужна для корректной работы со сторонними приложениями оплаты. Она помогает пользователям быстрее совершать покупки в стороннем приложении и возвращаться в ваше приложение.

Для настройки deeplink в вашем приложении выполните три основных шага:

**1. Создайте и настройте класс активити для обработки deeplink.**
1. Создайте файл `RuStoreIntentFilterActivity.java` и разместите его внутри папки `Assets` вашего проекта.
2. Реализуйте логику класса `RuStoreIntentFilterActivity`, используя приведённый ниже код.

Внимание! Имя класса должно совпадать с именем java-файла.

Приведённый пример реализации `RuStoreIntentFilterActivity`:
* Обрабатывает входящий `intent` с платежными данными.
* Передает управление основной активити (например, `UnityPlayerActivity`).

```java
package ru.rustore.unitysdk;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import com.unity3d.player.UnityPlayerActivity;
import ru.rustore.unitysdk.billingclient.RuStoreUnityBillingClient;

public class RuStoreIntentFilterActivity extends Activity {
    
    private final Class<?> UNITY_PLAYER_ACTIVITY_CLASS = UnityPlayerActivity.class;
	
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        
        if (savedInstanceState == null) {
            RuStoreUnityBillingClient.onNewIntent(getIntent());
        }
        
        if (!isTaskRoot()) {
            finish();
            return;
        }
        
        startGameActivity();
        finish();
    }
    
    @Override
    public void onNewIntent(Intent intent) {
        super.onNewIntent(intent);
        
        RuStoreUnityBillingClient.onNewIntent(intent);
    }
    
    private void startGameActivity() {
        Intent intent = new Intent(this, UNITY_PLAYER_ACTIVITY_CLASS);
        intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK | Intent.FLAG_ACTIVITY_CLEAR_TASK);
        startActivity(intent);
    }
}
```

**2. Обновите `AndroidManifest.xml`.**
1. Создайте deeplink-активити `ru.rustore.unitysdk.RuStoreIntentFilterActivity` с темой `Theme.NoDisplay`.
2. Перенесите запускающий `intent-filter` (`MAIN` и `LAUNCHER`) из игровой активити в deeplink-активити.
3. Создайте тег `intent-filter` внутри deeplink-активити с указанием вашей `Deeplink Scheme`.

```xml
<?xml version="1.0" encoding="utf-8"?>
<manifest xmlns:android="http://schemas.android.com/apk/res/android" package="rustore.unitysdk.sample" xmlns:tools="http://schemas.android.com/tools">
    <application>
        <!-- 1. Deeplink Activity -->
        <activity android:name="ru.rustore.unitysdk.RuStoreIntentFilterActivity"
                  android:theme="@android:style/Theme.NoDisplay"
                  android:exported="true">
				  
            <!-- 2. Starting intent-filter -->
            <intent-filter>
                <action android:name="android.intent.action.MAIN" />
                <category android:name="android.intent.category.LAUNCHER" />
            </intent-filter>
			
            <!-- 3. Deeplink intent-filter -->
            <intent-filter>
                <action android:name="android.intent.action.VIEW" />
                <category android:name="android.intent.category.DEFAULT" />
                <category android:name="android.intent.category.BROWSABLE" />
                <data android:scheme="yourappscheme" />
            </intent-filter>
        </activity>
        
        <!-- Game Activity -->
        <activity android:name="com.unity3d.player.UnityPlayerActivity" android:theme="@style/UnityThemeSelector" android:exported="true">
            <meta-data android:name="unityplayer.UnityActivity" android:value="true" />
        </activity>
    </application>
</manifest>
```

**3. Завершите настройку в методе инициализации SDK.**

В зависимости от выбранного способа [инициализации SDK](#initialization), выполните одну из следующих инструкций.

***1. Инициализация с параметрами задаваемыми через код.***

Если вы передаете параметры напрямую в коде, укажите `deeplinkPrefix` в конфигурации `RuStoreBillingClientConfig`:

```js
var config = new RuStoreBillingClientConfig() {
    consoleApplicationId = "123456",
    deeplinkPrefix = "yourappscheme", // Ваша схема deeplink
    allowNativeErrorHandling = true,
    enableLogs = true
};

RuStoreBillingClient.Instance.Init(config);
```

Важно! Значение схемы deeplink должно совпадать со значением, указанным в манифесте в теге `<data android:scheme="yourappscheme"/>`.

***2. Инициализация с параметрами задаваемыми через ресурсы.***

Если вы используете метод инициализации без параметров, настройте схему в редакторе Unity:

```js
RuStoreBillingClient.Instance.Init();
```

* В меню редактора Unity выберите пункт: **Window → RuStoreSDK → Settings → Billing Client**.
* В открывшемся инспекторе найдите поле `Deeplink Scheme` и укажите в нем схему (например, yourappscheme).
* Для согласованности настроек обновите манифест, чтобы он брал значение схемы из тех же ресурсов:

```xml
<!-- Было -->
<data android:scheme="yourappscheme" />

<!-- Стало -->
<data android:scheme="@string/rustore_BillingClientSettings_deeplinkScheme" />
```

#### Инициализация SDK

Перед вызовом методов библиотеки необходимо выполнить её инициализацию.

```csharp
var config =  new RuStoreBillingClientConfig() {
    consoleApplicationId =  "123456" ,
    deeplinkPrefix =  "yourappscheme" ,
    enableLogs =  true
};

RuStoreBillingClient.Instance.Init(config);
```

Начните изучение документации библиотеки RuStore с методов класса [RuStoreBillingClient](@ref RuStore.BillingClient.RuStoreBillingClient). Или воспользуйтесь <a href="https://www.rustore.ru/help/sdk/payments/unity" target="_blank">руководством онлайн</a>.

#### Техническая поддержка

Дополнительная помощь и инструкции доступны в <a href="https://www.rustore.ru/help" target="_blank">документации RuStore</a> и по электронной почте support@rustore.ru.

#### Условия распространения

Данное программное обеспечение, включая исходные коды, бинарные библиотеки и другие файлы, распространяется под лицензией MIT. Информация о лицензировании доступна в документе <a href="https://gitflic.ru/project/rustore/unity-rustore-billing-sdk/blob?file=MIT-LICENSE.txt" target="_blank">MIT-LICENSE</a>.
