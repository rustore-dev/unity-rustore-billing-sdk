package ru.rustore.unitysdk;

import android.os.Bundle;
import android.content.Intent;
import ru.rustore.unitysdk.billingclient.RuStoreUnityBillingClient;
import com.unity3d.player.UnityPlayerActivity;

public class RuStoreUnityActivity extends UnityPlayerActivity {

    @Override protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        
        if (savedInstanceState == null) {
            RuStoreUnityBillingClient.onNewIntent(getIntent());
        }
    }

    @Override protected void onNewIntent(Intent intent) {
        super.onNewIntent(intent);
        RuStoreUnityBillingClient.onNewIntent(intent);
    }
}
