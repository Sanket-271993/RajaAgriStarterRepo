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
    public partial class ProductRegistrationPage : BaseView
    {
        ProductRegistrationViewModel productRegistrationViewModel;
        public ProductRegistrationPage()
        {
            InitializeComponent();
            productRegistrationViewModel= new ProductRegistrationViewModel();
            this.BindingContext = productRegistrationViewModel;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            invoiceDatePicker.Focus();
        }

        protected override void OnAppearing()
        {
            productRegistrationViewModel.GetProductNameServiceCall();
           // productRegistrationViewModel.GetProductTypeServiceCall();
            base.OnAppearing();
        }

        protected override bool OnBackButtonPressed()
        {
            productRegistrationViewModel.IsProductTypeDDOpen = false;
            productRegistrationViewModel.IsProductNameDDOpen = false;
            productRegistrationViewModel.IsElectricalShopsDDOpen = false;
            productRegistrationViewModel.Dismiss();
            return base.OnBackButtonPressed();
        }
    }
}