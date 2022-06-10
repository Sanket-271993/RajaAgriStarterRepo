using RajaAgriApp.Models;
using RajaAgriApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RajaAgriApp.Controller
{
    public class DealerController : IDealerController
    {
        private IDealerService _dealerService;
        public DealerController(IDealerService dealerService)
        {
            _dealerService = dealerService;
        }
        public async Task<DealerResponseModel> GetDealer()
        {
            var response =await _dealerService.GetDealer();
            return response;
        }
    }
}
