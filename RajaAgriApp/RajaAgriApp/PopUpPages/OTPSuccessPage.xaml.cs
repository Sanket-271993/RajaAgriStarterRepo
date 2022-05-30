using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms.Xaml;

namespace RajaAgriApp.PopUpPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OTPSuccessPage : PopupPage
    {

        private string _popupTitle;

        public string PopupTitle
        {
            get { return _popupTitle; }
            set { 
                _popupTitle = value;

                OnPropertyChanged(nameof(PopupTitle));
            }
        }
        public event EventHandler OkClick;
        public OTPSuccessPage(string title)
        {
            PopupTitle = title;
            InitializeComponent();
            this.BindingContext = this;
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