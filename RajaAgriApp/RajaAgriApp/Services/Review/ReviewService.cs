using RajaAgriApp.Common;
using RajaAgriApp.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RajaAgriApp.Services
{

    public class ReviewService : IReviewService
    {
        private readonly IApiHelper _apiHelper;
        private readonly string BaseApiURL = ServiceUrl.ProductRating;

        public ReviewService(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<ReviewResponseModel> PostSubmitProductRating(ReviewRequestModel reviewRequest)
        {
            ReviewResponseModel response = new ReviewResponseModel();
            try
            {
                HttpResponseMessage responseMessage = await _apiHelper.InvokePostAPI(BaseApiURL,reviewRequest);
                if (responseMessage.IsSuccessStatusCode)
                {
                    response = await ResponseContent<ReviewResponseModel>.ResponseContentAsync(responseMessage);
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
