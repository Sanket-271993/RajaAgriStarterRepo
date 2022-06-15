using RajaAgriApp.Common;
using RajaAgriApp.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace RajaAgriApp.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IApiHelper _apiHelper;
        private readonly string BaseApiURL = ServiceUrl.Profile;

        public ProfileService(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<ProfileResponseModel> GetProfile()
        {
            ProfileResponseModel response = new ProfileResponseModel();
            try
            {
                HttpResponseMessage responseMessage = await _apiHelper.InvokeGetAPI(BaseApiURL);
                if (responseMessage.IsSuccessStatusCode)
                {
                    response = await ResponseContent<ProfileResponseModel>.ResponseContentAsync(responseMessage);
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
