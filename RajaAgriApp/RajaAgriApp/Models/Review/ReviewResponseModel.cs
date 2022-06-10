using Newtonsoft.Json;

namespace RajaAgriApp.Models
{
    public class ReviewResponseModel
    {
        [JsonProperty("IsSubmitted")]
        public bool IsSubmitted { get; set; }

        [JsonProperty("Message")]
        public string Message { get; set; }
    }
}
