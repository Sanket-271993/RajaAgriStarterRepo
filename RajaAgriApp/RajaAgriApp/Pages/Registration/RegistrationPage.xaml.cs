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
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
            this.BindingContext=new RegistrationViewModel();
        }
        
        private void nameEntry_Focused(object sender, FocusEventArgs e)
        {

            nameStackLayout.BackgroundColor = Color.FromHex("#d1fff2");
            namelabel.TextColor = Color.FromHex("#000028");

        }

        private void nameEntry_Unfocused(object sender, FocusEventArgs e)
        {
            nameStackLayout.BackgroundColor = Color.FromHex("#ebf7f8");
            namelabel.TextColor = Color.FromHex("#4c4c68");
        }

        private void pinCodeEntry_Focused(object sender, FocusEventArgs e)
        {
            pinCodeStackLayout.BackgroundColor = Color.FromHex("#d1fff2");
            pincodelabel.TextColor = Color.FromHex("#000028");
        }
        private void pinCodeEntry_Unfocused(object sender, FocusEventArgs e)
        {
            pinCodeStackLayout.BackgroundColor = Color.FromHex("#ebf7f8");
            pincodelabel.TextColor = Color.FromHex("#4c4c68");
        }
        private void landMarkEntry_Focused(object sender, FocusEventArgs e)
        {
            landMarkStackLayout.BackgroundColor = Color.FromHex("#d1fff2");
            pincodelabel.TextColor = Color.FromHex("#000028");
        }

        private void landMarkEntry_Unfocused(object sender, FocusEventArgs e)
        {
            landMarkStackLayout.BackgroundColor = Color.FromHex("#ebf7f8");
            pincodelabel.TextColor = Color.FromHex("#4c4c68");
        }

        private void adharCardAddressEditor_Focused(object sender, FocusEventArgs e)
        {
            addharStackLayout.BackgroundColor = Color.FromHex("#d1fff2");
            AadharCardlabel.TextColor = Color.FromHex("#000028");
        }

        private void adharCardAddressEditor_Unfocused(object sender, FocusEventArgs e)
        {
            addharStackLayout.BackgroundColor = Color.FromHex("#ebf7f8");
            AadharCardlabel.TextColor = Color.FromHex("#4c4c68");
        }
   
    }
}