using NavistarOCCApp.Common;
using RajaAgriApp.Common;
using RajaAgriApp.Models;
using RajaAgriApp.Pages;
using RajaAgriApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using XF.Material.Forms.UI.Dialogs;
using XF.Material.Forms.UI.Dialogs.Configurations;

namespace RajaAgriApp.ViewModels
{
    public class BaseViewModel : BaseNotifyPropertyChanged
    {
        private bool _isConnected;
        public bool IsConnected
        {
            get
            {
                CheckInternetConnection();
                if (!_isConnected)
                {
                    SetSnackBarMessage("Your device not connect with Internet!");
                }
                return _isConnected;
            }
            set { SetProperty(ref _isConnected, value); }
        }

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }
        public static bool IsLoginNavigation = true;

        bool _isMenuVisable = false;
        public bool IsMenuVisable
        {
            get { return _isMenuVisable; }
            set { SetProperty(ref _isMenuVisable, value); }
        }

        bool _isTranslateVisable = true;
        public bool IsTranslateVisable
        {
            get { return _isTranslateVisable; }
            set { SetProperty(ref _isTranslateVisable, value); }
        }

        private string _mobileNumber;
        public string MobileNumber
        {
            get {
                GetMobileNumber();
                return _mobileNumber; 
            }
            set { SetProperty(ref _mobileNumber, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        private int _languageID ;
        public int LanguageID
        {
            get { return _languageID; }
            set { SetProperty(ref _languageID, value); }
        }

        public ICommand MultiLanguageCommand { get; set; }

        public BaseViewModel()
        {
            InitCommand();
            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged; ;
        }



        private void InitCommand()
        {

            MultiLanguageCommand = new Command(OnMultiLanguageClick);
        }

        private async void OnMultiLanguageClick(object obj)
        {
            await ShellRoutingService.Instance.NavigateTo($"{nameof(MultiLanguage)}");
        }


        private void CheckInternetConnection()
        {
            var current = Connectivity.NetworkAccess;

            switch (current)
            {
                case NetworkAccess.Internet:
                    // Connected to internet
                    IsConnected = true;
                    break;
                case NetworkAccess.Local:
                    // Only local network access
                    break;
                case NetworkAccess.ConstrainedInternet:
                    IsConnected = true;
                    // Connected, but limited internet access such as behind a network login page
                    break;
                case NetworkAccess.None:
                    IsConnected = false;
                    // No internet available
                    break;
                case NetworkAccess.Unknown:
                    IsConnected = false;
                    // Internet access is unknown
                    break;
            }

        }

        private void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            CheckInternetConnection();
            string message = IsConnected ? "You are back to online!" : "Your device not connect with Internet";
            SetSnackBarMessage(message);
        }



        public async void SetSnackBarMessage(string Message)
        {
            await MaterialDialog.Instance.SnackbarAsync(message: Message,
                                           msDuration: MaterialSnackbar.DurationLong);
        }

       
        private async void GetMobileNumber()
        {
            var number = await StorageServiceProvider.Instance.Read(AppConstant.FarmerMobileNumber, true);
            MobileNumber = number;
        }

        public async void SetAlertPopup(string Message)
        {
            MaterialAlertDialogConfiguration configuration = new MaterialAlertDialogConfiguration()
            {
                TintColor = Color.LightGreen
            };
            await MaterialDialog.Instance.AlertAsync(message: Message, configuration);

        }
    }



}
