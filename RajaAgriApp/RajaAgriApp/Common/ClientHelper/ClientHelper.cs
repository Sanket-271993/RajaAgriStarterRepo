using System.Net.Http;
using System.Net.Http.Headers;

namespace RajaAgriApp.Common
{
    public class ClientHelper : IClientHelper
    {
        HttpClient _Client;
        public ClientHelper()
        {
                
        }
        public HttpClient GetAuthenticateClient()
        {
            ///Here set authenticate header
            var authValue = new AuthenticationHeaderValue("Bearer", "Access_token");
            _Client = new HttpClient()
            {
                DefaultRequestHeaders = { Authorization = authValue }
            };
            return _Client;
        }

        public HttpClient GetClient()
        {
           return new HttpClient();
        }
    }
}
