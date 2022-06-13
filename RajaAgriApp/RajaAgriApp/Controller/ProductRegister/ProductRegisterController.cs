using RajaAgriApp.Models;
using RajaAgriApp.Services;
using System.Threading.Tasks;

namespace RajaAgriApp.Controller
{

    public class ProductRegisterController : IProductRegisterController
    {
        private IProductRegisterService _productRegisterService;
        private IProductTypeService _productTypeService;
        private IHomeService _homeService;
        private IDealerService _dealerService;
        public ProductRegisterController(IProductRegisterService productRegisterService,IProductTypeService productTypeService, IHomeService homeService, IDealerService dealerService)
        {
            _productRegisterService = productRegisterService;
            _productTypeService = productTypeService;
            _homeService= homeService;
            _dealerService=dealerService;
        }

        public async Task<DealerResponseModel> GetDealer()
        {
            var response = await _dealerService.GetDealer();
            return response;
        }

        public Task<ProductResponseModel> GetHome()
        {
            var response = _homeService.GetHome();
            return response;
        }

        public Task<ProductTypeResponseModel> GetProductType()
        {
            var response = _productTypeService.GetProductType();
            return response;
        }

        public Task<ProductRegistrationResponseModel> PostProductRegistration(ProductRegistrationRequestModel requestModel)
        {
            var response = _productRegisterService.PostProductRegistration(requestModel);
            return response;

        }
    }
}
