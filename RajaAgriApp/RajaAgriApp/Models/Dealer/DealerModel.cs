using Newtonsoft.Json;
using RajaAgriApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace RajaAgriApp.Models
{
   


    public class DealerModel: BaseNotifyPropertyChanged
    {
        [JsonProperty("DistributorID")]
        public int DealerId { get; set; }

        [JsonProperty("Name")]
        public string DealerName { get; set; }

        [JsonProperty("Phone")]
        public string PhoneNumber { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("Address")]
        public string Address { get; set; }

        [JsonProperty("Region")]
        public string Region { get; set; }

        [JsonProperty("NumberOfPartnerContacts")]
        public string NumberOfPartnerContacts { get; set; }

        public int Rating { get; set; }

        private ImageSource _userProfile= "ic_defult_user";
        public ImageSource UserProfile 
        {
            get
            {
                return _userProfile;
            }
            set
            {
                SetProperty(ref _userProfile, value);
            }
        }
    }

    public class DealerResponseModel
    {
        [JsonProperty("Distributors")]
        public List<DealerModel> Distributors { get; set; }
        public string Message { get; set; }
        
    }
}
