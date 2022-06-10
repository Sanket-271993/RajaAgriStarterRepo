using System;
using System.Collections.Generic;
using System.Text;

namespace RajaAgriApp.Models
{
    public class ReviewRequestModel
    {
        public int ProductId { get; set; }
        public int ProductRating { get; set; }
        public string Comments { get; set; }
        public DateTime RatingDate { get; set; }
    }
}
