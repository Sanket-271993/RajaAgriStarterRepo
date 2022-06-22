using NavistarOCCApp.Common;
using RajaAgriApp.Common;
using RajaAgriApp.Controller;
using RajaAgriApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace RajaAgriApp.ViewModels
{
    
   
    public class ReviewViewModel : BaseViewModel
    {
        private IReviewController _reviewController;


        private string _productImageBase64;
        public string ProductImageBase64
        {
            get { return _productImageBase64; }
            set { 
                SetProperty(ref _productImageBase64, value);
              //  _productImage = GetImage(value);
            }
        }

        private ImageSource _productImage;
        public ImageSource ProductImage
        {
            get { return _productImage; }
            set
            {
              
                SetProperty(ref _productImage, value);
               
            }
        }

        private int _productId;
        public int ProductId
        {
            get { return _productId; }
            set { SetProperty(ref _productId, value); }
        }


        private int _productRating;
        public int ProductRating
        {
            get { return _productRating; }
            set { SetProperty(ref _productRating, value); }
        }

        private string _productName;
        public string ProductName
        {
            get { return _productName; }
            set { SetProperty(ref _productName, value); }
        }


        private string _comments;
        public string Comments
        {
            get { return _comments; }
            set { SetProperty(ref _comments, value); }
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
            IsBack = true;
            IsTranslateVisable = true;
            SetProductDetails();
            InitController();
            InitCommand();
        }

        private void InitCommand()
        {
            OnStarOneCommand = new Command(OnStarOneClick);
            OnStarTwoCommand = new Command(OnStarTwoClick);
            OnStarThreeCommand = new Command(OnStarThreeClick);
            OnStarFourCommand = new Command(OnStarFourClick);
            OnStarFiveCommand = new Command(OnStarFiveClick);
            OnSubmitCommand = new Command(OnSubmitClick);
        }

        private void InitController()
        {
            _reviewController = AppLocator.Instance.GetInstance<IReviewController>();
        }

        private void OnSubmitClick(object obj)
        {
            
            SetProductReviewSubmitServiceCall();
            
        }

        private void OnStarFiveClick(object obj)
        {
           
            IsStarFive = !IsStarFive;
            IsStarFour = IsStarFive;
            IsStarThree = IsStarFive;
            IsStarTwo = IsStarFive;
            IsStarOne = IsStarFive;

            ProductRating = 5;
        }

        private void OnStarFourClick(object obj)
        {
            SetAllStarUnselected();
            IsStarFour = !IsStarFour;
            IsStarThree = IsStarFour;
            IsStarTwo = IsStarFour;
            IsStarOne = IsStarFour;
            ProductRating = 4;
        }

        private void OnStarThreeClick(object obj)
        {
            SetAllStarUnselected();
            IsStarThree = !IsStarThree;
            IsStarTwo = IsStarThree;
            IsStarOne = IsStarThree;

            ProductRating = 3;
        }

        private void OnStarTwoClick(object obj)
        {
            SetAllStarUnselected();
            IsStarTwo = !IsStarTwo;
            IsStarOne = IsStarTwo;
            ProductRating = 2;
        }

        private void OnStarOneClick(object obj)
        {
            SetAllStarUnselected();
            IsStarOne = !IsStarOne;
            ProductRating = 1;
        }

        
        private void SetAllStarUnselected()
        {
            IsStarOne = false;
            IsStarTwo = false;
            IsStarThree = false;
            IsStarFour = false;
            IsStarFive = false;
        }

       

        private void SetProductDetails()
        {
            if(ProductDetails!=null)
            {
                ProductId = ProductDetails.ProductID;
                ProductName = ProductDetails.ProductName;
                ProductImage = GetImage(ProductDetails.Image1);
            }
        }

        private async void SetProductReviewSubmitServiceCall()
        {
            try
            {
                if (IsConnected)
                {
                    bool isValid = Validate();
                    if (isValid)
                    {
                        var requestModel = GetReviewRequsetModel();
                        AppIndicater.Instance.Show();
                        var response = await _reviewController.PostSubmitProductRating(requestModel);
                        AppIndicater.Instance.Dismiss();
                        if (response != null && response.IsSubmitted)
                        {
                         
                            SetSnackBarMessage(response.Message);
                             await Task.Delay(3000);
                            await ShellRoutingService.Instance.GoBack();
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(response.Message))
                            {
                                SetAlertPopup(response.Message);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private ImageSource GetImage(string image)
        {

            ImageSource _productImage;

            _productImage = ImageSource.FromStream(
                () => new MemoryStream(Convert.FromBase64String(image)));

            return _productImage;
        }

        private ReviewRequestModel GetReviewRequsetModel()
        {
            var requestModel = new ReviewRequestModel()
            {
                ProductId = ProductId,
                ProductRating = ProductRating,
                Comments = Comments,
                RatingDate = DateTime.Now
            };
            return requestModel;
        }

        private bool Validate()
        {
            // perform test for each field on page
            if (ProductRating==0)
            {
                SetAlertPopup("Please give  the Product Rating !");
                return false;
            }
            
            return true;
        }
    }
}
