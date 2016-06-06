using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RestExample.Model.Response
{
    [XmlRoot("result")]
    public class Geocode
    {
        [XmlElement("geometry")]
        public Geometry Geometry { get; set; }
    }
}
