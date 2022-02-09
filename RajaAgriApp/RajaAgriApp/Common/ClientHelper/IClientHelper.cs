using System.Net.Http;

namespace RajaAgriApp.Common
{
    public interface IClientHelper
    {
        HttpClient GetClient();
    }
}
