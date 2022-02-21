using System;
using RajaAgriApp.Pages;
using Xamarin.Forms;

namespace RajaAgriApp.ViewModels
{
    public class MultiLanguageViewModel : BaseViewModel
    {
        public Command SubmitButtonCommand { get; }

        public MultiLanguageViewModel()
        {
            SubmitButtonCommand = new Command(OnSubmitClicked);
        }

        private async void OnSubmitClicked()
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
           // await Shell.Current.GoToAsync($"//{nameof(RegistrationPage)}");

           // await Navigation.PushAsync(new RegistrationPage());
        }
    }
}
