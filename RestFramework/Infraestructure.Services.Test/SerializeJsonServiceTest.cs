using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Infrastructure.Services;
using Infraestructure.Services.Test.DummyClasses;

namespace Infraestructure.Services.Test
{
    [TestClass]
    public class SerializeJsonServiceTest
    {
        [TestMethod]
        public void SerializeDeserializeTest()
        {
            SerializeJsonService<Foo> serializeService = new SerializeJsonService<Foo>();
            Foo foo = new Foo() { FooInt = 2, FooString = "Foo" };
            var xml = serializeService.Serialize(foo);
            var deserializeJson = serializeService.Deserialize(xml);

            Assert.AreEqual(2, deserializeJson.FooInt);
            Assert.AreEqual("Foo", deserializeJson.FooString);
        }
    }
}
