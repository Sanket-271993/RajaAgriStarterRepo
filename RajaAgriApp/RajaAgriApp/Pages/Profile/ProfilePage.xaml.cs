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
    public partial class ProfilePage : BaseView
    {
        ProfileViewModel _profileViewModel;
        public ProfilePage()
        {
            InitializeComponent();
            _profileViewModel = new ProfileViewModel();
            this.BindingContext = _profileViewModel;
        }

        protected override void OnAppearing()
        {
            _profileViewModel.GetProfileServiceCall();
            base.OnAppearing();
        }
    }
}