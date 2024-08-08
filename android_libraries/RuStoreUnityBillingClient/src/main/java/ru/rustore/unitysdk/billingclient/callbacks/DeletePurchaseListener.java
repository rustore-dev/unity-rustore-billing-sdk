package ru.rustore.unitysdk.billingclient.callbacks;

public interface DeletePurchaseListener {

    public void OnFailure(Throwable throwable);
    public void OnSuccess();
}