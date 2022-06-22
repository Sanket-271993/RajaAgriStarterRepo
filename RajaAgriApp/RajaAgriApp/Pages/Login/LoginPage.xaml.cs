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
    public partial class LoginPage : ContentPage
    {
        LoginViewModel loginViewModel;
        public LoginPage()
        {
            InitializeComponent();
            loginViewModel= new LoginViewModel();
         
            this.BindingContext = loginViewModel;
        }

        
        protected override void OnAppearing()
        {
            base.OnAppearing();
            loginViewModel.SetdefultAsLogin();
            phoneNumberEntry.Focus();
            otpEntry.Focus();
        }


        protected override bool OnBackButtonPressed()
        {
            if(loginViewModel.IsOTPVerify)
            {
                loginViewModel.SetdefultAsLogin();
                return true;
            }
            else
            {
                DependencyService.Get<ICloseApplication>().CloseApp();
            }

            return base.OnBackButtonPressed();
        }
    }
}