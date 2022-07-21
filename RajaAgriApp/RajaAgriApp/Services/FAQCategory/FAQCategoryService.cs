using RajaAgriApp.Common;
using RajaAgriApp.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace RajaAgriApp.Services
{
    public class FAQCategoryService : IFAQCategoryService
    {

        private readonly IApiHelper _apiHelper;
        private readonly string BaseApiURL = ServiceUrl.FAQCategory;

        public FAQCategoryService(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<FAQCategoryResponseModel> GetFAQCategory()
        {
            FAQCategoryResponseModel response = new FAQCategoryResponseModel();
            try
            {
                
                HttpResponseMessage responseMessage = await _apiHelper.InvokeGetAPI(BaseApiURL);
                if (responseMessage.IsSuccessStatusCode)
                {
                    response = await ResponseContent<FAQCategoryResponseModel>.ResponseContentAsync(responseMessage);
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
