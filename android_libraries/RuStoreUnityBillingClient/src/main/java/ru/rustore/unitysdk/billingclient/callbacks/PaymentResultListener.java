package ru.rustore.unitysdk.billingclient.callbacks;

import ru.rustore.sdk.billingclient.model.purchase.PaymentResult;

public interface PaymentResultListener {

    public void OnFailure(Throwable throwable);
    public void OnSuccess(PaymentResult response);
}