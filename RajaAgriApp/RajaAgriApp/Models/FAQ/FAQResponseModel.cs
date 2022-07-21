using System;
using System.Collections.Generic;
using System.Text;

namespace RajaAgriApp.Models
{
    
        public class FAQResponseModel
        {
            public FAQ[] FAQ { get; set; }

            public string Message { get; set; }
        }

        public class FAQ
        {
            public int FAQID { get; set; }
            public int FAQCategoryId { get; set; }
            public string Question { get; set; }
            public string Answer { get; set; }
            public bool Status { get; set; }
        }

    
}
