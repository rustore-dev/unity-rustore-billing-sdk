package ru.rustore.unitysdk.billingclient.callbacks;

import ru.rustore.sdk.billingclient.model.user.UserAuthorizationStatus;

public interface AuthorizationStatusListener {
    void OnSuccess(UserAuthorizationStatus status);
    void OnFailure(Throwable throwable);
}
