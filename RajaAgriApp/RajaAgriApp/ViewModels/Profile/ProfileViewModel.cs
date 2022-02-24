using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
using RajaAgriApp.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace RajaAgriApp.ViewModels
{
    public class ProfileViewModel:BaseViewModel
    {
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
            SetUserDetails();
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
        }

        private void OnLogOutClick(object obj)
        {
            
        }

        private void OnServiceRequestClick(object obj)
        {
           
        }

        private void OnFAQClick(object obj)
        {
           
        }

        private void OnOrderHistoryClick(object obj)
        {
            
        }

        private void OnLanguageClick(object obj)
        {
        }

        private void OnProductRegistrationClick(object obj)
        {
            
        }

        private void OnNotificationClick(object obj)
        {
           
        }

        private void OnProfilePicEditClick(object obj)
        {
            SetFilePicker();
        }

        private void SetUserDetails()
        {
            UserName = "Ganesh";
            PhoneNumber = "+91 1234567890";
            Address = "Jodhpur";
        }
        private async void SetFilePicker()
        {
            await  PickAndShow(PickOptions.Images);
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
                        UserImage  = ImageSource.FromStream(() => stream);
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
