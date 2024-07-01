package ru.rustore.unitysdk.billingclient.wrappers;

import ru.rustore.sdk.billingclient.presentation.BillingClientTheme;
import ru.rustore.sdk.billingclient.provider.BillingClientThemeProvider;
import ru.rustore.unitysdk.billingclient.model.RuStoreThemeEnum;
import ru.rustore.unitysdk.core.IRuStoreListener;

public class BillingClientThemeProviderWrapper implements IRuStoreListener, BillingClientThemeProvider
{
    private Object mutex = new Object();
    private long cppPointer = 0;

    private RuStoreThemeEnum theme = RuStoreThemeEnum.LIGHT;

    public BillingClientThemeProviderWrapper(long cppPointer) {
        this.cppPointer = cppPointer;
    }

    public void SetTheme(RuStoreThemeEnum value) {
        theme = value;
    }

    @Override
    public BillingClientTheme provide() {
        switch (theme) {
            case DARK:
                return BillingClientTheme.Dark;
            default:
                return BillingClientTheme.Light;
        }
    }

    public void DisposeCppPointer() {
        synchronized (mutex) {
            cppPointer = 0;
        }
    }
}
