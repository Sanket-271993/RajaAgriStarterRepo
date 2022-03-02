using NavistarOCCApp.Common;
using RajaAgriApp.Models;
using RajaAgriApp.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace RajaAgriApp.ViewModels
{
    public class ProductDetailsViewModel:BaseViewModel
    {
        private string _productName;   
        public string ProductName
        {
            get { return _productName; }
            set { SetProperty(ref _productName, value); }   
        }

        private string _productDescription;
        public string ProductDescription
        {
            get { return _productDescription; }
            set { SetProperty(ref _productDescription, value); }
        }

        private bool _isDropDownOpen=false;
        public bool IsDropDownOpen
        {
            get { return _isDropDownOpen; }
            set { SetProperty(ref _isDropDownOpen, value); }
        }


        private int _postion = 0;
        public int Postion
        {
            get { return _postion; }
            set { SetProperty(ref _postion, value); }
        }


        public ObservableCollection<ProductDetailsModel> Products { get; set; }
        public ObservableCollection<DropDownModel> DropDownDataList { get; set; }

        public ICommand OnDropDownCommand { get; set; }
        public ICommand OnDropDownItemCommand { get; set; }

        public ICommand OnRightArrowCommand { get; set; }
        public ICommand OnLeftArrowCommand { get; set; }
        public ICommand OnGetDealerCommand { get; set; }

        public ProductDetailsViewModel()
        {
            InitCommand();
            GetProductImages();
            SetProductDetails();
            SetDropDownData();
        }

        private void InitCommand()
        {
            OnDropDownCommand = new Command(OnDropDownClick);
            OnDropDownItemCommand = new Command<DropDownModel>(OnDropDownItemClick);
            OnRightArrowCommand = new Command(OnRightArrowClick);
            OnLeftArrowCommand = new Command(OnLeftArrowClick);
            OnGetDealerCommand = new Command(OnGetDealerClick);
        }

        private async  void OnGetDealerClick(object obj)
        {
            await ShellRoutingService.Instance.NavigateTo($"{nameof(DealerPage)}");
        }

        private void OnLeftArrowClick(object obj)
        {
            if(Postion!=0)
            {
                Postion--;
            }
        }

        private void OnRightArrowClick(object obj)
        {
           if(Postion<(Products.Count-1))
            {
                Postion++;
            }
        }

        private void OnDropDownItemClick(DropDownModel DropDownItem)
        {
            SetAllUnSelected();
            DropDownItem.IsSelectedItem = !DropDownItem.IsSelectedItem;
            IsDropDownOpen = false;
        }

        private void SetAllUnSelected()
        {
            foreach (DropDownModel item in DropDownDataList)
            {
                item.IsSelectedItem = false;
            }
        }
        private void OnDropDownClick(object obj)
        {
            IsDropDownOpen=!IsDropDownOpen;
        }

        private void GetProductImages()
        {
             List<ProductDetailsModel> _productDetails = new List<ProductDetailsModel>();
            _productDetails.Add(new ProductDetailsModel() { Id = 1, ProductName = "AS ADOL Starter", ImageName = "ic_product_wid_pro" });
            _productDetails.Add(new ProductDetailsModel() { Id = 2, ProductName = "DOL controller", ImageName = "ic_product_wide" });
            _productDetails.Add(new ProductDetailsModel() { Id = 3, ProductName = "FASD1 Starter", ImageName = "ic_product_wid_pro" });

            Products = new ObservableCollection<ProductDetailsModel>(_productDetails);
        }


        private void SetProductDetails()
        {
            ProductName = "FASD2 Starter";
            ProductDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In ornare quis tellus efficitur elementum. Cras varius augue tortor, vel mattis quam posuere eu. Etiam luctus nisi at mauris faucibus, sit amet imperdiet nunc porta. Maecenas a felis ut velit tempor aliquam nec tincidunt dui. Sed sit amet finibus nulla. Nulla tristique metus vel nulla venenatis,";
        }


        private void SetDropDownData()
        {
            List<DropDownModel> _dropDowns = new List<DropDownModel>();
            _dropDowns.Add(new DropDownModel() { ItemID = 1, ItemName = "Catlog" });
            _dropDowns.Add(new DropDownModel() { ItemID = 2, ItemName = "Manual" });
            _dropDowns.Add(new DropDownModel() { ItemID = 3, ItemName = "Brochure" });
            DropDownDataList = new ObservableCollection<DropDownModel>(_dropDowns);
        }
    }
}
