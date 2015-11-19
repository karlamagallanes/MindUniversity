using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace MindEval.FiveSquare.Common
{
    public class User
    {
        public User()
        {
        }

        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("lastname")]
        public string LastName { get; set; }
        [JsonProperty("years")]
        public int Years { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("sex")]
        public string Sex { get; set; }
        [JsonIgnore]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

