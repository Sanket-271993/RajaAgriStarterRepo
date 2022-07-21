using System;
using System.Collections.Generic;
using System.Text;

namespace RajaAgriApp.Models
{

    public class FAQCategoryResponseModel
    {
        public List<Faqcategory> FAQCategory { get; set; }

        public string Message { get; set; }
    }

    public class Faqcategory
    {
        public int FAQCategoryId { get; set; }
        public string FAQCategoryName { get; set; }
    }
    
}
