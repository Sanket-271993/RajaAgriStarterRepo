using NavistarOCCApp.Common;
using RajaAgriApp.Common;
using RajaAgriApp.Controller;
using RajaAgriApp.Models;
using RajaAgriApp.PopUpPages;
using RajaAgriApp.Resources;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace RajaAgriApp.ViewModels
{
    public class NewServiceRequestViewModel:BaseViewModel
    {

        private INewServicRequestController _newServicRequestController;
        public ObservableCollection<DropDownModel> Products { get; set; }
        List<DropDownModel> _products;
        List<DropDownModel> _ProductProblems;

        private string ImageOneBase64;
        private string ImageTwoBase64;
        private string ImageThreeBase64;
        private int _productID;
        private int _ProblemTypeID;

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
            _newServicRequestController = AppLocator.Instance.GetInstance<INewServicRequestController>();
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
      
        
       
     

        private void DropDown_ItemSelectionClick(object sender, EventArgs e)
        {
            DropDownEventArg dropEventArgs = ((DropDownEventArg)e);
            if (dropEventArgs?.SelectedData != null)
            {
                switch (dropEventArgs.DropDownType)
                {
                    case DropDownType.SelectedProduct:
                        ProductName = dropEventArgs.SelectedData.ItemName;
                        ProductSerialNumber = dropEventArgs.SelectedData.SerialNumber;
                        _productID = dropEventArgs.SelectedData.ItemID;
                        IsProductNameDDOpen = false;
                        break;
                    case DropDownType.TypeProblem:
                        ProblemType = dropEventArgs.SelectedData.ItemName;
                        _ProblemTypeID = dropEventArgs.SelectedData.ItemID;
                        IsProblemTypeDDOpen = false;
                        break;
                 
                }
            }
        }

        private  void OnSubmitClick(object obj)
        {
            NewRequestServiceCall();
        }

        private async void NewRequestServiceCall()
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

                        var response = await _newServicRequestController.PostProductRegistration(request);
                        AppIndicater.Instance.Dismiss();
                        if (response != null && response.IsNew)
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
        private NewServiceRequestModel GetRequestModel()
        {
            var request = new NewServiceRequestModel();
            request.ProductRegistrationId = _productID;
            request.TypeofProblem = _ProblemTypeID;
            request.Image1 = ImageOneBase64;
            request.Image2 = ImageTwoBase64;
            request.Image3 = ImageThreeBase64;
            
            return request;
        }

        private bool IsValidData()
        {
            if (!string.IsNullOrEmpty(ProductName) && ProductName.Equals(AppResource.LabelSelectTheProduct))
            {
                SetAlertPopup("Please Select Product Name");
                return false;
            }
            else if (!string.IsNullOrEmpty(ProblemType) && ProductName.Equals(AppResource.LabelTypeOfProblem))
            {
                SetAlertPopup("Please Select Type of problem");
                return false;
            }
           

            return true;
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
                        var bytes = new byte[stream.Length];
                        await stream.ReadAsync(bytes, 0, (int)stream.Length);

                        
                        if (IsImageOne)
                        {
                           
                            ImageOneBase64= System.Convert.ToBase64String(bytes);
                            ImageOne = ImageSource.FromStream(() => new MemoryStream(Convert.FromBase64String(ImageOneBase64)));
                        }
                        else if(IsImageTwo)
                        {
                            ImageTwoBase64 = System.Convert.ToBase64String(bytes);
                            ImageTwo = ImageSource.FromStream(() => new MemoryStream(Convert.FromBase64String(ImageTwoBase64)));
                        }
                        else if(IsImageThree)
                        {
                            ImageThreeBase64 = System.Convert.ToBase64String(bytes);
                            ImageThree = ImageSource.FromStream(() => new MemoryStream(Convert.FromBase64String(ImageThreeBase64)));
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
                PickerTitle = "Please select  file",
                FileTypes = customFileType,
            };
            return options;
        }

        public async void SetProductServiceCall()
        {
            try
            {
                if (IsConnected)
                {

                    AppIndicater.Instance.Show();
                    var response = await _newServicRequestController.GetHome();
                    
                    if (response != null && response.Products?.Count > 0)
                    {

                        SetProductName(response.Products);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
              //  AppIndicater.Instance.Dismiss();
            }
        }

        private void SetProductName(List<ProductModel> products)
        {
            _products = new List<DropDownModel>();
            foreach (var product in products)
            {
                _products.Add(new DropDownModel() { ItemID = product.ProductID,SerialNumber= product.SerialNumber,
                    ItemName = product.ProductName, IsCheckBoxItem = false });
            }
            
            
        }

        public async void SetProblemTypeServiceCall()
        {
            try
            {
                if (IsConnected)
                {

                    
                    var response = await _newServicRequestController.GetTypeOfProblem();
                    AppIndicater.Instance.Dismiss();
                    if (response != null && response.TypeOfProblems?.Count > 0)
                    {

                        SetProductProblem(response.TypeOfProblems);
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
        private void SetProductProblem(List<TypeOfProblemModel> typeOfProblems)
        {
            _ProductProblems = new List<DropDownModel>();
            foreach (var problem in typeOfProblems)
            {
                _ProductProblems.Add(new DropDownModel() { ItemID = problem.TypeOfProblemID, ItemName = problem.TypeOfProblem, IsCheckBoxItem = true });
            }
            
        }
    }

   
}
