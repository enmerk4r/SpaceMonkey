using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SpaceMonkey.IO.Schemas
{
    public class SmSatellite
    {
        [JsonProperty("satid")]
        public int SatId { get; set; }
        [JsonProperty("satname")]
        public string SatName { get; set; }
        [JsonProperty("intDesignator")]
        public string IntDesignator { get; set; }
        [JsonProperty("launchDate")]
        public string LaunchDate { get; set; }
        [JsonProperty("satlat")]
        public double SatLat { get; set; }
        [JsonProperty("satlng")]
        public double SatLng { get; set; }
        [JsonProperty("satalt")]
        public double SatAlt { get; set; }
    }
}
