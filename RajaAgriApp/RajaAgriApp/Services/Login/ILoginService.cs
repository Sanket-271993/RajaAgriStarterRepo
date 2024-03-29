﻿using RajaAgriApp.Models;
using RajaAgriApp.Models.CommonResponse;
using System.Threading.Tasks;

namespace RajaAgriApp.Services
{
    public interface ILoginService
    {
        Task<Response<LoginResponseModel>> GetLogin(LoginRequestModel loginRequest);
    }
}
