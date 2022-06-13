using Newtonsoft.Json;
using RajaAgriApp.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace RajaAgriApp.Models
{
    //public class ProductDetailsModel
    //{
    //    public int Id { get; set; }
    //    public string ImageName { get; set; }
    //    public string ProductName { get; set; }
    //}

    public class DropDownModel : BaseViewModel
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public bool IsCheckBoxItem { get; set; } = false;
        private bool _isSelectedItem;
        public bool IsSelectedItem
        {
            get { return _isSelectedItem; }
            set { SetProperty(ref _isSelectedItem, value); }
        }

        public string Link { get; set; }
        public string SerialNumber { get; set; }
    }


    public class ProductDetailsModel : BaseNotifyPropertyChanged
    {
        private List<ProductImageData> _productImages;
        public ProductDetailsModel()
        {
            _productImages = new List<ProductImageData>();
        }

        private int _productID;

        [JsonProperty("ProductID")]
        public int ProductID
        {
            get { return _productID; }
            set
            {
               
                SetProperty(ref _productID, value);
            }
        }

        [JsonProperty("LanguageID")]
        public int LanguageID { get; set; }

        [JsonProperty("ProductName")]
        public string ProductName { get; set; }

        [JsonProperty("ProductType")]
        public int ProductType { get; set; }

        [JsonProperty("Text")]
        public string Text { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }


        private string _image1;
        [JsonProperty("Image1")]
        public string Image1
        {
            get {
               
                return _image1; 
            }
            set
            {
                
                SetProperty(ref _image1, value);
            }
        }


        private string _image2;
        [JsonProperty("Image2")]
        public string Image2
        {
            get { return _image2; }
            set
            {
                
                SetProperty(ref _image2, value);
            }
        }

        private string _image3;
        [JsonProperty("Image3")]
        public string Image3
        {
            get { return _image3; }
            set
            {
               
                SetProperty(ref _image3, value);
            }
        }




        [JsonProperty("YoutubeLink")]
        public string YoutubeLink { get; set; }

        [JsonProperty("ProductLink")]
        public string ProductLink { get; set; }

        [JsonProperty("Catalog")]
        public string Catalog { get; set; }

        [JsonProperty("Manual")]
        public string Manual { get; set; }

        [JsonProperty("Brochure")]
        public string Brochure { get; set; }

        [JsonProperty("AverageRating")]
        public double AverageRating { get; set; }

        public List<ProductImageData> ProductImages
        {
            get { return _productImages; }
            set { SetProperty(ref _productImages, value); }
        }


        


        private ImageSource GetImage(string image)
        {
            
            ImageSource _productImage;

            _productImage = ImageSource.FromStream(
                () => new MemoryStream(Convert.FromBase64String(image)));

            return _productImage;
        }


    }


    public class ProductImageData:BaseNotifyPropertyChanged
    {
        [JsonProperty("ProductID")]
        public int ProductID { get; set; }

        public ImageSource ImageName { get; set; }
        //private ImageSource _imageName;
        //public ImageSource ImageName 
        //{ get { return _imageName; }
        //    set { SetProperty(ref _imageName, value); }
        //}
       
    }


    public class ProductDetailsResponseModel
    {
        [JsonProperty("Products")]
        public List<ProductDetailsModel> Products { get; set; }

        public string Message { get; set; }
    }

}
