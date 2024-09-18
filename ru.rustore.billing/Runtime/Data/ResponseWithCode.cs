using System.Collections.Generic;

namespace RuStore.BillingClient {

    public class ResponseWithCode {

        public int code;
        public string errorMessage;
        public string errorDescription;
        public RequestMeta meta;

        public List<DigitalShopGeneralError> errors;
    }
}
