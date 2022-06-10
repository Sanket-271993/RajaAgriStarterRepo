using RajaAgriApp.AppDependencyService;
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
    public partial class HomePage : ContentPage
    {
        HomeViewModel _homeViewModel;
        public HomePage()
        {
            InitializeComponent();
            _homeViewModel=new HomeViewModel();
            this.BindingContext = _homeViewModel;
        }

        protected override void OnAppearing()
        {
            _homeViewModel.SetHomeServiceCall();
            base.OnAppearing();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (Shell.Current.FlyoutBehavior == FlyoutBehavior.Disabled)
            {
                Shell.Current.FlyoutIsPresented = true;
            }
            else
            {
                Shell.Current.FlyoutIsPresented = false;
            }
        }

        protected override bool OnBackButtonPressed()
        {
            DependencyService.Get<ICloseApplication>().CloseApp();
            return base.OnBackButtonPressed();
        }

    }
}