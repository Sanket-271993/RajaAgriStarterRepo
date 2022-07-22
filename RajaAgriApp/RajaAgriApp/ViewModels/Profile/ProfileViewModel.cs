using NavistarOCCApp.Common;
using RajaAgriApp.Common;
using RajaAgriApp.Controller;
using RajaAgriApp.Models;
using RajaAgriApp.Pages;
using RajaAgriApp.Resources;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using XF.Material.Forms.UI.Dialogs;
using XF.Material.Forms.UI.Dialogs.Configurations;

namespace RajaAgriApp.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {
        private IProfileController _profileController;
        private string ProfileImageBase64;

        private ImageSource _userImage = "ic_defult_user";

        public ImageSource UserImage
        {
            get { return _userImage; }
            set { SetProperty(ref _userImage, value); }
        }


        private string _userName;

        public String UserName
        {
            get { return _userName; }
            set { SetProperty(ref _userName, value); }
        }

        private string _phoneNumber;

        public String PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                SetProperty(ref _phoneNumber, value);
            }
        }

        private string _address;

        public String Address
        {
            get { return _address; }
            set
            {
                SetProperty(ref _address, value);
            }
        }
        public ICommand OnProfilePicEditCommand { get; set; }
        public ICommand OnNotificationCommand { get; set; }
        public ICommand OnProductRegistrationCommand { get; set; }
        public ICommand OnOrderHistoryCommand { get; set; }
        public ICommand OnLanguageCommand { get; set; }
        public ICommand OnFAQCommand { get; set; }
        public ICommand OnServiceRequestCommand { get; set; }
        public ICommand OnLogOutCommand { get; set; }
        public ProfileViewModel()
        {
            Title = AppResource.TitleBack;
            IsTranslateVisable = false;
            InitCommand();

        }


        private void InitCommand()
        {
            OnProfilePicEditCommand = new Command(OnProfilePicEditClick);
            OnNotificationCommand = new Command(OnNotificationClick);
            OnProductRegistrationCommand = new Command(OnProductRegistrationClick);
            OnOrderHistoryCommand = new Command(OnOrderHistoryClick);
            OnLanguageCommand = new Command(OnLanguageClick);
            OnFAQCommand = new Command(OnFAQClick);
            OnServiceRequestCommand = new Command(OnServiceRequestClick);
            OnLogOutCommand = new Command(OnLogOutClick);

            _profileController = AppLocator.Instance.GetInstance<IProfileController>();
        }

        private void OnLogOutClick(object obj)
        {
            SetLogouTPopup();
        }

        private async void OnServiceRequestClick(object obj)
        {
            await ShellRoutingService.Instance.NavigateTo($"{nameof(ServiceRequestPage)}");
        }

        private async void OnFAQClick(object obj)
        {
            await ShellRoutingService.Instance.NavigateTo($"{nameof(FAQCategoryPage)}");
        }

        private async void OnOrderHistoryClick(object obj)
        {
            await ShellRoutingService.Instance.NavigateTo($"{nameof(OrderHistoryPage)}");
        }

        private async void OnLanguageClick(object obj)
        {
            await ShellRoutingService.Instance.NavigateTo($"{nameof(MultiLanguage)}");
        }

        private async void OnProductRegistrationClick(object obj)
        {
            await ShellRoutingService.Instance.NavigateTo($"{nameof(ProductRegistrationPage)}");
        }

        private void OnNotificationClick(object obj)
        {

        }

        private void OnProfilePicEditClick(object obj)
        {
            SetFilePicker();
            //SetProfileUpdateServiceCall();
        }

        private FarmerDetail _farmerDetails;

        public async void GetProfileServiceCall()
        {
            try
            {
                if (IsConnected)
                {

                    AppIndicater.Instance.Show();
                    var response = await _profileController.GetProfile();
                    AppIndicater.Instance.Dismiss();
                    if (response != null && response.FarmerDetails?.Count > 0)
                    {
                        _farmerDetails = response.FarmerDetails[0];
                        if (_farmerDetails != null)
                        {
                            SetUserDetails();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void SetUserDetails()
        {
            UserName = _farmerDetails.FarmerName;
            PhoneNumber = _farmerDetails.PhoneNumber;
            Address = _farmerDetails.Location;
            UserImage = _farmerDetails.UserImage;
        }

        public async void SetProfileUpdateServiceCall(string ProfileImageBase64)
        {
            try
            {
                if (IsConnected)
                {
                    var request = new ProfileImageRequstModel()
                    {
                        Image = ProfileImageBase64,
                    };

                    AppIndicater.Instance.Show();
                    var response = await _profileController.PostProfileImageUpdate(request);
                    AppIndicater.Instance.Dismiss();
                    //if (response != null && response.Distributors?.Count > 0)
                    //{
                    //    Dealers = new ObservableCollection<DealerModel>(response.Distributors);
                    //}
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        private async void SetFilePicker()
        {
            await PickAndShow(PickOptions.Images);
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

                        var bytes = new byte[stream.Length];
                        await stream.ReadAsync(bytes, 0, (int)stream.Length);
                        ProfileImageBase64 = System.Convert.ToBase64String(bytes);


                        UserImage = ImageSource.FromStream(
                       () => new MemoryStream(Convert.FromBase64String(ProfileImageBase64)));

                        SetProfileUpdateServiceCall(ProfileImageBase64);
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


        private async void SetLogOut()
        {
            RemoveToken();
            await ShellRoutingService.Instance.NavigateTo($"{nameof(LoginPage)}");
        }

        private void RemoveToken()
        {
            StorageServiceProvider.Instance.Clear(AppConstant.Access_Token, true);
        }

        private async void SetLogouTPopup()
        {
            MaterialAlertDialogConfiguration configuration = new MaterialAlertDialogConfiguration()
            {
                TintColor = Color.LightGreen
            };
            var result= await MaterialDialog.Instance.ConfirmAsync(message: "Are you sure you want to Logout?",
                                    title: "Confirm",
                                    confirmingText: "Yes",
                                    dismissiveText: "No", configuration);

            if(result.Value)
            {
                SetLogOut();
            }
            
        }
    }
}
