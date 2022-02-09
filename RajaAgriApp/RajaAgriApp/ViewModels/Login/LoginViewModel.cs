using RajaAgriApp.Pages;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace RajaAgriApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {

        private bool _isOTPVerify;

        public bool IsOTPVerify
        {
            get { return _isOTPVerify; }
            set { SetProperty(ref _isOTPVerify, value); }
        }

        public ICommand LoginCommand { get; set; }
        public ICommand GetOTPCommand { get; set; }
        public ICommand MultiLanguageCommand { get; set; }
        public LoginViewModel()
        {
            IsOTPVerify=false;
            InitCommand();
        }

        private void InitCommand()
        {
            LoginCommand = new Command(OnLoginClicked);
            GetOTPCommand = new Command(OnGetOTPClick);
            MultiLanguageCommand = new Command(OnMultiLanguageClick);
        }

        private void OnMultiLanguageClick(object obj)
        {
            //
        }

        private void OnGetOTPClick(object obj)
        {
            IsOTPVerify = true;
        }

        private async void OnLoginClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }
    }
}
