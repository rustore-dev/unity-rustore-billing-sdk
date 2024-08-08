package ru.rustore.unitysdk.billingclient

import ru.rustore.sdk.billingclient.presentation.BillingClientTheme
import ru.rustore.sdk.billingclient.provider.BillingClientThemeProvider

object RuStoreBillingClientThemeProviderImpl : BillingClientThemeProvider {

    @Volatile
    private var theme: BillingClientTheme = BillingClientTheme.Light

    fun setTheme(value: BillingClientTheme) {
        theme = value
    }

    fun getTheme(): BillingClientTheme = theme

    override fun provide(): BillingClientTheme = theme
}