using RajaAgriApp.Common;
using RajaAgriApp.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RajaAgriApp.Services
{
    public class FarmerRegisterService : IFarmerRegisterService
    {
        private readonly IApiHelper _apiHelper;
        private readonly string BaseApiURL = ServiceUrl.FarmerRegister;

        public FarmerRegisterService(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<FarmerRegisterResponseModel> PostFarmerRegister(RegisterRequestModel registerRequestModel)
        {
            FarmerRegisterResponseModel response = new FarmerRegisterResponseModel();
            try
            {
                
                HttpResponseMessage responseMessage = await _apiHelper.InvokePostAPI(BaseApiURL, registerRequestModel);
                if (responseMessage.IsSuccessStatusCode)
                {
                    response = await ResponseContent<FarmerRegisterResponseModel>.ResponseContentAsync(responseMessage);
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

        public FormUrlEncodedContent SetFarmerRegisterParams(string phoneNumber)
        {

            var keyValues = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("PhoneNumber", phoneNumber),
            };

            return new FormUrlEncodedContent(keyValues);
        }
    }
}
