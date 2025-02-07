package ru.rustore.unitysdk.billingclient.callbacks;

import ru.rustore.sdk.billingclient.model.purchase.PurchaseAvailabilityResult;

public interface PurchaseAvailabilityListener {

    public void OnFailure(Throwable throwable);
    public void OnSuccess(PurchaseAvailabilityResult response);
}
