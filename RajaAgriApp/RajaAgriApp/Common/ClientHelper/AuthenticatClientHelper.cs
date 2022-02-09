using System.Net.Http;
using System.Net.Http.Headers;

namespace RajaAgriApp.Common
{
    public class AuthenticatClientHelper : IClientHelper
    {
        HttpClient _Client;
        public AuthenticatClientHelper()
        {

        }
      

        public HttpClient GetClient()
        {
            ///Here set authenticate header
            _Client = new HttpClient();
            _Client.DefaultRequestHeaders.Add("Subscriptionkey", "TestSubscriptionKey0001");
            return _Client;
        }
    }
}
