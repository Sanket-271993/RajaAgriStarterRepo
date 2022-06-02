using RajaAgriApp.Common;
using RajaAgriApp.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RajaAgriApp.Services
{
    public class ProductDetailsService: IProductDetailsService
    {

        private readonly IApiHelper _apiHelper;
        private readonly string BaseApiURL = ServiceUrl.ProductDetail;

        public ProductDetailsService(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<ProductDetailsResponseModel> GetProductDetails(ProductDetailsRequestModel requestModel)
        {
            ProductDetailsResponseModel response = new ProductDetailsResponseModel();
            try
            {
                string ProductDetailsBaseURL = $"{BaseApiURL}?ProductId={requestModel.ProductId}&LanguageId={requestModel.LanguageId}";
                HttpResponseMessage responseMessage = await _apiHelper.InvokeGetAPI(ProductDetailsBaseURL);
                if (responseMessage.IsSuccessStatusCode)
                {
                    response = await ResponseContent<ProductDetailsResponseModel>.ResponseContentAsync(responseMessage);
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
