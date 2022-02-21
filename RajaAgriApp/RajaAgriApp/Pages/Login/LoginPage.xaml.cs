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
            loginViewModel.LoginEvent += LoginViewModel_LoginEvent;
            this.BindingContext = loginViewModel;
        }

        private async void LoginViewModel_LoginEvent(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HomePage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            phoneNumberEntry.Focus();
            otpEntry.Focus();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (!loginViewModel.IsOTPVerify)
            {
                loginViewModel.GetOTP();
            }
            else
            {
                loginViewModel.VerifyOTP();
            }
        }
    }
}