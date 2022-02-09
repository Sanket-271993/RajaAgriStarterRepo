using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RajaAgriApp.Common
{


    public class ApiHelper: IApiHelper
    {
        private readonly IClientHelper _clientHelper;
        public ApiHelper(IClientHelper clientHelper)
        {
            this._clientHelper = clientHelper;
        }

        public async Task<HttpResponseMessage> InvokeGetAPI(string apiName)
        {
            using (var client = _clientHelper.GetClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(AppConstant.APP_JSON));
                client.DefaultRequestHeaders.Add("Connection", "close");
                return await client.GetAsync(apiName);
            }
        }

        public async Task<HttpResponseMessage> InvokePutAPI<T>(string apiName, T body)
        {
            using (var client = _clientHelper.GetClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, AppConstant.APP_JSON);
                return await client.PutAsync(apiName, content);
            }
        }

        public async Task<HttpResponseMessage> InvokePostAPI<T>(string apiName, T body)
        {
            using (var client = _clientHelper.GetClient())
            {
                string steData = JsonConvert.SerializeObject(body);
                var content = new StringContent(steData, Encoding.UTF8, AppConstant.APP_JSON);
                return await client.PostAsync(apiName, content);
            }
        }

        public async Task<HttpResponseMessage> InvokeDeleteAPI(string apiName)
        {
            using (var client = _clientHelper.GetClient())
            {
                return await client.DeleteAsync(apiName);
            }
        }

        public async Task<HttpResponseMessage> GetOAuthAccessToken(string apiName, FormUrlEncodedContent body)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                var response = await client.PostAsync(apiName, body);
                return response;
            }
        }

        public async Task<HttpResponseMessage> GetOAuthAccessLoginToken(string apiName, FormUrlEncodedContent body)
        {
            using (var client = _clientHelper.GetClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                var response = await client.PostAsync(apiName, body);
                return response;
            }
        }

        public string GetAPIResponseStatusCodeMessage(HttpResponseMessage responseMessage)
        {
            string message;
            if (responseMessage != null && responseMessage.StatusCode == HttpStatusCode.ServiceUnavailable
                || responseMessage.StatusCode == HttpStatusCode.InternalServerError
                || responseMessage.StatusCode == HttpStatusCode.Unauthorized)
            {
                message = AppConstant.MSG_SERVICE_UNAVAILABLE;
            }
            else
            {
                message = AppConstant.DEFUAULT_SERVICES_MESSAGE;
            }
            return message;
        }
    }
}
