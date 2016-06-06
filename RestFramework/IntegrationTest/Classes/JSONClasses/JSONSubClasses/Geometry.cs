using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTest.Classes.JSONClasses.JSONSubClasses
{
    [JsonObject("geometry")]
    public class Geometry
    {
        [JsonProperty("location")]
        public Location Location { get; set; }
    }
}
