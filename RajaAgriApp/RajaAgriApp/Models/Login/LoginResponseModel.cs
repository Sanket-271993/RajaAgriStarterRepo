namespace RajaAgriApp.Models
{

    public class LoginResponseModel
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public string PhoneNumber { get; set; }
        public string issued { get; set; }
        public string expires { get; set; }
        public string Message { get; set; }
    }
}
