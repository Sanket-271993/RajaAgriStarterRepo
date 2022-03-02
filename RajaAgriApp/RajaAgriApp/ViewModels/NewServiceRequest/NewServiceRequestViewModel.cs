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
    public class NewServiceRequestViewModel:BaseViewModel
    {
        public ObservableCollection<DropDownModel> Products { get; set; }
        List<DropDownModel> _products;
        List<DropDownModel> _ProductProblems;
         
        private bool IsImageOne;
        private bool IsImageTwo;
        private bool IsImageThree;
        private bool _isProductNameDDOpen;
        public bool IsProductNameDDOpen
        {
            get { return _isProductNameDDOpen; }
            set { SetProperty(ref _isProductNameDDOpen, value); }
        }

        private bool _isProblemTypeDDOpen;
        public bool IsProblemTypeDDOpen
        {
            get { return _isProblemTypeDDOpen; }
            set { SetProperty(ref _isProblemTypeDDOpen, value); }
        }

        private string _productSerialNumber;
        public string ProductSerialNumber
        {
            get { return _productSerialNumber; }
            set { SetProperty(ref _productSerialNumber, value); }
        }

        private string _productName;
        public string ProductName
        {
            get { return _productName; }
            set { SetProperty(ref _productName, value); }
        }

        private string _problemType;
        public string ProblemType
        {
            get { return _problemType; }
            set { SetProperty(ref _problemType, value); }
        }

        private ImageSource _imageOne = "ic_camera";
        public ImageSource ImageOne
        {
            get
            {
                return _imageOne;
            }
            set
            {
                SetProperty(ref _imageOne, value);
            }
        }
        private ImageSource _imageTwo = "ic_camera";
        public ImageSource ImageTwo
        {
            get
            {
                return _imageTwo;
            }
            set
            {
                SetProperty(ref _imageTwo, value);
            }
        }
        private ImageSource _imageThree = "ic_camera";
        public ImageSource ImageThree
        {
            get
            {
                return _imageThree;
            }
            set
            {
                SetProperty(ref _imageThree, value);
            }
        }

        public ICommand OnProductNameDropDownCommand { get; set; }
        public ICommand OnProblemTypeDropDownCommand { get; set; }
        public ICommand FilePickerImageOneCommand { get; set; }
        public ICommand FilePickerImageTwoCommand { get; set; }
        public ICommand FilePickerImageThreeCommand { get; set; }
        public ICommand OnSubmitCommand { get; set; }

        public NewServiceRequestViewModel()
        {
            InitCommand();
            SetDropDownDefultValue();
            SetProductName();
            SetProductProblem();
        }

        private void SetDropDownDefultValue()
        {
            Title = AppResource.TitleNewServiceRequest;
            ProductName = AppResource.LabelSelectTheProduct;
            ProblemType = AppResource.LabelTypeOfProblem;
            ProductSerialNumber= AppResource.LabelProductSerialNumber;
        }
        private void InitCommand()
        {

            OnProductNameDropDownCommand = new Command(OnProductNameDropDownClick);
            OnProblemTypeDropDownCommand = new Command(OnProblemTypeDropDownClick);

            FilePickerImageOneCommand = new Command(FilePickerOneClick);
            FilePickerImageTwoCommand = new Command(FilePickerTwoClick);
            FilePickerImageThreeCommand = new Command(FilePickerThreeClick);
            OnSubmitCommand = new Command(OnSubmitClick);
        }

        private void FilePickerThreeClick(object obj)
        {
            IsImageThree = true;
            IsImageTwo = false;
            IsImageOne = false;
                
            ImageThree = "ic_camera";
            SetFilePicker();
        }

        private void FilePickerTwoClick(object obj)
        {
            ImageTwo = "ic_camera";
            IsImageThree = false;
            IsImageTwo = true;
            IsImageOne = false;
            SetFilePicker();
        }

        private void FilePickerOneClick(object obj)
        {
            ImageOne = "ic_camera";
            IsImageThree = false;
            IsImageTwo = false;
            IsImageOne = true;
            SetFilePicker();
            
        }

        private void OnProblemTypeDropDownClick(object obj)
        {
            IsProblemTypeDDOpen = !IsProblemTypeDDOpen;
            SetDropDown(_ProductProblems, DropDownType.TypeProblem);
        }

        private void OnProductNameDropDownClick(Object obj)
        {
            IsProductNameDDOpen = !IsProductNameDDOpen;
            SetDropDown(_products, DropDownType.SelectedProduct);
        }

        private async void SetDropDown(List<DropDownModel> dataSource, DropDownType dropdowntype)
        {
            var dropDown = new DropDownPage(dataSource,dropdowntype);
            dropDown.ItemSelectionClick += DropDown_ItemSelectionClick;
            await PopupNavigation.Instance.PushAsync(dropDown, false);
        }
      
        private void SetProductName()
        {
            _products = new List<DropDownModel>
            {
                new DropDownModel() { ItemID = 1, ItemName = "FASD1 Starter ",IsCheckBoxItem=false },
                new DropDownModel() { ItemID = 1, ItemName = "FASD2 Starter",IsCheckBoxItem=false }
            };
        }
       
        private void SetProductProblem()
        {
            _ProductProblems = new List<DropDownModel>
            {
                new DropDownModel() { ItemID = 1, ItemName = "Coil Burnt" ,IsCheckBoxItem=true},
                new DropDownModel() { ItemID = 1, ItemName = "Weld" ,IsCheckBoxItem=true},
                new DropDownModel() { ItemID = 1, ItemName = "Burnt" ,IsCheckBoxItem=true },
                new DropDownModel() { ItemID = 1, ItemName = "Nuisance tripping" ,IsCheckBoxItem=true},
                new DropDownModel() { ItemID = 1, ItemName = "Accessories Fitment" ,IsCheckBoxItem=true},
                new DropDownModel() { ItemID = 1, ItemName = "Other problem" ,IsCheckBoxItem=true}
            };
        }

        private void DropDown_ItemSelectionClick(object sender, EventArgs e)
        {
            DropDownEventArg dropEventArgs = ((DropDownEventArg)e);
            if (dropEventArgs?.SelectedData != null)
            {
                switch (dropEventArgs.DropDownType)
                {
                    case DropDownType.SelectedProduct:
                        ProductName = dropEventArgs.SelectedData.ItemName;
                        ProductSerialNumber = "0202020202";
                        IsProductNameDDOpen = false;
                        break;
                    case DropDownType.TypeProblem:
                        ProblemType = dropEventArgs.SelectedData.ItemName;
                        IsProblemTypeDDOpen = false;
                        break;
                 
                }
            }
        }

        private async void OnSubmitClick(object obj)
        {
            await ShellRoutingService.Instance.GoBack();
        }

       

        private async void SetFilePicker()
        {
            await PickAndShow();
        }

    
        private async Task<FileResult> PickAndShow()
        {
            try
            {

                var options = GetPickerType();
                var result = await FilePicker.PickAsync(options);
                if (result != null)
                {
                    string fileName = $"File Name: {result.FileName}";
                    if (result.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) ||
                        result.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase)||
                             result.FileName.EndsWith("pdf", StringComparison.OrdinalIgnoreCase))
                    {
                        var stream = await result.OpenReadAsync();

                        if(IsImageOne)
                        {
                            ImageOne = ImageSource.FromStream(() => stream);
                        }
                        else if(IsImageTwo)
                        {
                            ImageTwo = ImageSource.FromStream(() => stream);
                        }
                        else if(IsImageThree)
                        {
                            ImageThree = ImageSource.FromStream(() => stream);
                        }
                        
                       
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

        private PickOptions GetPickerType()
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
            return options;
        }
    }

   
}
