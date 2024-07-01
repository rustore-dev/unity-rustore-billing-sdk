package ru.rustore.unitysdk.billingclient.wrappers;

import ru.rustore.sdk.billingclient.model.purchase.Purchase;
import ru.rustore.unitysdk.core.IRuStoreListener;
import ru.rustore.unitysdk.billingclient.callbacks.PurchaseInfoResponseListener;

public class PurchaseInfoResponseListenerWrapper implements IRuStoreListener, PurchaseInfoResponseListener
{
    private Object mutex = new Object();
    private long cppPointer = 0;

    private native void NativeOnFailure(long pointer, Throwable throwable);
    private native void NativeOnSuccess(long pointer, Purchase response);

    public PurchaseInfoResponseListenerWrapper(long cppPointer) {
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
    public void OnSuccess(Purchase response) {
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
