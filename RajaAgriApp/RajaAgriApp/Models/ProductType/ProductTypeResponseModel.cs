using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RajaAgriApp.Models
{
    public class ProductTypeResponseModel
    {
        [JsonProperty("ProductType")]
        public List<ProductTypeModel> ProductTypes { get; set; }
        public string Message { get; set; }
    }

    public class ProductTypeModel
    {
        [JsonProperty("ProductTypeID")]
        public int ProductTypeID { get; set; }

        [JsonProperty("ProductType")]
        public string ProductType { get; set; }
    }

    
}
