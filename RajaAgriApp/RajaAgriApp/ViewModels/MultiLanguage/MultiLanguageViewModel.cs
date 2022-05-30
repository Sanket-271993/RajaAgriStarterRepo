using System;
using NavistarOCCApp.Common;
using RajaAgriApp.Pages;
using RajaAgriApp.Resources;
using Xamarin.Forms;

namespace RajaAgriApp.ViewModels
{
    public class MultiLanguageViewModel : BaseViewModel
    {
        
        private bool _isGujarati;
        public bool IsGujarati
        {
            get { return _isGujarati; }
            set { SetProperty(ref _isGujarati, value); }
        }

        private bool _isEnglish;
        public bool IsEnglish
        {
            get { return _isEnglish; }
            set { SetProperty(ref _isEnglish, value); }
        }

        private bool _isMarathi;
        public bool IsMarathi
        {
            get { return _isMarathi; }
            set { SetProperty(ref _isMarathi, value); }
        }

        private bool _isPanjabi;
        public bool IsPanjabi
        {
            get { return _isPanjabi; }
            set { SetProperty(ref _isPanjabi, value); }
        }

        private bool _isHindi;
        public bool IsHindi
        {
            get { return _isHindi; }
            set { SetProperty(ref _isHindi, value); }
        }

        public Command SubmitButtonCommand { get; set; }
        public Command OnEnglishCommand { get; set; }
        public Command OnHindiCommand { get; set; }
        public Command OnMarathiCommand { get; set; }
        public Command OnGujaratiCommand { get; set; }
        public Command OnPanjabiCommand { get; set; }

        public MultiLanguageViewModel()
        {
            InitCommand();
            SetTitle();
        }

        private void SetTitle()
        {
            IsEnglish = true;
            Title = AppResource.TitleLanguagePage;
            IsTranslateVisable = false;
        }

        private void InitCommand()
        {
            SubmitButtonCommand = new Command(OnSubmitClicked);
            OnEnglishCommand = new Command(OnEnglishClick);
            OnHindiCommand = new Command(OnHindiClick);
            OnMarathiCommand = new Command(OnMarathiClick);
            OnGujaratiCommand = new Command(OnGujaratiClick);
            OnPanjabiCommand = new Command(OnPanjabiClick);
        }

        private void SetAllLanguageFalse()
        {
            IsHindi = false;
            IsGujarati = false;
            IsMarathi = false;
            IsEnglish = false;
            IsPanjabi = false;
        }
        private void OnPanjabiClick(object obj)
        {
            SetAllLanguageFalse();
            IsPanjabi = true;
        }

        private void OnGujaratiClick(object obj)
        {
            SetAllLanguageFalse();
            IsGujarati = true;
        }

        private void OnMarathiClick(object obj)
        {
            SetAllLanguageFalse();
            IsMarathi = true;
        }

        private void OnHindiClick(object obj)
        {
            SetAllLanguageFalse();
            IsHindi = true;
        }

        private void OnEnglishClick(object obj)
        {
            SetAllLanguageFalse();
            IsEnglish = true;
        }

      
        private async void OnSubmitClicked()
        {
            if(IsLoginNavigation)
            {
                IsLoginNavigation = false;
                await ShellRoutingService.Instance.NavigateTo($"{nameof(LoginPage)}");
            }
            else
            {
                await ShellRoutingService.Instance.GoBack();
            }
        }
    }
}
