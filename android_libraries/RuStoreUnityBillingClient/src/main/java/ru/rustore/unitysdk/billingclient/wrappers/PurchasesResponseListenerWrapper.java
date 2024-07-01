package ru.rustore.unitysdk.billingclient.wrappers;

import java.util.List;
import ru.rustore.unitysdk.billingclient.callbacks.PurchasesResponseListener;
import ru.rustore.sdk.billingclient.model.purchase.Purchase;
import ru.rustore.unitysdk.core.IRuStoreListener;

public class PurchasesResponseListenerWrapper implements IRuStoreListener, PurchasesResponseListener
{
    private Object mutex = new Object();
    private long cppPointer = 0;

    private native void NativeOnFailure(long pointer, Throwable throwable);
    private native void NativeOnSuccess(long pointer, List<Purchase> response);

    public PurchasesResponseListenerWrapper(long cppPointer) {
        this.cppPointer = cppPointer;
    }

    @Override
    public void OnFailure(Throwable throwable) {
        synchronized (mutex) {
            if (cppPointer != 0) {
                NativeOnFailure(cppPointer, throwable);
            }
        }
    }

    @Override
    public void OnSuccess(List<Purchase> response) {
        synchronized (mutex) {
            if (cppPointer != 0) {
                NativeOnSuccess(cppPointer, response);
            }
        }
    }

    public void DisposeCppPointer() {
        synchronized (mutex) {
            cppPointer = 0;
        }
    }
}
