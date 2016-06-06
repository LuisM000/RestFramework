using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Test.DummyClasses
{
    public class DummyPropertyAttribute : Attribute
    {
        public string PropertyName { get; set; }

        public DummyPropertyAttribute() { }
        public DummyPropertyAttribute(string propertyName) { this.PropertyName = propertyName; }
    }

    public class DummyRequest
    {
        [DummyPropertyAttribute(PropertyName = "name")]
        public string Name { get; set; }

        [DummyPropertyAttribute(PropertyName = "location")]
        public string Location { get; set; }

        [DummyPropertyAttribute(PropertyName = "age")]
        public int Age { get; set; }
    }
}
