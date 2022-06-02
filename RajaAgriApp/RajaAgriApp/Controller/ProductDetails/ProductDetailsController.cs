using RajaAgriApp.Models;
using RajaAgriApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RajaAgriApp.Controller
{
    public class ProductDetailsController : IProductDetailsController
    {
        private IProductDetailsService _productDetailsService;

        public ProductDetailsController(IProductDetailsService productDetailsService)
        {
            _productDetailsService = productDetailsService;
        }

        public Task<ProductDetailsResponseModel> GetProductDetails(ProductDetailsRequestModel requestModel)
        {
            var response= _productDetailsService.GetProductDetails(requestModel);
            return response;
        }
    }
}
