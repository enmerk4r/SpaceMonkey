using Newtonsoft.Json;
using SpaceMonkey.IO.Schemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SpaceMonkey.WebClient
{
    public class SpaceMonkeyWebClient
    {
        // Routes
        private string Server => "https://api.n2yo.com/rest/v1";
        private string GetAboveUrl(double lat, double lng, double alt, int rad, int id, string key)
        {
            return $"{Server}/satellite/above/{lat}/{lng}/{alt}/{rad}/{id}/&apiKey={key}";
        }

        /// <summary>
        /// Http Client
        /// </summary>
        private HttpClient Client;
        public SpaceMonkeyWebClient()
        {
            this.Client = new HttpClient();
        }

        public async Task<SmAboveResponse> GetAboveSatellites(double lat, double lng, double alt, int rad, int id, string key)
        {
            string url = this.GetAboveUrl(lat, lng, alt, rad, id, key);
            var response = await this.Client.GetAsync(url);
            var res = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<SmAboveResponse>(res);
        }

    }
}
