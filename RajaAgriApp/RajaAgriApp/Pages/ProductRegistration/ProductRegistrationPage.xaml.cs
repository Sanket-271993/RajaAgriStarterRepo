﻿using RajaAgriApp.ViewModels;
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
        public ProductRegistrationPage()
        {
            InitializeComponent();
            this.BindingContext = new ProductRegistrationViewModel();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            invoiceDatePicker.Focus();
        }
    }
}