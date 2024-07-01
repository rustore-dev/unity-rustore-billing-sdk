package ru.rustore.unitysdk.billingclient.callbacks;

import ru.rustore.sdk.billingclient.model.purchase.Purchase;
public interface PurchaseInfoResponseListener {

    public void OnFailure(Throwable throwable);
    public void OnSuccess(Purchase response);
}