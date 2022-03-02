using System;
using System.Collections.Generic;
using System.Text;

namespace RajaAgriApp.Models
{
    public class ServiceRequestModel
    {
        public string ProductName { get; set; }
        public string ProductProblem { get; set; }
        public string SerialNumber { get; set; }
        public string RequestNumber { get; set; }
        public string RequestStatus { get; set; }

        public string RequestTime { get; set; }
             
    }

    public class Product
    {
        public int Id { get; set; }

        public string ProductName { get; set; }
    }

    public class ProductProblem
    {
        public int Id { get; set; }

        public string ProductProblemType { get; set; }
    }
}
