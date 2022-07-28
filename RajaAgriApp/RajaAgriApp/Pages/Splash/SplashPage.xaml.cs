using NavistarOCCApp.Common;
using RajaAgriApp.AppDependencyService;
using RajaAgriApp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Xamarin.Essentials.Permissions;

namespace RajaAgriApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SplashPage : ContentPage
    {
        public SplashPage()
        {
            InitializeComponent();
            DependencyService.Get<IStatusBarColor>().HideStatusBar();
            


            Device.BeginInvokeOnMainThread(()=>NavigateToShell());
           
           
        }

        private async void NavigateToShell()
        {
            await Task.Delay(2000);
            CheckUserIsRegister();
            DependencyService.Get<IStatusBarColor>().ShowStatusBar();
        }


        private  void CheckUserIsRegister()
        {
            AskPermission();
            if (VersionTracking.IsFirstLaunchEver)
            {
                GoToMultiLanguage();
            }
            else
            {
                GoToHomePage();
            }
        }

        private async void GoToHomePage()
        {
            await ShellRoutingService.Instance.NavigateTo($"{nameof(HomePage)}");
        }
        private async void GoToMultiLanguage()
        {
            await ShellRoutingService.Instance.NavigateTo($"{nameof(MultiLanguage)}");
        }
  

         private async void AskPermission()
        {
            //await GetLocationAsync();
            await GetNetworkAsync();
          
        }
        private bool IsPermission;
        public async Task GetNetworkAsync()
        {
            var status = await CheckAndRequestPermissionAsync(new Permissions.NetworkState());
            if (status == PermissionStatus.Granted)
            {
                IsPermission = true;
               await GetReadAsync();
                
            }
            else
            {
                IsPermission = false;
                AppInfo.ShowSettingsUI();
            }

            //var location = await Geolocation.GetLocationAsync();
        }

        public async Task GetReadAsync()
        {
            var status = await CheckAndRequestPermissionAsync(new Permissions.StorageRead());
            if (status == PermissionStatus.Granted)
            {
              
                IsPermission = true;
                await GetWriteAsync();
            }
            else
            {
                //Denie
                IsPermission = false;
                AppInfo.ShowSettingsUI();
            }
        }
        public async Task GetWriteAsync()
        {
            var status = await CheckAndRequestPermissionAsync(new Permissions.StorageWrite());
            if (status != PermissionStatus.Granted)
            {
                // Notify user permission was denied
                IsPermission = false;
                AppInfo.ShowSettingsUI();
                return;
            }

            //var location = await Geolocation.GetLocationAsync();
        }

        public async Task<PermissionStatus> CheckAndRequestPermissionAsync<T>(T permission)
                    where T : BasePermission
        {
            var status = await permission.CheckStatusAsync();
            if (status != PermissionStatus.Granted)
            {
                status = await permission.RequestAsync();
            }

            return status;
        }

       
    }
}