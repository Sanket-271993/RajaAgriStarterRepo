using NavistarOCCApp.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace RajaAgriApp.ViewModels
{
    public class ReviewViewModel : BaseViewModel
    {

        private string _productName;

        public string ProductName
        {
            get { return _productName; }
            set { SetProperty(ref _productName,value); }
        }

        private bool _isStarOne;
        public bool IsStarOne
        {
            get { return _isStarOne; }
            set { SetProperty(ref _isStarOne, value); }
        }

        private bool _isStarTwo;
        public bool IsStarTwo
        {
            get { return _isStarTwo; }
            set { SetProperty(ref _isStarTwo, value); }
        }

        private bool _isStarThree;
        public bool IsStarThree
        {
            get { return _isStarThree; }
            set { SetProperty(ref _isStarThree, value); }
        }

        private bool _isStarFour;
        public bool IsStarFour
        {
            get { return _isStarFour; }
            set { SetProperty(ref _isStarFour, value); }
        }

        private bool _isStarFive;
        public bool IsStarFive
        {
            get { return _isStarFive; }
            set { SetProperty(ref _isStarFive, value); }
        }

        public ICommand OnStarOneCommand { get; set; }
        public ICommand OnStarTwoCommand { get; set; }
        public ICommand OnStarThreeCommand { get; set; }
        public ICommand OnStarFourCommand { get; set; }
        public ICommand OnStarFiveCommand { get; set; }
        public ICommand OnSubmitCommand { get; set; }
        
        public ReviewViewModel()
        {
            Title = "Review";
            IsTranslateVisable = true;
            SetProductDetails();
            InitCommand();
        }

        private void InitCommand()
        {
            OnStarOneCommand = new Command(OnStarOneClick);
            OnStarTwoCommand= new Command(OnStarTwoClick);
            OnStarThreeCommand = new Command(OnStarThreeClick);
            OnStarFourCommand = new Command(OnStarFourClick);
            OnStarFiveCommand = new Command(OnStarFiveClick);
            OnSubmitCommand = new Command(OnSubmitClick);
        }

        private async void OnSubmitClick(object obj)
        {
            await ShellRoutingService.Instance.GoBack();
        }

        private void OnStarFiveClick(object obj)
        {
            IsStarFive = !IsStarFive;
            IsStarFour = IsStarFive;
            IsStarThree = IsStarFive;
            IsStarTwo = IsStarFive;
            IsStarOne = IsStarFive;
        }

        private void OnStarFourClick(object obj)
        {
            SetAllStarUnselected();
            IsStarFour = !IsStarFour;
            IsStarThree = IsStarFour;
            IsStarTwo = IsStarFour;
            IsStarOne = IsStarFour;
        }

        private void OnStarThreeClick(object obj)
        {
            SetAllStarUnselected();
            IsStarThree = !IsStarThree;
            IsStarTwo = IsStarThree;
            IsStarOne = IsStarThree;
        }

        private void OnStarTwoClick(object obj)
        {
            SetAllStarUnselected();
            IsStarTwo = !IsStarTwo;
            IsStarOne = IsStarTwo;
        }

        private void OnStarOneClick(object obj)
        {
            SetAllStarUnselected();
            IsStarOne = !IsStarOne;
        }

        private void SetProductDetails()
        {
            ProductName = "FASD2 Starter";
        }

        private void SetAllStarUnselected()
        {
            IsStarOne = false;
            IsStarTwo = false;
            IsStarThree = false;
            IsStarFour = false;
            IsStarFive = false;
        }

        private void SetAllStarSelected()
        {
            IsStarOne = true;
            IsStarTwo = true;
            IsStarThree = true;
            IsStarFour = true;
            IsStarFive = true;
        }
    }
}
