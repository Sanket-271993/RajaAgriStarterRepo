using System;
using System.Collections.Generic;
using System.Text;

namespace RajaAgriApp.Models
{
    public class ProductRegistrationRequestModel
    {
        public int ProductId { get; set; }
        public int ProductType { get; set; }
        public int DistributorId { get; set; }
        public string SerialNumber { get; set; }
        public string InvoiceImage { get; set; }
        public DateTime InvoiceDate { get; set; }
       
        
    }
}
