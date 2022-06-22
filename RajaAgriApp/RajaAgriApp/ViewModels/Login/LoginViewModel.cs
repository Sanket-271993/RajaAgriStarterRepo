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
using Xamarin.Forms;

namespace RajaAgriApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private ILoginController _loginController;
        private System.Timers.Timer _timer;
        private int _countSeconds=30;
        private string _recentOTP;
     
        private bool _isOTPVerify;
        public bool IsOTPVerify
        {
            get { return _isOTPVerify; }
            set { SetProperty(ref _isOTPVerify, value); }
        }

        private bool _isPhoneNumber;
        public bool IsPhoneNumber
        {
            get { return _isPhoneNumber; }
            set { SetProperty(ref _isPhoneNumber, value); }
        }

        private string _phoneNumber = string.Empty;
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { SetProperty(ref _phoneNumber, value); }
        }

        private int _otp = -1;
        public int OTP
        {
            get { return _otp; }
            set { SetProperty(ref _otp, value); }
        }

        private int _resendSecond=30;
        public int ResendSecond
        {
            get { return _resendSecond; }
            set { SetProperty(ref _resendSecond, value); }
        }

      
        public ICommand GetOTPCommand { get; set; }
        
        public LoginViewModel()
        {
            Title = AppResource.LoginTitle;
            InitCommand();
            InitController();
            SetdefultAsLogin();
        }

        private void InitController()
        {
            _loginController= AppLocator.Instance.GetInstance<ILoginController>();
        }

        private void InitCommand()
        {
            GetOTPCommand = new Command(OnGetOTPClick);
        }

        public void SetdefultAsLogin()
        {
            IsOTPVerify = false;
            IsPhoneNumber = true;
            PhoneNumber = String.Empty;
            OTP = -1;
        }

        /// <summary>
        /// Get OTP Click
        /// </summary>
        /// <param name="obj"></param>
        private void OnGetOTPClick(object obj)
        {
            SetTokenServiceCall();
            //if(!IsOTPVerify)
            //{
            //    GetOTP();
            //}
            //else
            //{
            //    VerifyOTP();
            //}

        }

        private async void SetTokenServiceCall()
        {
            try
            {
                if (IsConnected)
                {
                    LoginRequestModel loginRequestModel = new LoginRequestModel()
                    {
                        MobileNo = PhoneNumber.ToString()
                    };
                    AppIndicater.Instance.Show();
                    var response = await _loginController.GetLoginAsync(loginRequestModel);
                    AppIndicater.Instance.Dismiss();
                    if (response != null && !string.IsNullOrEmpty(response.access_token))
                    {
                        SaveFarmerMobileNumber(PhoneNumber);
                        CheckUserIsRegister();
                    }

                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        private void SaveFarmerMobileNumber(string MobileNumber)
        {
            if (!string.IsNullOrEmpty(MobileNumber))
            {
                StorageServiceProvider.Instance.Write(AppConstant.FarmerMobileNumber, MobileNumber, true);
            }
        }

        public void GetOTP()
        {
            IsOTPVerify = true;
            IsPhoneNumber = false;
            OTP = -1;

            GenreateOTP();
            SetResendSecond();
        }

        public void VerifyOTP()
        {
            if(_recentOTP==OTP.ToString())
            {
                PhoneNumber = String.Empty;
                SetOTPSuccessFullPopup();
            }
            else
            {
                //Set fail Popup 
            }
        }
       

        private async void SetOTPSuccessFullPopup()
        {
            var popup = new OTPSuccessPage(AppResource.LabelOTPVerified);
            popup.OkClick += Popup_OkClick;
            await PopupNavigation.Instance.PushAsync(popup);
        }

        private async void Popup_OkClick(object sender, EventArgs e)
        {
            await ShellRoutingService.Instance.NavigateTo($"{nameof(RegistrationPage)}");
        }


        private async void GoToRegistrationPage()
        {
            await ShellRoutingService.Instance.NavigateTo($"{nameof(RegistrationPage)}");
        }
        private async void GoToHomePage()
        {
            await ShellRoutingService.Instance.NavigateTo($"{nameof(HomePage)}");
        }

        private async Task<bool> GetIsFarmerRegister()
        {
            bool isRegister = false;
            string result=await StorageServiceProvider.Instance.Read(AppConstant.IsRegistered, false);
            if(!string.IsNullOrEmpty(result))
            {
                isRegister = Convert.ToBoolean(result);
            }
            

            return isRegister;
        }


        private async void CheckUserIsRegister()
        {
            var result = await GetIsFarmerRegister();
            if(result)
            {
                GoToHomePage();
            }
            else
            {
                GoToRegistrationPage();
            }
        }
        private void GenreateOTP()
        {
            //Random generator = new Random();
            //String randomotp = generator.Next(0, 9999).ToString("D4");
            //_recentOTP = randomotp;
            _recentOTP = "1234";
            //Console.WriteLine("New Genreated OTP:" + _recentOTP);
        }


       /// <summary>
       /// Set Resend OTP Second
       /// </summary>
        private void SetResendSecond()
        {
            _timer = new System.Timers.Timer
            {
                //Trigger event every second
                Interval = 1000
            };
            _timer.Elapsed += OnTimedEvent;
            //count down 5 seconds
            _countSeconds = 30;

            _timer.Enabled = true;
        }

        /// <summary>
        /// Timer event for second
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTimedEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            _countSeconds--;
            ResendSecond = _countSeconds;


            if (_countSeconds == 0)
            {
                SetdefultAsLogin();
                _timer.Stop();
            }
        }
    }
}
