using Customer.DTO.Models.Constants;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Customer.DTO.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhotoBase64 { get; set; }
        public string UserCreator { get; set; }
        public string UserLastModified { get; set; }
        public Roles? Role { get; set; }
    }
}
