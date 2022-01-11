using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.Domain.Dtos.Responses
{
    public class TemplateData
    {
        [JsonProperty("Username")]
        public string Username { get; set; }

        [JsonProperty("Data")]
        public string Data { get; set; }
    }
}
