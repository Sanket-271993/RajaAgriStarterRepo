using RajaAgriApp.Pages;
using System;
using Xamarin.Forms;

namespace RajaAgriApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MultiLanguage), typeof(MultiLanguage));
            Routing.RegisterRoute(nameof(RegistrationPage), typeof(RegistrationPage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
            Routing.RegisterRoute(nameof(SearchPage), typeof(SearchPage));
            Routing.RegisterRoute(nameof(ProductDetailsPage), typeof(ProductDetailsPage));
            Routing.RegisterRoute(nameof(ProfilePage), typeof(ProfilePage));
            Routing.RegisterRoute(nameof(DealerPage), typeof(DealerPage));
            Routing.RegisterRoute(nameof(ProductRegistrationPage), typeof(ProductRegistrationPage));
            Routing.RegisterRoute(nameof(NewServiceRequestPage), typeof(NewServiceRequestPage));
            Routing.RegisterRoute(nameof(ServiceRequestPage), typeof(ServiceRequestPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
