package ru.rustore.unitysdk.core

import android.app.Activity
import com.unity3d.player.UnityPlayer

object PlayerProvider {

    private var externalProvider: IPlayerProvider? = null

    fun getCurrentActivity(): Activity
    {
        return externalProvider?.getCurrentActivity() ?: UnityPlayer.currentActivity
    }

    fun setExternalProvider(provider: IPlayerProvider) {
        externalProvider = provider
    }
}
