using RajaAgriApp.Models;
using RajaAgriApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RajaAgriApp.Controller
{
    public class NewServicRequestController: INewServicRequestController
    {
        private readonly IHomeService _homeService;
        private readonly INewServiceRequestService _newServiceRequestService;
        private readonly ITypeOfProblemService _typeOfProblemService;
        public NewServicRequestController(IHomeService homeService, INewServiceRequestService newServiceRequestService, ITypeOfProblemService typeOfProblemService)
        {
            _homeService = homeService;
            _newServiceRequestService = newServiceRequestService;
            _typeOfProblemService= typeOfProblemService;
        }

        public Task<ProductResponseModel> GetHome()
        {
            var response = _homeService.GetHome();
            return response;
        }

        public Task<TypeOfProblemResponseModel> GetTypeOfProblem()
        {
            var response = _typeOfProblemService.GetTypeOfProblem();
            return response;
        }

        public Task<NewServiceRequestResponseModel> PostProductRegistration(NewServiceRequestModel requestModel)
        {
            var response = _newServiceRequestService.PostProductRegistration(requestModel);
            return response;
        }
    }
}
