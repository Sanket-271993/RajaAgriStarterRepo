using NavistarOCCApp.Common;
using RajaAgriApp.Pages;
using RajaAgriApp.PopUpPages;
using RajaAgriApp.Resources;
using Rg.Plugins.Popup.Services;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace RajaAgriApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
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

        private int _phoneNumber = -1;
        public int PhoneNumber
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
            SetdefultAsLogin();
        }

        private void InitCommand()
        {
            GetOTPCommand = new Command(OnGetOTPClick);
        }

        public void SetdefultAsLogin()
        {
            IsOTPVerify = false;
            IsPhoneNumber = true;
            PhoneNumber =-1;
            OTP = -1;
        }

        /// <summary>
        /// Get OTP Click
        /// </summary>
        /// <param name="obj"></param>
        private void OnGetOTPClick(object obj)
        {
            if(!IsOTPVerify)
            {
                GetOTP();
            }
            else
            {
                VerifyOTP();
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
                PhoneNumber = -1;
                SetOTPSuccessFullPopup();
            }
            else
            {
                //Set fail Popup 
            }
        }
       

        private async void SetOTPSuccessFullPopup()
        {
            var popup = new OTPSuccessPage();
            popup.OkClick += Popup_OkClick;
            await PopupNavigation.Instance.PushAsync(popup);
        }

        private async void Popup_OkClick(object sender, EventArgs e)
        {
            await ShellRoutingService.Instance.NavigateTo($"{nameof(RegistrationPage)}");
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
