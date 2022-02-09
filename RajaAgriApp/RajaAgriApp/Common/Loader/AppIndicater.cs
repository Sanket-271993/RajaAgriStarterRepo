using RajaAgriApp.PopUpPages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace RajaAgriApp.Common
{
    public class AppIndicater
    {
        private static AppIndicater _instance;

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
        }

        public async void Dismiss()
        {
            await PopupNavigation.Instance.PopAsync();
        }
    }
}
