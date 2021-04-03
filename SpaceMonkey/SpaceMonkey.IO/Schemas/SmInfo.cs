using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceMonkey.IO.Schemas
{
    public class SmInfo
    {
        [JsonProperty("category")]
        public string Category { get; set; }
        [JsonProperty("transactionscount")]
        public int TransactionsCount { get; set; }
        [JsonProperty("satcount")]
        public string SatCount { get; set; }
    }
}
