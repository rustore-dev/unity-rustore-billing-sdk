package ru.rustore.unitysdk.billingclient.callbacks;

import java.util.List;
import ru.rustore.sdk.billingclient.model.product.Product;
public interface ProductsResponseListener {
    public void OnFailure(Throwable throwable);
    public void OnSuccess(List<Product> response);
}