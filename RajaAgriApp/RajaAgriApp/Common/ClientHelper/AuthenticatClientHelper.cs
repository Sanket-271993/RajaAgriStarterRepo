using NavistarOCCApp.Common;
using System.Net.Http;
using System.Net.Http.Headers;

namespace RajaAgriApp.Common
{
    public class AuthenticatClientHelper : IClientHelper
    {
        HttpClient _Client;
        private string _token;
        public AuthenticatClientHelper()
        {

        }

        private async void GetToken()
        {
            _token = await StorageServiceProvider.Instance.Read(AppConstant.Access_Token, true);
        }

        public HttpClient GetClient()
        {
            GetToken();
            ///Here set authenticate header
            var authValue = new AuthenticationHeaderValue("Bearer", _token);
            _Client = new HttpClient()
            {
                DefaultRequestHeaders = { Authorization = authValue }
            };
            return _Client;
        }
    }
}
