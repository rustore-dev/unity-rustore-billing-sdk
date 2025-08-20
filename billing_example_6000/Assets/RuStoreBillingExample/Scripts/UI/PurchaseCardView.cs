using System;
using UnityEngine;
using UnityEngine.UI;
using RuStore.BillingClient;

namespace RuStore.BillingExample.UI {

    public class PurchaseCardView : MonoBehaviour, ICardView<Purchase> {

        [SerializeField]
        private Text purchaseId;

        [SerializeField]
        private Text invoiceId;

        [SerializeField]
        private Text productId;

        [SerializeField]
        private Text orderId;

        [SerializeField]
        private Text amount;

        [SerializeField]
        private Text time;

        [SerializeField]
        private Text state;

        public static event EventHandler OnConfirmPurchase;
        public static event EventHandler OnDeletePurchase;
        public static event EventHandler OnGetPurchaseInfo;

        private Purchase purchase = null;

        public void SetData(Purchase purchase) {
            this.purchase = purchase;

            if (purchaseId != null) purchaseId.text = purchase.purchaseId;
            if (invoiceId != null) invoiceId.text = purchase.invoiceId;
            if (productId != null) productId.text = purchase.productId;
            if (orderId != null) orderId.text = purchase.orderId;
            if (amount != null) amount.text = purchase.amountLabel;
            if (time != null) time.text = purchase.purchaseTime.ToString();
            if (state != null) state.text = purchase.purchaseState.ToString();
        }

        public Purchase GetData() {
            return purchase;
        }

        public void ConfirmPurchase() {
            OnConfirmPurchase?.Invoke(this, EventArgs.Empty);
        }

        public void DeletePurchase() {
            OnDeletePurchase?.Invoke(this, EventArgs.Empty);
        }

        public void GetPurchaseInfo() {
            OnGetPurchaseInfo?.Invoke(this, EventArgs.Empty);
        }
    }
}
