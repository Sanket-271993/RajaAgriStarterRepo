using NavistarOCCApp.Common;
using RajaAgriApp.Common;
using RajaAgriApp.Models;
using RajaAgriApp.PopUpPages;
using RajaAgriApp.Resources;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace RajaAgriApp.ViewModels
{
    public class ProductRegistrationViewModel : BaseViewModel
    {
        public List<DropDownModel> Products { get; set; }
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
        private string _productName;
        public string ProductName
        {
            get { return _productName; }
            set { SetProperty(ref _productName, value); }
        }

        private string _productType;
        public string ProductType
        {
            get { return _productType; }
            set { SetProperty(ref _productType, value); }
        }

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
        public ICommand OnProductNameDropDownCommand { get; set; }
        public ICommand OnProductTypeDropDownCommand { get; set; }
        public ICommand OnElectricalShopsDropDownCommand { get; set; }
        public ICommand OnInvoiceDateCommand { get; set; }
        public ICommand FilePickerCommand { get; set; }
        public ICommand OnSubmitCommand { get; set; }


        public ProductRegistrationViewModel()
        {
            InitCommand();
            SetDropDownData();
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

        private void InitCommand()
        {

            OnProductNameDropDownCommand = new Command(OnProductNameDropDownClick);
            OnProductTypeDropDownCommand = new Command(OnProductTypeDropDownClick);
            OnElectricalShopsDropDownCommand = new Command(OnElectricalShopsDropDownClick);
            OnInvoiceDateCommand = new Command(OnInvoiceDateClick);
            FilePickerCommand = new Command(FilePickerClick);
            OnSubmitCommand = new Command(OnSubmitClick);
        }


        private async void OnSubmitClick(object obj)
        {
            await ShellRoutingService.Instance.GoBack();
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
            SetDropDown(DropDownType.ElectricSghop);
        }

        private void OnProductTypeDropDownClick(object obj)
        {
            IsProductTypeDDOpen = !IsProductTypeDDOpen;
            IsProductNameDDOpen = false;
            IsElectricalShopsDDOpen = false;
            SetDropDown(DropDownType.ProductType);
        }

        private void OnProductNameDropDownClick(Object obj)
        {
            IsProductNameDDOpen = !IsProductNameDDOpen;
            SetDropDown(DropDownType.ProductName);
        }

        private async void SetDropDown(DropDownType dropdowntype)
        {
            var dropDown = new DropDownPage(Products,dropdowntype);
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
                        IsProductNameDDOpen = false;
                        break;
                    case DropDownType.ProductType:
                        ProductType = dropEventArgs.SelectedData.ItemName;
                        IsProductTypeDDOpen = false;
                        break;
                    case DropDownType.ElectricSghop:
                        ElectricalShops = dropEventArgs.SelectedData.ItemName;
                        IsElectricalShopsDDOpen = false;
                        break;
                }
            }

        }

        private void SetAllUnSelected()
        {
            foreach (DropDownModel item in Products)
            {
                item.IsSelectedItem = false;
            }
        }

        private void SetDropDownData()
        {
            List<DropDownModel> _dropDowns = new List<DropDownModel>();
            _dropDowns.Add(new DropDownModel() { ItemID = 1, ItemName = "Catlog" });
            _dropDowns.Add(new DropDownModel() { ItemID = 2, ItemName = "Manual" });
            _dropDowns.Add(new DropDownModel() { ItemID = 3, ItemName = "Brochure" });
            Products = new List<DropDownModel>(_dropDowns);
        }
    }
}
