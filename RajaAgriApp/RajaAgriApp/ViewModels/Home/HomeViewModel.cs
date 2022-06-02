using NavistarOCCApp.Common;
using RajaAgriApp.Common;
using RajaAgriApp.Controller;
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
        private ObservableCollection<ProductModel> _products;
        public ObservableCollection<ProductModel> Products
        { 
            get { return _products; }
            set { SetProperty(ref _products, value); } 
        }

        private IHomeController _homeController;

        public ICommand SearchCommand { get; set; }
        public ICommand NotificationCommand { get; set; }
        public ICommand ItemCommand { get; set; }

        public ICommand OnMenuCommand { get; set; }

        public HomeViewModel()
        {
            SetMenuAndTitle();
            InitCommand();
            ControlerInit();
          //  GetProductData();
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
            OnMenuCommand = new Command<ProductModel>(OnMenuClick);
        }

        private void ControlerInit()
        {
            _homeController= AppLocator.Instance.GetInstance<IHomeController>();

        }

        private async void OnMenuClick(ProductModel obj)
        {
            await ShellRoutingService.Instance.NavigateTo(nameof(ProfilePage));
        }

        private async void OnItemClick(ProductModel product)
        {
           await ShellRoutingService.Instance.NavigateTo($"{ nameof(ProductDetailsPage)}?ProductIdParameter={product.ProductID}");
        }

        private void OnNotificationClick(object obj)
        {
            //
        }

        private void OnSearchClicked(object obj)
        {
            ShellRoutingService.Instance.NavigateTo(nameof(SearchPage));
        }

        //private void GetProductData()
        //{
        //    List<ProductResponseModel> _products = new List<ProductResponseModel>();
        //    _products.Add(new ProductResponseModel() { ProductID = 1, ProductName = "AS ADOL Starter", ImageName = "ic_product_wid_pro" });
        //    _products.Add(new ProductResponseModel() { ProductID = 2, ProductName = "DOL controller", ImageName = "ic_product_wide" });
        //    _products.Add(new ProductResponseModel() { ProductID = 3, ProductName = "FASD1 Starter", ImageName = "ic_product_wid_pro" });
        //    _products.Add(new ProductResponseModel() { ProductID = 4, ProductName = "RAJA+ DOL", ImageName = "ic_product_port" });
        //    _products.Add(new ProductResponseModel() { ProductID = 5, ProductName = "FASD2 Starter", ImageName = "ic_product_port" });
        //    _products.Add(new ProductResponseModel() { ProductID = 6, ProductName = "FASD3 Starter", ImageName = "ic_product_port" });
        //    _products.Add(new ProductResponseModel() { ProductID = 7, ProductName = "FASD2 Starter", ImageName = "ic_product_port" });
        //    Products = new ObservableCollection<ProductResponseModel>(_products);
        //}


        public async void SetHomeServiceCall()
        {
            try
            {
                if (IsConnected)
                {

                    AppIndicater.Instance.Show();
                    var response = await _homeController.GetHome();
                     AppIndicater.Instance.Dismiss();
                    if (response != null && response.Products?.Count > 0)
                    {
                      
                        Products = new ObservableCollection<ProductModel>(response.Products);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                AppIndicater.Instance.Dismiss();
            }
        }

    }
}
