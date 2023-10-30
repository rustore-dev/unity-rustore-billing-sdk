using System.Collections.Generic;

namespace RuStore.BillingClient {

    public class PurchasesResponse : ResponseWithCode {

        public List<Purchase> purchases;
    }
}
