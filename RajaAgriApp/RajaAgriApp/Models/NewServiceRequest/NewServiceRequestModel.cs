using System;
using System.Collections.Generic;
using System.Text;

namespace RajaAgriApp.Models
{
    public class NewServiceRequestModel
    {
        public int ProductRegistrationId { get; set; }
        public int TypeofProblem { get; set; }
        public int DistributorId { get; set; }

        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public string Comments { get; set; }
    }
}
