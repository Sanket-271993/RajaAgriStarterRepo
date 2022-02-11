using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using Xamarin.Forms.Xaml;

namespace RajaAgriApp.PopUpPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OTPSuccessPage : PopupPage
    {
        public event EventHandler OkClick;
        public OTPSuccessPage()
        {
            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            Dismiss();
            OkClick.Invoke(this, e);
        }
        public async void Dismiss()
        {
            await PopupNavigation.Instance.PopAsync();
        }
    }
}