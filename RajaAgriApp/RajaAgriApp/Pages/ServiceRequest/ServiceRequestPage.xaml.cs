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
    public partial class ServiceRequestPage : BaseView
    {
        ServiceRequestViewModel serviceRequestViewModel;
        public ServiceRequestPage()
        {
            InitializeComponent();

            serviceRequestViewModel= new ServiceRequestViewModel();
            this.BindingContext = serviceRequestViewModel;
        }

        protected override void OnAppearing()
        {
            serviceRequestViewModel.GetServicRequestServiceCall();
            base.OnAppearing();
        }
    }
}