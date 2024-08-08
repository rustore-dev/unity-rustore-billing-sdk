package ru.rustore.unitysdk.billingclient;

import ru.rustore.sdk.billingclient.RuStoreBillingClient;
import ru.rustore.sdk.billingclient.model.product.ProductsResponse;
import ru.rustore.sdk.billingclient.model.purchase.response.PurchasesResponse;
import ru.rustore.sdk.billingclient.model.purchase.response.ConfirmPurchaseResponse;
import ru.rustore.sdk.billingclient.model.purchase.response.DeletePurchaseResponse;
import ru.rustore.sdk.billingclient.model.purchase.PaymentResult;
import ru.rustore.sdk.core.exception.*;

public interface RuStoreUnityBillingClientListener {

	public void OnProductsResponse(ProductsResponse products);
	public void OnPurchasesResponse(PurchasesResponse purchases);
	public void OnException(String type, String message);
	public void OnPurchaseResult(PaymentResult result);
	public void OnConfirmPurchaseResponse(ConfirmPurchaseResponse response);
	public void OnDeletePurchaseResponse(DeletePurchaseResponse response);
}