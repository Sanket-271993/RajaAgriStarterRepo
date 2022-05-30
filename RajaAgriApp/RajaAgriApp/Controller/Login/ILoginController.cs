using RajaAgriApp.Models;
using RajaAgriApp.Models.CommonResponse;
using System.Threading.Tasks;

namespace RajaAgriApp.Controller
{
    public interface ILoginController
    {
        Task<LoginResponseModel> GetLoginAsync(LoginRequestModel loginRequest);
    }
}
