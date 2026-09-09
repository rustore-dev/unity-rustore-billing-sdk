using System.Text.RegularExpressions;

namespace RuStore.BillingExample.Internal {

    public class JsonLinkExtractor {

        public static string AddLinksToJson(string json) {
            Regex urlRegex = new Regex(@"(https?://[^\s""']+)", RegexOptions.IgnoreCase);

            string result = urlRegex.Replace(json, match => {
                string url = match.Value;
                url = url.TrimEnd('"', ',', ' ');
                return $"<a href=\"{url}\">{url}</a>";
            });

            return result;
        }
    }
}
