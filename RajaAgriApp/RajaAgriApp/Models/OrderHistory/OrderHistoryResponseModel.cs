using Newtonsoft.Json;
using RajaAgriApp.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace RajaAgriApp.Models
{
    

    public class OrderHistoryResponseModel
    {
        [JsonProperty("Products")]
        public List<HistoryOrderModel> Products { get; set; }
        public string Message { get; set; }
        
    }


    public class HistoryOrderModel: BaseNotifyPropertyChanged
    {
        [JsonProperty("ProductRegistrationId")]
        public int ProductRegistrationId { get; set; }

        [JsonProperty("ProductName")]
        public string ProductName { get; set; }

        [JsonProperty("ProductType")]
        public int ProductType { get; set; }

        


        private string _productImage;

        [JsonProperty("ProductImage")]
        public string ProductImage
        {
            get { return _productImage; }
            set
            {
                if (_orderProductImage == null)
                {
                    _orderProductImage = Xamarin.Forms.ImageSource.FromStream(
                        () => new MemoryStream(Convert.FromBase64String(ProductImage)));
                }
                SetProperty(ref _productImage, value);

            }
        }

        private ImageSource _orderProductImage;
        public ImageSource OrderProductImage
        {
            get
            {
                return _orderProductImage;
            }
            set
            {
                SetProperty(ref _orderProductImage, value);
            }
        }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("SerialNumber")]
        public string SerialNumber { get; set; }

        [JsonProperty("InvoiceDate")]
        public DateTime? InvoiceDate { get; set; }

        [JsonProperty("RegistrationDate")]
        public DateTime RegistrationDate { get; set; }

        [JsonProperty("InvoiceImage")]
        public string InvoiceImage { get; set; }

        [JsonProperty("FarmerId")]
        public int FarmerId { get; set; }

        [JsonProperty("DistributorId")]
        public object DistributorId { get; set; }

        [JsonProperty("Warranty")]
        public int Warranty { get; set; }
    }

    
}
