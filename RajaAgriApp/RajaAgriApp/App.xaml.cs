using NavistarOCCApp.Common;
using RajaAgriApp.AppDependencyService;
using RajaAgriApp.PopUpPages;
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


            MainPage = new AppShell();
            //MainPage = new OTPSuccessPage();
        }


        private void SetLang()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.InstalledUICulture;

            CultureInfo language = new CultureInfo("ta");
            Thread.CurrentThread.CurrentUICulture = language;
   

          //  RajaAgriApp..Culture = language;
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
