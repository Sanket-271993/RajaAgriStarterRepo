using NavistarOCCApp.Common;
using RajaAgriApp.AppDependencyService;
using RajaAgriApp.Pages;
using RajaAgriApp.Pages.Profile;
using RajaAgriApp.PopUpPages;
using RajaAgriApp.Resources;
using System.Globalization;

using System.Threading;
using Xamarin.Forms;

namespace RajaAgriApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Get<IStatusBarColor>().SetColoredStatusBar("#00feb9");
            ProjectSetup.Instance.AppSetup();
           // SetUpLang();

           //MainPage = new AppShell();
            MainPage = new ProfilePage();
        }


        private void SetUpLang()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.InstalledUICulture;

            CultureInfo language = new CultureInfo("gu");
            Thread.CurrentThread.CurrentUICulture = language;
   

             AppResource.Culture = language;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
