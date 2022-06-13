using RajaAgriApp.Models;
using System.Threading.Tasks;

namespace RajaAgriApp.Services
{
    public interface IProductRegisterService
    {
        Task<ProductRegistrationResponseModel> PostProductRegistration(ProductRegistrationRequestModel requestModel);
    }
}
