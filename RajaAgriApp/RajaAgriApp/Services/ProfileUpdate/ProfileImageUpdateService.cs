using RajaAgriApp.Common;
using RajaAgriApp.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace RajaAgriApp.Services
{
    public class ProfileImageUpdateService : IProfileImageUpdateService
    {
        private readonly IApiHelper _apiHelper;
        private readonly string BaseApiURL = ServiceUrl.UpdateFarmerImage;

        public ProfileImageUpdateService(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<ProfileImageResponseModel> PostProfileImageUpdate(ProfileImageRequstModel profileImageRequstModel)
        {
            ProfileImageResponseModel response = new ProfileImageResponseModel();
            try
            {
                HttpResponseMessage responseMessage = await _apiHelper.InvokePostAPI(BaseApiURL,profileImageRequstModel);
                if (responseMessage.IsSuccessStatusCode)
                {
                    response = await ResponseContent<ProfileImageResponseModel>.ResponseContentAsync(responseMessage);
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
