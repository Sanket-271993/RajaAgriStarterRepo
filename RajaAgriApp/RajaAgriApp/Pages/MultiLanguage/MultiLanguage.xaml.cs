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
        }

       
    }
}
