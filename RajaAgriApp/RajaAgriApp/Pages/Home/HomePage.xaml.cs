using RajaAgriApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RajaAgriApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            this.BindingContext = new HomeViewModel();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (Shell.Current.FlyoutBehavior == FlyoutBehavior.Disabled)
            {
                Shell.Current.FlyoutIsPresented = true;
            }
            else
            {
                Shell.Current.FlyoutIsPresented = false;
            }
        }
    }
}