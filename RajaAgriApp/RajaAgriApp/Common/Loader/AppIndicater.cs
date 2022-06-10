using RajaAgriApp.PopUpPages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XF.Material.Forms.UI.Dialogs;

namespace RajaAgriApp.Common
{
    public class AppIndicater
    {
        private static AppIndicater _instance;
        private IMaterialModalPage _loadingDialog;
        public static AppIndicater Instance
        {
            get
            {
                return _instance ?? (_instance = new AppIndicater());
            }
        }

        
     
        public async void Show()
        {
              var loader = new LoadingPopupPage();
              await PopupNavigation.Instance.PushAsync(loader);
           // _loadingDialog.Dispose();
           // _loadingDialog = await MaterialDialog.Instance.LoadingDialogAsync(message: "Loading");
        }

        public async void Dismiss()
        {

           // Device.BeginInvokeOnMainThread(async() => await _loadingDialog.DismissAsync());
          //  _loadingDialog.Dispose();
            await PopupNavigation.Instance.PopAsync();

        }
    }
}
