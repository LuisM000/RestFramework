using IntegrationTest.Classes.XMLClasses.XMLSubClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace IntegrationTest.Classes.XMLClasses
{
    [XmlRoot("GeocodeResponse")]
    public class GeocodeResponse
    {
        [XmlElement("status")]
        public string Status { get; set; }
        [XmlElement("result")]
        public Geocode Geocode { get; set; }
    }
}
