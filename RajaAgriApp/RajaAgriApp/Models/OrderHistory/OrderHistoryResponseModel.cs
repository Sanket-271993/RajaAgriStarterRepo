using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RajaAgriApp.Models
{
    public class HistoryOrderModel
    {
        [JsonProperty("ProductRegistrationId")]
        public int ProductRegistrationId { get; set; }

        [JsonProperty("ProductId")]
        public int ProductId { get; set; }

        [JsonProperty("ProductType")]
        public int ProductType { get; set; }

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
        public int DistributorId { get; set; }
    }

    public class OrderHistoryResponseModel
    {
        [JsonProperty("Products")]
        public List<HistoryOrderModel> Products { get; set; }
        public string Message { get; set; }
        
    }
}
