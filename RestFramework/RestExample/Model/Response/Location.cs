using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RestExample.Model.Response
{
    [XmlRoot("location")]
    public class Location
    {
        [XmlElement("lat")]
        public float Latitude { get; set; }
        [XmlElement("lng")]
        public float Longitude { get; set; }
    }
}
