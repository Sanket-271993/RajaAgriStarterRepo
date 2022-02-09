using System.Net.Http;
using System.Threading.Tasks;

namespace RajaAgriApp.Common
{
    public interface IApiHelper
    {
        Task<HttpResponseMessage> InvokeGetAPI(string apiName);
        Task<HttpResponseMessage> InvokePutAPI<T>(string apiName, T body);
        Task<HttpResponseMessage> InvokePostAPI<T>(string apiName, T body);
        Task<HttpResponseMessage> InvokeDeleteAPI(string apiName);
        string GetAPIResponseStatusCodeMessage(HttpResponseMessage responseMessage);
    }
}
