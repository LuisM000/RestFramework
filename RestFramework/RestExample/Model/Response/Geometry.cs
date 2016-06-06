using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RestExample.Model.Response
{
    [XmlRoot("geometry")]
    public class Geometry
    {
        [XmlElement("location")]
        public Location Location { get; set; }
    }
}
