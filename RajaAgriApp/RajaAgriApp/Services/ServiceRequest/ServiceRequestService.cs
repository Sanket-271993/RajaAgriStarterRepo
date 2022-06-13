﻿using RajaAgriApp.Common;
using RajaAgriApp.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace RajaAgriApp.Services
{
    public class ServiceRequestService : IServiceRequestService
    {
        private readonly IApiHelper _apiHelper;
        private readonly string BaseApiURL = ServiceUrl.RequestStatus;

        public ServiceRequestService(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<ServiceRequestResponseModel> GetServiceRequest()
        {
            ServiceRequestResponseModel response = new ServiceRequestResponseModel();
            try
            {
                HttpResponseMessage responseMessage = await _apiHelper.InvokeGetAPI(BaseApiURL);
                if (responseMessage.IsSuccessStatusCode)
                {
                    response = await ResponseContent<ServiceRequestResponseModel>.ResponseContentAsync(responseMessage);
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