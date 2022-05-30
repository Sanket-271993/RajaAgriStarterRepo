using NavistarOCCApp.Common;
using RajaAgriApp.Common;
using RajaAgriApp.Models;
using RajaAgriApp.Models.CommonResponse;
using RajaAgriApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RajaAgriApp.Controller
{

    public class LoginController : ILoginController
    {
        private ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        public async Task<LoginResponseModel> GetLoginAsync(LoginRequestModel loginRequest)
        {
            LoginResponseModel response = await _loginService.GetLogin(loginRequest);
            SaveToken(response);
            return response;
        }

        private void SaveToken(LoginResponseModel loginResponse)
        {
            if (loginResponse != null && !string.IsNullOrEmpty(loginResponse.access_token))
            {
                StorageServiceProvider.Instance.Write(AppConstant.Access_Token, loginResponse.access_token, true);
            }
        }
    }
}
