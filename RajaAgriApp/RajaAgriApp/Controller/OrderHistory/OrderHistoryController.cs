using RajaAgriApp.Models;
using RajaAgriApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RajaAgriApp.Controller
{
    public class OrderHistoryController : IOrderHistoryController
    {
        private IOrderHistoryService _orderHistoryService;
        public OrderHistoryController(IOrderHistoryService orderHistoryService)
        {
            _orderHistoryService=orderHistoryService;
        }

        public Task<OrderHistoryResponseModel> GetOrderHistory()
        {
            var response = _orderHistoryService.GetOrderHistory();
            return response;
        }
    }
}
