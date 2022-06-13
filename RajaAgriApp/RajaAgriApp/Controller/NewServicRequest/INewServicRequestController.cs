using RajaAgriApp.Models;
using System.Threading.Tasks;

namespace RajaAgriApp.Controller
{
    public interface INewServicRequestController
    {
        Task<ProductResponseModel> GetHome();
        Task<TypeOfProblemResponseModel> GetTypeOfProblem();
        Task<NewServiceRequestResponseModel> PostProductRegistration(NewServiceRequestModel requestModel);
    }
}
