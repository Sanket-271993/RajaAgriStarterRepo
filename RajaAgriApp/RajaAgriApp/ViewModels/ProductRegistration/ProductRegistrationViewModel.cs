using NavistarOCCApp.Common;
using RajaAgriApp.Common;
using RajaAgriApp.Controller;
using RajaAgriApp.Models;
using RajaAgriApp.Pages;
using RajaAgriApp.PopUpPages;
using RajaAgriApp.Resources;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace RajaAgriApp.ViewModels
{
    public class ProductRegistrationViewModel : BaseViewModel
    {
        private IProductRegisterController _productRegisterController;

        public List<ProductModel> Products { get; set; }
        private bool _isProductNameDDOpen;
        public bool IsProductNameDDOpen
        {
            get { return _isProductNameDDOpen; }
            set { SetProperty(ref _isProductNameDDOpen, value); }
        }

        private bool _isProductTypeDDOpen;
        public bool IsProductTypeDDOpen
        {
            get { return _isProductTypeDDOpen; }
            set { SetProperty(ref _isProductTypeDDOpen, value); }
        }

        private bool _isElectricalShopsDDOpen;
        public bool IsElectricalShopsDDOpen
        {
            get { return _isElectricalShopsDDOpen; }
            set { SetProperty(ref _isElectricalShopsDDOpen, value); }
        }
        private int _productID;
        private string _productName;
        public string ProductName
        {
            get { return _productName; }
            set { SetProperty(ref _productName, value); }
        }

        private int _productTypeID;
        private string _productType;
        public string ProductType
        {
            get { return _productType; }
            set { SetProperty(ref _productType, value); }
        }

        private int _dealerID;
        private string _electricalShops;
        public string ElectricalShops
        {
            get { return _electricalShops; }
            set { SetProperty(ref _electricalShops, value); }
        }

        private DateTime _invoiceDate = DateTime.Now;
        public DateTime InvoiceDate
        {
            get { return _invoiceDate; }
            set { SetProperty(ref _invoiceDate, value); }
        }

        private string _invoiceSelectedDate;
        public string InvoiceSelectedDate
        {
            get { return _invoiceSelectedDate; }
            set { SetProperty(ref _invoiceSelectedDate, value); }
        }


        private string _serialNumber = String.Empty;
        public string SerialNumber
        {
            get { return _serialNumber; }
            set { SetProperty(ref _serialNumber, value); }
        }

        private string InvoiceImageBase64;

        public ICommand OnProductNameDropDownCommand { get; set; }
        public ICommand OnProductTypeDropDownCommand { get; set; }
        public ICommand OnElectricalShopsDropDownCommand { get; set; }
        public ICommand OnInvoiceDateCommand { get; set; }
        public ICommand FilePickerCommand { get; set; }
        public ICommand OnSubmitCommand { get; set; }


        public ProductRegistrationViewModel()
        {
            InitCommand();
            InitController();
            
            SetDropDownDefultValue();
        }

        private void SetDropDownDefultValue()
        {
            Title = AppResource.TitleProductRegistration;
            IsTranslateVisable = true;
            ProductName = AppResource.LabelProductName;
            ProductType = AppResource.LabelProductType;
            ElectricalShops = AppResource.LabelElectricalShops;
            InvoiceSelectedDate = AppResource.LabelProductInvoiceDate;
            // SerialNumber = AppResource.LabelProductSerialNumber;
            
        }

        private void InitController()
        {
            _productRegisterController = AppLocator.Instance.GetInstance<IProductRegisterController>();

        }

        private void InitCommand()
        {

            OnProductNameDropDownCommand = new Command(OnProductNameDropDownClick);
            OnProductTypeDropDownCommand = new Command(OnProductTypeDropDownClick);
            OnElectricalShopsDropDownCommand = new Command(OnElectricalShopsDropDownClick);
            OnInvoiceDateCommand = new Command(OnInvoiceDateClick);
            FilePickerCommand = new Command(FilePickerClick);
            OnSubmitCommand = new Command(OnSubmitClick);
        }

        public async void GetProductNameServiceCall()
        {
            try
            {
                if (IsConnected)
                {
                    AppIndicater.Instance.Show();
                    var response = await _productRegisterController.GetHome();
                   // AppIndicater.Instance.Dismiss();
                    if (response != null && response.Products?.Count > 0)
                    {
                        SetProductNameDropDownData(response.Products);
                        GetProductTypeServiceCall();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
               // AppIndicater.Instance.Dismiss();
            }
        }

        public async void GetProductTypeServiceCall()
        {
            try
            {
                if (IsConnected)
                {
                   // AppIndicater.Instance.Show();
                    var response = await _productRegisterController.GetProductType();
                   // AppIndicater.Instance.Dismiss();
                    if (response != null && response.ProductTypes?.Count > 0)
                    {
                        SetProductTypeDropDownData(response.ProductTypes);
                        GetDealerServiceCall();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
               // AppIndicater.Instance.Dismiss();
            }
        }

        public async void GetDealerServiceCall()
        {
            try
            {
                if (IsConnected)
                {

                   // AppIndicater.Instance.Show();
                    var response = await _productRegisterController.GetDealer();
                    AppIndicater.Instance.Dismiss();
                    if (response != null && response.Distributors?.Count > 0)
                    {
                        SetElecticShopsDropDownData(response.Distributors);
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

        private  void OnSubmitClick(object obj)
        {
            ProductRegisterServiceCall();
        }

        private async void ProductRegisterServiceCall()
        {
            try
            {
                if (IsConnected)
                {
                    bool isValid = IsValidData();
                    if (isValid)
                    {
                        AppIndicater.Instance.Show();
                        var request = GetRequestModel();

                        var response = await _productRegisterController.PostProductRegistration(request);
                        AppIndicater.Instance.Dismiss();
                        if (response != null && response.IsRegistered)
                        {
                            SetSnackBarMessage(response.Message);
                            await Task.Delay(3000);

                            await ShellRoutingService.Instance.GoBack();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
               // AppIndicater.Instance.Dismiss();
            }
        }

        private ProductRegistrationRequestModel GetRequestModel()
        {
            var request= new ProductRegistrationRequestModel();
            request.ProductType = _productTypeID;
            request.ProductId=_productID;
            request.DistributorId = _dealerID;
            request.SerialNumber= _serialNumber;
            request.InvoiceDate = InvoiceDate;
            request.InvoiceImage = InvoiceImageBase64;
            return request;
        }

        private void FilePickerClick(object obj)
        {
            SetFilePicker();
        }

        private async void SetFilePicker()
        {
            await PickAndShow();
        }

        private async Task<FileResult> PickAndShow()
        {
            try
            {
                var customFileType = new FilePickerFileType
                           (new Dictionary<DevicePlatform, IEnumerable<string>>
                                {
                                    { DevicePlatform.iOS, new[] { "public.image" } }, // or general UTType values
                                    { DevicePlatform.Android, new[] { "application/pdf", "image/jpeg" } },

                                });
                var options = new PickOptions
                {
                    PickerTitle = "Please select a comic file",
                    FileTypes = customFileType,
                };

                var result = await FilePicker.PickAsync(options);
                if (result != null)
                {
                    string fileName = $"File Name: {result.FileName}";
                    if (result.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) ||
                        result.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase))
                    {
                        var stream = await result.OpenReadAsync();
                        //var stream = file.GetStream();
                        var bytes = new byte[stream.Length];
                        await stream.ReadAsync(bytes, 0, (int)stream.Length);
                        InvoiceImageBase64 = System.Convert.ToBase64String(bytes);
                        //UserImage = ImageSource.FromStream(() => stream);
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                // The user canceled or something went wrong
            }

            return null;
        }



        private void OnInvoiceDateClick(object obj)
        {
            //
        }

        private void OnElectricalShopsDropDownClick(object obj)
        {
            IsElectricalShopsDDOpen = !IsElectricalShopsDDOpen;

            IsProductNameDDOpen = false;
            IsProductNameDDOpen = false;
            SetDropDownElectricalShops(_electicShopsDropDowns, DropDownType.ElectricSghop);
        }

        private async void SetDropDownElectricalShops(List<DropDownModel> electricalShopsDropDowns, DropDownType dropdowntype)
        {
            var dropDown = new DropDownPage(electricalShopsDropDowns, dropdowntype);
            dropDown.ItemSelectionClick += DropDown_ItemSelectionClick;
            await PopupNavigation.Instance.PushAsync(dropDown, false);
        }

        private void OnProductTypeDropDownClick(object obj)
        {
            IsProductTypeDDOpen = !IsProductTypeDDOpen;
            IsProductNameDDOpen = false;
            IsElectricalShopsDDOpen = false;
            SetDropDownProductTypeName(_productTypeDropDowns,DropDownType.ProductType);
        }

        private async void SetDropDownProductTypeName(List<DropDownModel> productTypeDropDowns, DropDownType dropdowntype)
        {
            var dropDown = new DropDownPage(productTypeDropDowns, dropdowntype);
            dropDown.ItemSelectionClick += DropDown_ItemSelectionClick;
            await PopupNavigation.Instance.PushAsync(dropDown, false);
        }

        private void OnProductNameDropDownClick(Object obj)
        {
            IsProductNameDDOpen = !IsProductNameDDOpen;
            SetDropDownProductName(_productNameDropDowns,DropDownType.ProductName);
        }

        private async void SetDropDownProductName(List<DropDownModel> productNameDropDowns, DropDownType dropdowntype)
        {
            var dropDown = new DropDownPage(productNameDropDowns,dropdowntype);
            dropDown.ItemSelectionClick += DropDown_ItemSelectionClick;
            await PopupNavigation.Instance.PushAsync(dropDown, false);
        }

        private void DropDown_ItemSelectionClick(object sender, EventArgs e)
        {
            DropDownEventArg dropEventArgs = ((DropDownEventArg)e);
            if (dropEventArgs?.SelectedData != null)
            {
                switch (dropEventArgs.DropDownType)
                {
                    case DropDownType.ProductName:
                        ProductName = dropEventArgs.SelectedData.ItemName;
                        _productID = dropEventArgs.SelectedData.ItemID;
                        IsProductNameDDOpen = false;
                        break;
                    case DropDownType.ProductType:
                        ProductType = dropEventArgs.SelectedData.ItemName;
                        _productTypeID = dropEventArgs.SelectedData.ItemID;
                        IsProductTypeDDOpen = false;
                        break;
                    case DropDownType.ElectricSghop:
                        ElectricalShops = dropEventArgs.SelectedData.ItemName;
                        _dealerID = dropEventArgs.SelectedData.ItemID;
                        IsElectricalShopsDDOpen = false;
                        break;
                }
            }
        }

    

        private List<DropDownModel> _productNameDropDowns;
        private void SetProductNameDropDownData(List<ProductModel> products)
        {
            List<DropDownModel> _dropDowns = new List<DropDownModel>();
            _dropDowns.Add(new DropDownModel() { ItemID = 0, ItemName = AppResource.LabelProductName });
            foreach (var product in products)
            {
                _dropDowns.Add(new DropDownModel() { ItemID = product.ProductID, ItemName = product.ProductName });
            }
           
            _productNameDropDowns = new List<DropDownModel>(_dropDowns);
        }

        private List<DropDownModel> _productTypeDropDowns;
        private void SetProductTypeDropDownData(List<ProductTypeModel> productTypes)
        {
            List<DropDownModel> _dropDowns = new List<DropDownModel>();
            _dropDowns.Add(new DropDownModel() { ItemID = 0, ItemName = AppResource.LabelProductType });
            foreach (var product in productTypes)
            {
                _dropDowns.Add(new DropDownModel() { ItemID = product.ProductTypeID, ItemName = product.ProductType });
            }
            _productTypeDropDowns = new List<DropDownModel>(_dropDowns);
        }

        private List<DropDownModel> _electicShopsDropDowns;
        private void SetElecticShopsDropDownData(List<DealerModel> electicShops)
        {
            List<DropDownModel> _dropDowns = new List<DropDownModel>();
            _dropDowns.Add(new DropDownModel() { ItemID = 0, ItemName = AppResource.LabelElectricalShops });
            foreach (var product in electicShops)
            {
                _dropDowns.Add(new DropDownModel() { ItemID = product.DealerId, ItemName = product.DealerName });
            }
            _electicShopsDropDowns = new List<DropDownModel>(_dropDowns);
        }

        private bool IsValidData()
        {
            if (!string.IsNullOrEmpty(ProductName) && ProductName.Equals(AppResource.LabelProductName))
            {
                SetAlertPopup("Please Select Product Name");
                return false;
            }
            else if (!string.IsNullOrEmpty(ProductType) && ProductName.Equals(AppResource.LabelProductType))
            {
                SetAlertPopup("Please Select Product Type");
                return false;
            }
            else if (!string.IsNullOrEmpty(ElectricalShops) && ProductName.Equals(AppResource.LabelElectricalShops))
            {
                SetAlertPopup("Please Select Product Type");
                return false;
            }
            else if (string.IsNullOrEmpty(SerialNumber))
            {
                SetAlertPopup("Please enter Serial Number");
                return false;
            }
            else if(InvoiceSelectedDate.Equals(DateTime.MinValue))
            {
                SetAlertPopup("Please select invoice date");
                return false;
            }
            else if (string.IsNullOrEmpty(InvoiceImageBase64))
            {
                SetAlertPopup("Please select invoice image");
                return false;
            }

            return true;
        }
    }
}
