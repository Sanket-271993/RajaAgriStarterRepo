using RajaAgriApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RajaAgriApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DropDownView : ContentView
    {
        public DropDownView()
        {
            InitializeComponent();
        }

        public static BindableProperty DropDownCommandProperty =
           BindableProperty.Create(nameof(DropDownCommand), typeof(ICommand), typeof(DropDownView));
        public ICommand DropDownCommand
        {
            get => (ICommand)GetValue(DropDownCommandProperty);
            set => SetValue(DropDownCommandProperty, value);
        }

        public static BindableProperty IsDropDownOpenProperty =
           BindableProperty.Create(nameof(IsDropDownOpen), typeof(bool), typeof(DropDownView),false,BindingMode.TwoWay);
        public bool IsDropDownOpen
        {
            get => (bool)GetValue(IsDropDownOpenProperty);
            set => SetValue(IsDropDownOpenProperty, value);
        }

        public static BindableProperty ProductsProperty =
           BindableProperty.Create(nameof(Products), typeof(ObservableCollection<DropDownModel>), typeof(DropDownView),null,BindingMode.Default,null,propertyChanged:OnProductsChanged);

        private static void OnProductsChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if(newValue!=null)
            {
                ((DropDownView)bindable).Products =(ObservableCollection<DropDownModel>)newValue;
            }
        }

        public ObservableCollection<DropDownModel> Products
        {
            get => (ObservableCollection<DropDownModel>)GetValue(ProductsProperty);
            set => SetValue(ProductsProperty, value);
        }
    }
}