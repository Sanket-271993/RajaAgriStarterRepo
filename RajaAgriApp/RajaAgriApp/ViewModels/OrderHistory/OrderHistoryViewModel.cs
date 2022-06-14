using RajaAgriApp.Common;
using RajaAgriApp.Controller;
using System;
using System.Collections.Generic;
using System.Text;

namespace RajaAgriApp.ViewModels
{
    public class OrderHistoryViewModel:BaseViewModel
    {
        private IOrderHistoryController _orderHistoryController;

        public OrderHistoryViewModel()
        {
            InitController();
        }


        private void InitController()
        {
            _orderHistoryController=AppLocator.Instance.GetInstance<IOrderHistoryController>();
        }
    }
}
