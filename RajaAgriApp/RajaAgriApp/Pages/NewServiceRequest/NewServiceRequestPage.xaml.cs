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
    public partial class NewServiceRequestPage : BaseView
    {
        NewServiceRequestViewModel newServiceRequestViewModel { get; set; }
        public NewServiceRequestPage()
        {
            InitializeComponent();
            newServiceRequestViewModel= new NewServiceRequestViewModel();
            this.BindingContext = newServiceRequestViewModel;
        }

        protected override void OnAppearing()
        {
            newServiceRequestViewModel.SetProductServiceCall();
            newServiceRequestViewModel.SetProblemTypeServiceCall();
            base.OnAppearing();

        }
    }
}