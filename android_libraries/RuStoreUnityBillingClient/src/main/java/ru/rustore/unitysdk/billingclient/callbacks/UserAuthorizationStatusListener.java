package ru.rustore.unitysdk.billingclient.callbacks;

import ru.rustore.sdk.billingclient.model.user.UserAuthorizationStatus;

public interface UserAuthorizationStatusListener {

    public void OnFailure(Throwable throwable);
    public void OnSuccess(UserAuthorizationStatus response);
}
