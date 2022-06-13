using RajaAgriApp.Models;
using System.Threading.Tasks;

namespace RajaAgriApp.Controller
{
    public interface IServicRequestController
    {
        Task<ServiceRequestResponseModel> GetServiceRequest();
       
    }
}
