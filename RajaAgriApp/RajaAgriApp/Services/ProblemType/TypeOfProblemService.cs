using RajaAgriApp.Common;
using RajaAgriApp.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace RajaAgriApp.Services
{
    public class TypeOfProblemService : ITypeOfProblemService
    {
        private readonly IApiHelper _apiHelper;
        private readonly string BaseApiURL = ServiceUrl.ProblemTypes;

        public TypeOfProblemService(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<TypeOfProblemResponseModel> GetTypeOfProblem()
        {
            TypeOfProblemResponseModel response = new TypeOfProblemResponseModel();
            try
            {
                HttpResponseMessage responseMessage = await _apiHelper.InvokeGetAPI(BaseApiURL);
                if (responseMessage.IsSuccessStatusCode)
                {
                    response = await ResponseContent<TypeOfProblemResponseModel>.ResponseContentAsync(responseMessage);
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
