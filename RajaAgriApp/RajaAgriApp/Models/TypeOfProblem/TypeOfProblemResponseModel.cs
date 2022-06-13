using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RajaAgriApp.Models
{
   
    public class TypeOfProblemResponseModel
    {
        [JsonProperty("TypeOfProblem")]
        public List<TypeOfProblemModel> TypeOfProblems { get; set; }

        public string Message { get; set; }
    }

    public class TypeOfProblemModel
    {
        [JsonProperty("TypeOfProblemID")]
        public int TypeOfProblemID { get; set; }

        [JsonProperty("TypeOfProblem")]
        public string TypeOfProblem { get; set; }
    }
}
