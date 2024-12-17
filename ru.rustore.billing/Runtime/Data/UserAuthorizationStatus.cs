using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RuStore.BillingClient {

    public class UserAuthorizationStatus {

        public bool authorized { get; }

        public UserAuthorizationStatus(bool authorized) {
            this.authorized = authorized;
        }
    }
}
