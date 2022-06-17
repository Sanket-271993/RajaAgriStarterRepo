using Newtonsoft.Json;
using RajaAgriApp.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace RajaAgriApp.Models
{
    
    public class FarmerDetail : BaseNotifyPropertyChanged
    {
        [JsonProperty("FarmerId")]
        public int FarmerId { get; set; }

        [JsonProperty("FarmerName")]
        public string FarmerName { get; set; }

        [JsonProperty("PhoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("Location")]
        public string Location { get; set; }

        private string _image;

        [JsonProperty("Image")]
        public string Image
        {
            get { return _image; }
            set
            {
                if (_userImage == null)
                {
                    _userImage = Xamarin.Forms.ImageSource.FromStream(
                        () => new MemoryStream(Convert.FromBase64String(Image)));
                }
                SetProperty(ref _image, value);

            }
        }

        private ImageSource _userImage;


        public ImageSource UserImage
        {
            get { return _userImage; }
            set
            {

                SetProperty(ref _userImage, value);

            }
        }


    }

    public class ProfileResponseModel
      {
        [JsonProperty("FarmerDetails")]
        public List<FarmerDetail> FarmerDetails { get; set; }
        public string Message { get; set; }
       }


}
