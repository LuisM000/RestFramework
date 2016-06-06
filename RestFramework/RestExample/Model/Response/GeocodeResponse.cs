using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RestExample.Model.Response
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
