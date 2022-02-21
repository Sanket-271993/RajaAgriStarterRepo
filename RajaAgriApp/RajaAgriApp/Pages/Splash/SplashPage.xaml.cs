using NavistarOCCApp.Common;
using RajaAgriApp.AppDependencyService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RajaAgriApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SplashPage : ContentPage
    {
        public SplashPage()
        {
            InitializeComponent();
            DependencyService.Get<IStatusBarColor>().HideStatusBar();
           // Task startupWork = new Task(() => { NavigateToShell(); });
            Device.BeginInvokeOnMainThread(()=>NavigateToShell());
            //startupWork.Start();
           
        }

        private async void NavigateToShell()
        {
            await Task.Delay(2000);
            await Navigation.PushAsync(new MultiLanguage());
            DependencyService.Get<IStatusBarColor>().ShowStatusBar();
            // await ShellRoutingService.Instance.NavigateTo($"{nameof(RegistrationPage)}");


        }
      
    }
}