using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace RajaAgriApp.Models
{
    public class DealerModel
    {
        public int DealerId { get; set; }
        public string DealerName { get; set; }
        public string PhoneNumber { get; set; }
        public int Rating { get; set; } 
        public ImageSource ImageSource { get; set; }
    }
}
