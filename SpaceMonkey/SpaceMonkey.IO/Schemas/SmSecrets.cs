using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceMonkey.IO.Schemas
{
    public class SmSecrets
    {
        [JsonProperty("api_key")]
        public string ApiKey { get; set; }
    }
}
