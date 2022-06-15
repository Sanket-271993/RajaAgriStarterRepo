using RajaAgriApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RajaAgriApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderHistoryPage : ContentPage
    {
        OrderHistoryViewModel _orderHistoryViewModel;
        public OrderHistoryPage()
        {
            InitializeComponent();
            _orderHistoryViewModel = new OrderHistoryViewModel();
            this.BindingContext = _orderHistoryViewModel;
        }

        protected override void OnAppearing()
        {

            _orderHistoryViewModel.SetOrderHistoryServiceCall();
            base.OnAppearing();


        }
    }
}