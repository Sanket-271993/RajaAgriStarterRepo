using RajaAgriApp.Common;
using RajaAgriApp.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RajaAgriApp.Services
{
    public class FAQService: IFAQService
    {

        private readonly IApiHelper _apiHelper;
        private readonly string BaseApiURL = ServiceUrl.FAQ;

        public FAQService(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<FAQResponseModel> GetFAQ(int FAQCategoryId)
        {
            FAQResponseModel response = new FAQResponseModel();
            try
            {
                string ProductDetailsBaseURL = $"{BaseApiURL}?FAQCategoryId={FAQCategoryId}";
                HttpResponseMessage responseMessage = await _apiHelper.InvokeGetAPI(ProductDetailsBaseURL);
                if (responseMessage.IsSuccessStatusCode)
                {
                    response = await ResponseContent<FAQResponseModel>.ResponseContentAsync(responseMessage);
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
