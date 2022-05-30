using RajaAgriApp.Models;
using RajaAgriApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RajaAgriApp.Controller
{

    public class FarmerRegisterController: IFarmerRegisterController
    {
        IFarmerRegisterService _farmerRegisterService;
        public FarmerRegisterController(IFarmerRegisterService farmerRegisterService)
        {
             _farmerRegisterService=farmerRegisterService;

        }

        public Task<FarmerRegisterResponseModel> PostFarmerRegister(RegisterRequestModel registerRequestModel)
        {
           var response = _farmerRegisterService.PostFarmerRegister(registerRequestModel);
            return response;
        }
    }
}
