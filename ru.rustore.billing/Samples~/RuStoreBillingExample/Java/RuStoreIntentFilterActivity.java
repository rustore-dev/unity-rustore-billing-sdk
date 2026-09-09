package ru.rustore.unitysdk;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import com.unity3d.player.UnityPlayerActivity;
import ru.rustore.unitysdk.billingclient.RuStoreUnityBillingClient;

public class RuStoreIntentFilterActivity extends Activity {
    
    private final Class<?> UNITY_PLAYER_ACTIVITY_CLASS = UnityPlayerActivity.class;
	
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        
        if (savedInstanceState == null) {
            RuStoreUnityBillingClient.onNewIntent(getIntent());
        }
        
        if (!isTaskRoot()) {
            finish();
            return;
        }
        
        startGameActivity();
        finish();
    }
    
    @Override
    public void onNewIntent(Intent intent) {
        super.onNewIntent(intent);
        
        RuStoreUnityBillingClient.onNewIntent(intent);
    }
    
    private void startGameActivity() {
        Intent intent = new Intent(this, UNITY_PLAYER_ACTIVITY_CLASS);
        intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK | Intent.FLAG_ACTIVITY_CLEAR_TASK);
        startActivity(intent);
    }
}
