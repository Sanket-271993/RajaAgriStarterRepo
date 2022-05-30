using RajaAgriApp.Models;
using System.Threading.Tasks;

namespace RajaAgriApp.Services
{
    public interface IFarmerRegisterService
    {
        Task<FarmerRegisterResponseModel> PostFarmerRegister(RegisterRequestModel registerRequestModel);
    }
}
