using RajaAgriApp.Models;
using System.Threading.Tasks;

namespace RajaAgriApp.Controller
{
    public interface IFarmerRegisterController
    {
        Task<FarmerRegisterResponseModel> PostFarmerRegister(RegisterRequestModel registerRequestModel);
    }
}
