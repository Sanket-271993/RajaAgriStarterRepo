using NavistarOCCApp.Common;
using RajaAgriApp.Common;
using RajaAgriApp.Controller;
using RajaAgriApp.Models;
using RajaAgriApp.Pages;
using RajaAgriApp.PopUpPages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace RajaAgriApp.ViewModels
{
    [QueryProperty("ProductId", "ProductIdParameter")]
    public class ProductDetailsViewModel:BaseViewModel
    {
        private ProductDetailsModel productDeatils;
        private IProductDetailsController _productDetailsController;

        private string _productName;   
        public string ProductName
        {
            get { return _productName; }
            set { SetProperty(ref _productName, value); }   
        }

        private string _productId;
        public string ProductId
        {
            get { return _productId; }
            set { 
                SetProperty(ref _productId, value);
                SetProductDetailsServiceCall();
            }
        }

        private string _productDescription;
        public string ProductDescription
        {
            get { return _productDescription; }
            set { SetProperty(ref _productDescription, value); }
        }

        private bool _isArrowVisable = false;
        public bool IsArrowVisable
        {
            get { return _isArrowVisable; }
            set { SetProperty(ref _isArrowVisable, value); }
        }

        private bool _isDropDownOpen = false;
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

        private ObservableCollection<ProductImageData> _products;
        public ObservableCollection<ProductImageData> Products 
        { get { return _products; }
            set { SetProperty(ref _products, value); } 
        }
        public ObservableCollection<DropDownModel> DropDownDataList { get; set; }

        public ICommand OnDropDownCommand { get; set; }
        public ICommand OnDropDownItemCommand { get; set; }

        public ICommand OnRightArrowCommand { get; set; }
        public ICommand OnLeftArrowCommand { get; set; }
        public ICommand OnGetDealerCommand { get; set; }

        public ICommand OnReviewCommand { get; set; }

        public ProductDetailsViewModel()
        {
            InitCommand();
            //  GetProductImages();
            // SetProductDetails();
            InitController();
            SetDropDownData();
        }

        private void InitCommand()
        {
            OnDropDownCommand = new Command(OnDropDownClick);
            OnDropDownItemCommand = new Command<DropDownModel>(OnDropDownItemClick);
            OnRightArrowCommand = new Command(OnRightArrowClick);
            OnLeftArrowCommand = new Command(OnLeftArrowClick);
            OnGetDealerCommand = new Command(OnGetDealerClick);
            OnReviewCommand = new Command(OnReviewClick);
        }

        private void InitController()
        {
            _productDetailsController=AppLocator.Instance.GetInstance<IProductDetailsController>();
        }


        private async void OnReviewClick(object obj)
        {
            await ShellRoutingService.Instance.NavigateTo($"{nameof(ReviewPage)}");
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

            SetDropDown();
        }

        private async void SetDropDown()
        {
            var dropDown = new DownloadPopUpPage(_dropDowns);
            //dropDown.ItemSelectionClick += DropDown_ItemSelectionClick;
            await PopupNavigation.Instance.PushAsync(dropDown, false);
        }

        private void GetProductImages(ProductDetailsModel productDetailsModel)
        {
            List<ProductImageData> _productImages = new List<ProductImageData>();
            if (!string.IsNullOrEmpty(productDetailsModel.Image1))
            {
                _productImages.Add(new ProductImageData() { ProductID = 1, ImageName = GetImage(productDetailsModel.Image1) });
            }
            if (!string.IsNullOrEmpty(productDetailsModel.Image2))
            {
                _productImages.Add(new ProductImageData() { ProductID = 1, ImageName = GetImage(productDetailsModel.Image2) });
            }
            if (!string.IsNullOrEmpty(productDetailsModel.Image3))
            {
                _productImages.Add(new ProductImageData() { ProductID = 1, ImageName = GetImage(productDetailsModel.Image3) });
            }
            if (_productImages?.Count>0)
            {
                IsArrowVisable = true;
                Products = new ObservableCollection<ProductImageData>(_productImages);
            }
        }


         private  List<DropDownModel> _dropDowns;


        private void SetDropDownData()
        {
             _dropDowns = new List<DropDownModel>();
            _dropDowns.Add(new DropDownModel() { ItemID = 1, ItemName = "Catlog" });
            _dropDowns.Add(new DropDownModel() { ItemID = 2, ItemName = "Manual" });
            _dropDowns.Add(new DropDownModel() { ItemID = 3, ItemName = "Brochure" });
            DropDownDataList = new ObservableCollection<DropDownModel>(_dropDowns);
        }

        
        public async void SetProductDetailsServiceCall()
        {
            try
            {
                if (IsConnected)
                {
                    var requestModel = new ProductDetailsRequestModel() 
                    { ProductId = Convert.ToInt32(ProductId), LanguageId = LanguageID };
                    AppIndicater.Instance.Show();
                    var response = await _productDetailsController.GetProductDetails(requestModel);
                    AppIndicater.Instance.Dismiss();
                    if (response != null && response.Products?.Count > 0)
                    {
                         productDeatils = response.Products[0];
                        SetProductDetails(productDeatils);
                        GetProductImages(productDeatils);
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


        private ImageSource GetImage(string image)
        {

            ImageSource _productImage;

            _productImage = ImageSource.FromStream(
                () => new MemoryStream(Convert.FromBase64String(image)));

            return _productImage;
        }

        private void SetProductDetails(ProductDetailsModel productDetails)
        {
            if(productDetails!=null)
            {
                ProductName = productDetails.ProductName;
                ProductDescription = productDetails.Description;
            }
        }


        private async Task<string> DownloadPdfFileAsync(string fileUrl,string fileName)
        {
            var filePath = Path.Combine(FileSystem.AppDataDirectory, "test.pdf");

            if (File.Exists(filePath))
                return filePath;

            var httpClient = new HttpClient();
            var pdfBytes = await httpClient.GetByteArrayAsync("ENTER YOUR URL TO THE PDF FILE HERE");

            try
            {
                File.WriteAllBytes(filePath, pdfBytes);

                return filePath;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
            }

            return null;
        }
    }
}
