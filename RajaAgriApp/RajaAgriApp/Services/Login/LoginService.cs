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
        private readonly string BaseApiURL = ServiceUrl.Login;

        public LoginService(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<Response<LoginResponseModel>> GetLogin(LoginRequestModel loginRequest)
        {
            Response<LoginResponseModel> response = new Response<LoginResponseModel>();
            try
            {
                HttpResponseMessage responseMessage = await _apiHelper.InvokePostAPI(BaseApiURL, loginRequest);
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
    }
}
