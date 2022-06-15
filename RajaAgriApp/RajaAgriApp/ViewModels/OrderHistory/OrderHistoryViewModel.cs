using RajaAgriApp.Common;
using RajaAgriApp.Controller;
using RajaAgriApp.Models;
using RajaAgriApp.Resources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace RajaAgriApp.ViewModels
{
    public class OrderHistoryViewModel:BaseViewModel
    {
        private IOrderHistoryController _orderHistoryController;


        private ObservableCollection<HistoryOrderModel> _historyOrderModels;
        public ObservableCollection<HistoryOrderModel> OrderHistorys
        {
            get { return _historyOrderModels; }
            set { SetProperty(ref _historyOrderModels, value); }
        }
        public ICommand OnInvoiceDownloadCommand { get; set; }
        public OrderHistoryViewModel()
        {
            InitController();
            InitCommand();
            SetTitle();
        }

        private void SetTitle()
        {
            Title = AppResource.TitleDealers;
            IsMenuVisable = false;
            IsTranslateVisable = true;
        }
        private void InitCommand()
        {
            OnInvoiceDownloadCommand = new Command<HistoryOrderModel>(OnInvoiceDownloadClick);
           
        }

        private void OnInvoiceDownloadClick(HistoryOrderModel obj)
        {
            //
        }

        private void InitController()
        {
            _orderHistoryController=AppLocator.Instance.GetInstance<IOrderHistoryController>();
        }


       

        public async void SetOrderHistoryServiceCall()
        {
            try
            {
                if (IsConnected)
                {

                    AppIndicater.Instance.Show();
                    var response = await _orderHistoryController.GetOrderHistory();
                    AppIndicater.Instance.Dismiss();
                    if (response != null && response.Products?.Count > 0)
                    {
                        OrderHistorys = new ObservableCollection<HistoryOrderModel>(response.Products);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

    }
}
