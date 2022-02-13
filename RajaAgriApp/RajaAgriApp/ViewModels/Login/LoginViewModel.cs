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

        public ICommand LoginCommand { get; set; }
        public ICommand GetOTPCommand { get; set; }
        
        public LoginViewModel()
        {
            Title = AppResource.LoginTitle;
            InitCommand();
            SetdefultAsLogin();
        }

        private void InitCommand()
        {
            LoginCommand = new Command(OnLoginClicked);
            GetOTPCommand = new Command(OnGetOTPClick);
           
        }

        private void SetdefultAsLogin()
        {
            IsOTPVerify = false;
            IsPhoneNumber = true;

        }

        private void OnMultiLanguageClick(object obj)
        {
            //
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
        private void GetOTP()
        {
            IsOTPVerify = true;
            IsPhoneNumber = false;

            GenreateOTP();
            SetResendSecond();
        }

        private void VerifyOTP()
        {
            if(_recentOTP==OTP.ToString())
            {
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

        private void Popup_OkClick(object sender, EventArgs e)
        {
            //Navigation new page
        }

        private void GenreateOTP()
        {
            Random generator = new Random();
            String randomotp = generator.Next(0, 9999).ToString("D4");
            _recentOTP = randomotp;
            Console.WriteLine("New Genreated OTP:" + _recentOTP);
        }


        private async void OnLoginClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
           await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
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
