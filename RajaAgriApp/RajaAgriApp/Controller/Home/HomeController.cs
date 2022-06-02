using RajaAgriApp.Models;
using RajaAgriApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RajaAgriApp.Controller
{
    public class HomeController : IHomeController
    {
        private readonly IHomeService _homeService;
        public HomeController(IHomeService homeService)
        {
            _homeService=homeService;
        }

        public Task<ProductResponseModel> GetHome()
        {
            var response= _homeService.GetHome();
            return response;
        }
    }
}
