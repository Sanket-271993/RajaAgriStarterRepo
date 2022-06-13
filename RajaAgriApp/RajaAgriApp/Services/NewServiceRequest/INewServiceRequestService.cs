using RajaAgriApp.Models;
using System.Threading.Tasks;

namespace RajaAgriApp.Services
{
    public interface INewServiceRequestService
    {
        Task<NewServiceRequestResponseModel> PostProductRegistration(NewServiceRequestModel requestModel);
    }
}
