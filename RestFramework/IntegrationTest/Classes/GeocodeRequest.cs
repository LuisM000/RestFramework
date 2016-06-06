using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTest.Classes
{
    public class Attributes : Attribute
    {
        public string PropertyName { get; set; }

        public Attributes() { }
        public Attributes(string propertyName) { this.PropertyName = propertyName; }
    }

    public class GeocodeRequest
    {
        [Attributes(PropertyName = "address")]
        public string Address { get; set; }
        [Attributes(PropertyName = "region")]
        public string Region { get; set; }
        [Attributes(PropertyName = "sensor")]
        public string Sensor { get; set; }
        [Attributes(PropertyName = "language")]
        public string Language { get; set; }
    }
}
