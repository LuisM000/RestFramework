using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTest.Classes.JSONClasses.JSONSubClasses
{
    [JsonObject("results")]
    public class Geocode
    {
        [JsonProperty("geometry")]
        public Geometry Geometry { get; set; }
    }
}
