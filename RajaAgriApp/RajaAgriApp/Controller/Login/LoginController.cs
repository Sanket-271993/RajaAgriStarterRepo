using RajaAgriApp.Models;
using RajaAgriApp.Models.CommonResponse;
using RajaAgriApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RajaAgriApp.Controller
{

    public class LoginController:ILoginController
    {
        private ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        public async Task<Response<LoginResponseModel>> GetLoginAsync(LoginRequestModel loginRequest)
        {
            var response = await _loginService.GetLogin(loginRequest);
            return response;
        }
    }
}
