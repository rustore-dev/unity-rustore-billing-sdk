package ru.rustore.unitysdk.billingclient.callbacks;

import java.util.List;
import ru.rustore.sdk.billingclient.model.purchase.Purchase;
public interface PurchasesResponseListener {

    public void OnFailure(Throwable throwable);
    public void OnSuccess(List<Purchase> response);
}