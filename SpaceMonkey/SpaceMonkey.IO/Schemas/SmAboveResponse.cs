using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceMonkey.IO.Schemas
{
    public class SmAboveResponse
    {
        [JsonProperty("info")]
        public SmInfo Info { get; set; }
        [JsonProperty("above")]
        public List<SmSatellite> Above { get; set; }
    }
}
