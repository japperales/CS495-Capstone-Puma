using System.Net.Http;
using Flurl.Http.Configuration;

namespace CS495_Capstone_Puma.Temporary
{
    public class UntrustedCertClientFactory : DefaultHttpClientFactory
    {
        public override HttpMessageHandler CreateMessageHandler() {
            return new HttpClientHandler {
                ServerCertificateCustomValidationCallback = (a, b, c, d) => true
            };
        }
    }
}