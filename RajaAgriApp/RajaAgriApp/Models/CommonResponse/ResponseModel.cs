using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RajaAgriApp.Models.CommonResponse
{
    public class Response<T>
    {
        public T Data { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }



}
