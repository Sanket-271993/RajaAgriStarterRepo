using Newtonsoft.Json;
using RajaAgriApp.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace RajaAgriApp.Models
{
    public class ProductModel: BaseNotifyPropertyChanged
    {
        [JsonProperty("Id")]
        public int ProductID { get; set; }

        [JsonProperty("Headline")]
        public object Headline { get; set; }

        private string _productName;

        [JsonProperty("Name")]
        public string ProductName 
        { 
            get { return _productName; }
            set
            {
                SetProperty(ref _productName, value);
            }
        }

        [JsonProperty("ProductTypeId")]
        public int ProductTypeId { get; set; }

        [JsonProperty("Subtitle")]
        public string Subtitle { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        private string _image;

        [JsonProperty("Image")]
        public string Image
        { get { return _image; }
          set {
                if (_productImage == null)
                {
                    _productImage = Xamarin.Forms.ImageSource.FromStream(
                        () => new MemoryStream(Convert.FromBase64String(Image)));
                }
                SetProperty(ref _image, value);

            }
        }

        private ImageSource _productImage;
        public ImageSource ProductImage
        {
            get
            {
                return _productImage;
            }
            set
            {
                SetProperty(ref _productImage, value);
            }
        }
    }

    public class ProductResponseModel
    {
        [JsonProperty("Home")]
        public List<ProductModel> Products  { get; set; }

        public string Message { get; set; }
        
    }

}
