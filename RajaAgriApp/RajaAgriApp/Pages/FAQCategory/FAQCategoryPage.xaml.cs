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
    public partial class FAQCategoryPage : BaseView
    {
        FAQCategoryViewModel FAQCategoryViewModel;
        public FAQCategoryPage()
        {
            InitializeComponent();
            FAQCategoryViewModel = new FAQCategoryViewModel();
            BindingContext = FAQCategoryViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            FAQCategoryViewModel.SetFAQCategoryServiceCall();
        }
    }
}