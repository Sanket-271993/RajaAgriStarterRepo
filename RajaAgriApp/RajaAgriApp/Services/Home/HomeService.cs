using RajaAgriApp.Common;
using RajaAgriApp.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RajaAgriApp.Services
{

    internal class HomeService: IHomeService
    {

        private readonly IApiHelper _apiHelper;
        private readonly string BaseApiURL = ServiceUrl.Home;

        public HomeService(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<ProductResponseModel> GetHome()
        {
            ProductResponseModel response = new ProductResponseModel();
            try
            {
                HttpResponseMessage responseMessage = await _apiHelper.InvokeGetAPI(BaseApiURL);
                if (responseMessage.IsSuccessStatusCode)
                {
                    response = await ResponseContent<ProductResponseModel>.ResponseContentAsync(responseMessage);
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
