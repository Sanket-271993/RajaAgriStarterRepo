using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RajaAgriApp.Models
{
    public class RegisterRequestModel
    {
       
            [JsonProperty("phoneNumber")]
            public string PhoneNumber { get; set; }

            [JsonProperty("farmerName")]
            public string FarmerName { get; set; }

            [JsonProperty("pincode")]
            public string Pincode { get; set; }

            [JsonProperty("landmark")]
            public string Landmark { get; set; }

            [JsonProperty("aadhaarCardAddress")]
            public string AadhaarCardAddress { get; set; }

            [JsonProperty("image")]
            public string Image { get; set; }
        
    }


}
