using RajaAgriApp.Common;
using RajaAgriApp.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace RajaAgriApp.Services
{
    public class ProductRegisterService : IProductRegisterService
    {
        private readonly IApiHelper _apiHelper;
        private readonly string BaseApiURL = ServiceUrl.RegisterProduct;

        public ProductRegisterService(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<ProductRegistrationResponseModel> PostProductRegistration(ProductRegistrationRequestModel requestModel)
        {
            ProductRegistrationResponseModel response = new ProductRegistrationResponseModel();
            try
            {
                HttpResponseMessage responseMessage = await _apiHelper.InvokePostAPI(BaseApiURL, requestModel);
                if (responseMessage.IsSuccessStatusCode)
                {
                    response = await ResponseContent<ProductRegistrationResponseModel>.ResponseContentAsync(responseMessage);
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
