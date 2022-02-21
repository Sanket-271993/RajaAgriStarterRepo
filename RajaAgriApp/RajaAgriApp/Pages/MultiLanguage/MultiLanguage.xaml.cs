using RajaAgriApp.ViewModels;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace RajaAgriApp.Pages
{
    public partial class MultiLanguage : ContentPage
    {
        public MultiLanguage()
        {
            InitializeComponent();

            this.BindingContext = new MultiLanguageViewModel();

            englishbtn.TextColor = Color.FromHex("#005159");
            englishbtn.BackgroundColor = Color.FromHex("#c2ffee");

            hindibtn.TextColor = Color.FromHex("#000028");
            hindibtn.BackgroundColor = Color.FromHex("#ffffff");

            punjabibtn.TextColor = Color.FromHex("#000028");
            punjabibtn.BackgroundColor = Color.FromHex("#ffffff");

            marathibtn.TextColor = Color.FromHex("#000028");
            marathibtn.BackgroundColor = Color.FromHex("#ffffff");

            gujratibtn.TextColor = Color.FromHex("#000028");
            gujratibtn.BackgroundColor = Color.FromHex("#ffffff");
        }

        void SubmitButton_Clicked(System.Object sender, System.EventArgs e)
        {
            Shell.Current.GoToAsync($"//{nameof(RegistrationPage)}");
        }

        void englishbtn_Clicked(System.Object sender, System.EventArgs e)
        {
            englishbtn.TextColor = Color.FromHex("#005159");
            englishbtn.BackgroundColor = Color.FromHex("#c2ffee");

            hindibtn.TextColor = Color.FromHex("#000028");
            hindibtn.BackgroundColor = Color.FromHex("#ffffff");

            punjabibtn.TextColor = Color.FromHex("#000028");
            punjabibtn.BackgroundColor = Color.FromHex("#ffffff");

            marathibtn.TextColor = Color.FromHex("#000028");
            marathibtn.BackgroundColor = Color.FromHex("#ffffff");

            gujratibtn.TextColor = Color.FromHex("#000028");
            gujratibtn.BackgroundColor = Color.FromHex("#ffffff");
        }

        void hindibtn_Clicked(System.Object sender, System.EventArgs e)
        {
            hindibtn.TextColor = Color.FromHex("#005159");
            hindibtn.BackgroundColor = Color.FromHex("#c2ffee");

            englishbtn.TextColor = Color.FromHex("#000028");
            englishbtn.BackgroundColor = Color.FromHex("#ffffff");

            punjabibtn.TextColor = Color.FromHex("#000028");
            punjabibtn.BackgroundColor = Color.FromHex("#ffffff");

            marathibtn.TextColor = Color.FromHex("#000028");
            marathibtn.BackgroundColor = Color.FromHex("#ffffff");

            gujratibtn.TextColor = Color.FromHex("#000028");
            gujratibtn.BackgroundColor = Color.FromHex("#ffffff");

        }

        void punjabibtn_Clicked(System.Object sender, System.EventArgs e)
        {
            punjabibtn.TextColor = Color.FromHex("#005159");
            punjabibtn.BackgroundColor = Color.FromHex("#c2ffee");

            englishbtn.TextColor = Color.FromHex("#000028");
            englishbtn.BackgroundColor = Color.FromHex("#ffffff");

            hindibtn.TextColor = Color.FromHex("#000028");
            hindibtn.BackgroundColor = Color.FromHex("#ffffff");

            marathibtn.TextColor = Color.FromHex("#000028");
            marathibtn.BackgroundColor = Color.FromHex("#ffffff");

            gujratibtn.TextColor = Color.FromHex("#000028");
            gujratibtn.BackgroundColor = Color.FromHex("#ffffff");

        }

        void marathibtn_Clicked(System.Object sender, System.EventArgs e)
        {
            marathibtn.TextColor = Color.FromHex("#005159");
            marathibtn.BackgroundColor = Color.FromHex("#c2ffee");

            englishbtn.TextColor = Color.FromHex("#000028");
            englishbtn.BackgroundColor = Color.FromHex("#ffffff");

            hindibtn.TextColor = Color.FromHex("#000028");
            hindibtn.BackgroundColor = Color.FromHex("#ffffff");

            punjabibtn.TextColor = Color.FromHex("#000028");
            punjabibtn.BackgroundColor = Color.FromHex("#ffffff");

            gujratibtn.TextColor = Color.FromHex("#000028");
            gujratibtn.BackgroundColor = Color.FromHex("#ffffff");

        }

        void gujratibtn_Clicked(System.Object sender, System.EventArgs e)
        {
            gujratibtn.TextColor = Color.FromHex("#005159");
            gujratibtn.BackgroundColor = Color.FromHex("#c2ffee");

            englishbtn.TextColor = Color.FromHex("#000028");
            englishbtn.BackgroundColor = Color.FromHex("#ffffff");

            hindibtn.TextColor = Color.FromHex("#000028");
            hindibtn.BackgroundColor = Color.FromHex("#ffffff");

            marathibtn.TextColor = Color.FromHex("#000028");
            marathibtn.BackgroundColor = Color.FromHex("#ffffff");

            punjabibtn.TextColor = Color.FromHex("#000028");
            punjabibtn.BackgroundColor = Color.FromHex("#ffffff");

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistrationPage());
        }
    }
}
