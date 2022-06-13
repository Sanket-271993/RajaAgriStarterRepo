using RajaAgriApp.Common;
using RajaAgriApp.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RajaAgriApp.Services
{
    public class NewServiceRequestService : INewServiceRequestService
    {
        private readonly IApiHelper _apiHelper;
        private readonly string BaseApiURL = ServiceUrl.CreateNewServiceRequest;

        public NewServiceRequestService(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<NewServiceRequestResponseModel> PostProductRegistration(NewServiceRequestModel requestModel)
        {
            NewServiceRequestResponseModel response = new NewServiceRequestResponseModel();
            try
            {
                HttpResponseMessage responseMessage = await _apiHelper.InvokePostAPI(BaseApiURL, requestModel);
                if (responseMessage.IsSuccessStatusCode)
                {
                    response = await ResponseContent<NewServiceRequestResponseModel>.ResponseContentAsync(responseMessage);
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
