using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace IntegrationTest.Classes.XMLClasses.XMLSubClasses
{
    [XmlRoot("result")]
    public class Geocode
    {
        [XmlElement("geometry")]
        public Geometry Geometry { get; set; }
    }
}
