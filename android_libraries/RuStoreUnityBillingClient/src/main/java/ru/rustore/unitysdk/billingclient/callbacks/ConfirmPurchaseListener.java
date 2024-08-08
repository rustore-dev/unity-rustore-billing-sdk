package ru.rustore.unitysdk.billingclient.callbacks;

public interface ConfirmPurchaseListener {

    public void OnFailure(Throwable throwable);
    public void OnSuccess();
}