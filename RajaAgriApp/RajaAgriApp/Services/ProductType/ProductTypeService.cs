using RajaAgriApp.Common;
using RajaAgriApp.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RajaAgriApp.Services
{

    public class ProductTypeService : IProductTypeService
    {
       
        private readonly IApiHelper _apiHelper;
        private readonly string BaseApiURL = ServiceUrl.ProductType;

        public ProductTypeService(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }



        public async Task<ProductTypeResponseModel> GetProductType()
        {
            ProductTypeResponseModel response = new ProductTypeResponseModel();
            try
            {
                HttpResponseMessage responseMessage = await _apiHelper.InvokeGetAPI(BaseApiURL);
                if (responseMessage.IsSuccessStatusCode)
                {
                    response = await ResponseContent<ProductTypeResponseModel>.ResponseContentAsync(responseMessage);
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
