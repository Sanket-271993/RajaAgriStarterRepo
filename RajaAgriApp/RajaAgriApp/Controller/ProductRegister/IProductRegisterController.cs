using RajaAgriApp.Models;
using System.Threading.Tasks;

namespace RajaAgriApp.Controller
{
    public interface IProductRegisterController
    {
        
        Task<ProductResponseModel> GetHome();
        Task<ProductTypeResponseModel> GetProductType();
        Task<DealerResponseModel> GetDealer();
        Task<ProductRegistrationResponseModel> PostProductRegistration(ProductRegistrationRequestModel requestModel);
    }
}
