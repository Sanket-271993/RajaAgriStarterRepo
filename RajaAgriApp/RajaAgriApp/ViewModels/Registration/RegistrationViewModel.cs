using NavistarOCCApp.Common;
using RajaAgriApp.Common;
using RajaAgriApp.Controller;
using RajaAgriApp.Models;
using RajaAgriApp.Pages;
using RajaAgriApp.PopUpPages;
using RajaAgriApp.Resources;
using Rg.Plugins.Popup.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using XF.Material.Forms.UI.Dialogs;
using XF.Material.Forms.UI.Dialogs.Configurations;

namespace RajaAgriApp.ViewModels
{
    public class RegistrationViewModel : BaseViewModel
    {
        private IFarmerRegisterController _farmerRegisterController;

        private string _name;

        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private string _pinCode;

        public string PinCode
        {
            get { return _pinCode; }
            set { SetProperty(ref _pinCode, value); }
        }

        private string _landMark;

        public string LandMark
        {
            get { return _landMark; }
            set { SetProperty(ref _landMark, value); }
        }


        private string _adharCardAddress;

        public string AdharCardAddress
        {
            get { return _adharCardAddress; }
            set { SetProperty(ref _adharCardAddress, value); }
        }


        private string  _userImageBase64 ;

       

        private ImageSource _imageSource = "ic_camera";

        public ImageSource FileUplodeImageSource
        {
            get => _imageSource;
            set => SetProperty(ref _imageSource, value);
        }

        public bool _isRegisterValidData;
        public bool IsRegisterValidData
        {
            get => _isRegisterValidData;
            set => SetProperty(ref _isRegisterValidData, value);
        }

        public ICommand FilePickerCommand { get; set; }
        public ICommand OnSubmitCommand { get; set; }

        public RegistrationViewModel()
        {
            Title = AppResource.TitleRegistrationPage;
            _farmerRegisterController = AppLocator.Instance.GetInstance<IFarmerRegisterController>();
            InitCommand();
        }

        private void InitCommand()
        {
            FilePickerCommand = new Command(FilePickerClick);
            OnSubmitCommand = new Command(OnSubmitClick);
        }


        private void OnSubmitClick(object obj)
        {
            bool isValid = Validate();
            if (isValid)
            {
                IsRegisterValidData = true;
                SetFarmerReqgistrationServiceCall();
            }
            else
            {
                IsRegisterValidData = false;
            }
            // SetOTPSuccessFullPopup();
        }

        private bool Validate()
        {
            // perform test for each field on page
            if (string.IsNullOrEmpty(Name))
            {
                SetAlertPopup("Please enter the Name!");
                return false;
            }
            else if (string.IsNullOrEmpty(PinCode))
            {
                SetAlertPopup("Please enter the PinCode!");
                return false;
            }
            else if (string.IsNullOrEmpty(LandMark))
            {
                SetAlertPopup("Please enter the LandMark!");
                return false;
            }
            return true;
        }

        private async void SetFarmerReqgistrationServiceCall()
        {
            try
            {
                if (IsConnected)
                {
                    var requestData = GetRequestData();
                    AppIndicater.Instance.Show();
                    var response =await _farmerRegisterController.PostFarmerRegister(requestData);
                    AppIndicater.Instance.Dismiss();
                    if (response != null && response.IsRegistered)
                    {
                        SaveFarmerRegister(true);
                        SetOTPSuccessFullPopup();
                    }
                    else
                    {
                        // App Close
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


        private void SaveFarmerRegister(bool isRegistered)
        {
           
           StorageServiceProvider.Instance.Write(AppConstant.IsRegistered, isRegistered.ToString(), false);
            
        }

        private RegisterRequestModel GetRequestData()
        {

            RegisterRequestModel registerRequest = new RegisterRequestModel
            {
                PhoneNumber = MobileNumber,
                AadhaarCardAddress = AdharCardAddress,
                Pincode = PinCode,
                Landmark = LandMark,
                FarmerName = Name,
                Image = _userImageBase64
            };

            return registerRequest;

        }

        private async void SetOTPSuccessFullPopup()
        {
            var popup = new OTPSuccessPage(AppResource.PopUpTitleRegistration);
            popup.OkClick += Popup_OkClick;
            await PopupNavigation.Instance.PushAsync(popup);
        }

        private async void Popup_OkClick(object sender, EventArgs e)
        {
            await ShellRoutingService.Instance.NavigateTo($"{nameof(HomePage)}");
            AppIndicater.Instance.Dismiss();
        }




        private void FilePickerClick(object obj)
        {
            SetFilePicker();
        }

        private async void SetFilePicker()
        {
            try
            {
                await PickAndShow(PickOptions.Images);
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Exception choosing file: " + e.ToString());
            }
        }

        async Task<FileResult> PickAndShow(PickOptions options)
        {
            try
            {
                var result = await FilePicker.PickAsync(options);
                if (result != null)
                {
                    string fileName = $"File Name: {result.FileName}";
                    if (result.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) ||
                        result.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase))
                    {
                        var stream = await result.OpenReadAsync();
                     //   _userImageBase64 = Convert.ToBase64String(stream);
                           // 
                        FileUplodeImageSource = ImageSource.FromStream(() => stream);
                        System.Console.WriteLine("File name chosen: " + fileName);
                        System.Console.WriteLine("File data: " + stream);
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
    }
}
