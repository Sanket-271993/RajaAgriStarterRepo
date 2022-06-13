using RajaAgriApp.Models;
using RajaAgriApp.Services;
using System.Threading.Tasks;

namespace RajaAgriApp.Controller
{
    public class ServicRequestController : IServicRequestController
    {
        private readonly IServiceRequestService _serviceRequestService;
        
        public ServicRequestController(IServiceRequestService serviceRequestService)
        {
            _serviceRequestService = serviceRequestService;
        }

        public Task<ServiceRequestResponseModel> GetServiceRequest()
        {
            var response = _serviceRequestService.GetServiceRequest();
            return response;
        }

       
    }
}
