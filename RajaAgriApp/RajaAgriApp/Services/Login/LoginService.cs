using RajaAgriApp.Common;
using RajaAgriApp.Models;
using RajaAgriApp.Models.CommonResponse;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RajaAgriApp.Services
{

    public class LoginService : ILoginService
    {
        private readonly IApiHelper _apiHelper;
        private readonly string BaseApiURL = ServiceUrl.Token;

        public LoginService(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<LoginResponseModel> GetLogin(LoginRequestModel loginRequest)
        {
            LoginResponseModel response = new LoginResponseModel();
            try
            {
                var loginRequestParm = SetLoginParams(loginRequest.MobileNo);
                HttpResponseMessage responseMessage = await _apiHelper.GetOAuthAccessToken(BaseApiURL, loginRequestParm);
                if (responseMessage.IsSuccessStatusCode)
                {
                    response = await ResponseContent<LoginResponseModel>.ResponseContentAsync(responseMessage);
                }
                else
                {
                    response.Message = ApiStatusMessage.CheckStatusCode(responseMessage);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return response;
        }

        public FormUrlEncodedContent SetLoginParams(string userName)
        {

            var keyValues = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("UserName", userName),
                new KeyValuePair<string, string>("grant_type", "password"),
            };

            return new FormUrlEncodedContent(keyValues);
        }
    }
}
