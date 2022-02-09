using RajaAgriApp.Models.CommonResponse;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RajaAgriApp.Common
{
    public partial class ResponseContent<T>
    {
        public static async Task<Response<T>> ResponseContentAsync(HttpResponseMessage httpResponseMessage)
        {
            Response<T> responseconent;
            string apiResponseString = await httpResponseMessage.Content.ReadAsStringAsync();
            apiResponseString = JToken.Parse(apiResponseString).ToString();
            responseconent = Newtonsoft.Json.JsonConvert.DeserializeObject<Response<T>>(apiResponseString);

            return responseconent;
        }


    }
}
