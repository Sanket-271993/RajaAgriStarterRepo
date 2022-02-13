using NavistarOCCApp.Common;
using RajaAgriApp.Models;
using RajaAgriApp.Pages;
using RajaAgriApp.Resources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace RajaAgriApp.ViewModels
{
    public class HomeViewModel:BaseViewModel
    {
        public ObservableCollection<ProductModel> Products{ get; set; }

        public ICommand SearchCommand { get; set; }
        public ICommand NotificationCommand { get; set; }
        public ICommand ItemCommand { get; set; }

        public HomeViewModel()
        {
            SetMenuAndTitle();
            InitCommand();
            GetProductData();
        }

        private void SetMenuAndTitle()
        {
            Title = AppResource.TitleHome;
            IsMenuVisable = true;
            IsTranslateVisable = false;
        }

        private void InitCommand()
        {
            SearchCommand = new Command(OnSearchClicked);
            NotificationCommand = new Command(OnNotificationClick);
            ItemCommand = new Command<ProductModel>(OnItemClick);
        }

        private void OnItemClick(ProductModel  product)
        {
           //
        }

        private void OnNotificationClick(object obj)
        {
            //
        }

        private void OnSearchClicked(object obj)
        {
            ShellRoutingService.Instance.NavigateTo(nameof(SearchPage));
        }

        private void GetProductData()
        {
            List<ProductModel> _products = new List<ProductModel>();
            _products.Add(new ProductModel() { ProductID = 1, ProductName = "AS ADOL Starter", ImageName = "ic_product_wid_pro" });
            _products.Add(new ProductModel() { ProductID = 2, ProductName = "DOL controller", ImageName = "ic_product_wide" });
            _products.Add(new ProductModel() { ProductID = 3, ProductName = "FASD1 Starter", ImageName = "ic_product_wid_pro" });
            _products.Add(new ProductModel() { ProductID = 4, ProductName = "RAJA+ DOL", ImageName = "ic_product_port" });
            _products.Add(new ProductModel() { ProductID = 5, ProductName = "FASD2 Starter", ImageName = "ic_product_port" });
            _products.Add(new ProductModel() { ProductID = 6, ProductName = "FASD3 Starter", ImageName = "ic_product_port" });
            _products.Add(new ProductModel() { ProductID = 7, ProductName = "FASD2 Starter", ImageName = "ic_product_port" });
            Products = new ObservableCollection<ProductModel>(_products);
        }
    }
}
