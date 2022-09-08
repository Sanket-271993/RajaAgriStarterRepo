using Newtonsoft.Json;
using RajaAgriApp.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace RajaAgriApp.Models
{
    

   

    public class ServiceRequestResponseModel
    {
        [JsonProperty("ServiceRequests")]
        public List<ServiceRequestModel> ServiceRequests { get; set; }

        public string Message { get; set; }
        
    }

    public class ServiceRequestModel: BaseNotifyPropertyChanged
    {
        [JsonProperty("ServiceRequestID")]
        public int ServiceRequestID { get; set; }

        [JsonProperty("RequestNumber")]
        public int RequestNumber { get; set; }

        [JsonProperty("ProductID")]
        public int ProductID { get; set; }

        [JsonProperty("ProductName")]
        public string ProductName { get; set; }

        [JsonProperty("SerialNumber")]
        public string SerialNumber { get; set; }

        [JsonProperty("ProblemTypeName")]
        public string ProblemTypeName { get; set; }

        public string CustomerPhoneNumber { get; set; }


        private string _image1;

        [JsonProperty("Image1")]
        public string Image1
        {
            get { return _image1; }
            set
            {
                if (_productImage == null)
                {
                    _productImage = Xamarin.Forms.ImageSource.FromStream(
                        () => new MemoryStream(Convert.FromBase64String(Image1)));
                }
                SetProperty(ref _image1, value);

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

       
        private string _image2;

        [JsonProperty("Image2")]
        public string Image2
        {
            get { return _image2; }
            set
            {
                if (_productImage == null)
                {
                    _productImage = Xamarin.Forms.ImageSource.FromStream(
                        () => new MemoryStream(Convert.FromBase64String(Image2)));
                }
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
                if (_productImage == null)
                {
                    _productImage = Xamarin.Forms.ImageSource.FromStream(
                        () => new MemoryStream(Convert.FromBase64String(Image3)));
                }
                SetProperty(ref _image3, value);

            }
        }

        [JsonProperty("RequestDate")]
        public string RequestDate { get; set; }

        [JsonProperty("Status")]
        public string Status { get; set; }
    }

}
