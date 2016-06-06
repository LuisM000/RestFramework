using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Infraestructure.Services.Test.DummyClasses;
using Infrastructure.Services;

namespace Infraestructure.Services.Test
{
    [TestClass]
    public class SerializeXmlServiceTest
    {
        
        [TestMethod]
        public void SerializeDeserializeTest()
        {
            SerializeXmlService<Foo> serializeService = new SerializeXmlService<Foo>();
            Foo foo = new Foo(){FooInt = 2, FooString = "Foo"};
            var xml=serializeService.Serialize(foo);
            var deserializeXml = serializeService.Deserialize(xml);

            Assert.AreEqual(2, deserializeXml.FooInt);
            Assert.AreEqual("Foo", deserializeXml.FooString);

        }

         
    }
}
