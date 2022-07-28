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
    public partial class ProductDetailsPage : ContentPage
    {
        ProductDetailsViewModel productDetailsViewModel;
        public ProductDetailsPage()
        {
            InitializeComponent();
            productDetailsViewModel = new ProductDetailsViewModel();
            this.BindingContext= productDetailsViewModel;
        }

        protected override bool OnBackButtonPressed()
        {
            productDetailsViewModel.IsDropDownOpen = false;
            productDetailsViewModel.Dismiss();
            return base.OnBackButtonPressed();
        }
    }
}