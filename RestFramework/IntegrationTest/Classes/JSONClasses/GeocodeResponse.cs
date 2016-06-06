using IntegrationTest.Classes.JSONClasses.JSONSubClasses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTest.Classes.JSONClasses
{
    public class GeocodeResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("results")]
        public IList<Geocode> Geocode { get; set; }
    }
}
