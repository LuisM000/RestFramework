using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Services;
using Model.Services.Test.DummyClasses;

namespace Model.Services.Test
{
    [TestClass]
    public class CreateBasicRequestServiceTest
    {
        [TestMethod]
        public void CreateBasicRequestTest()
        {
            DummyRequest request = new DummyRequest() { Name = "Dummy", Location = "DummyLocation", Age = 30 };
            CreateBasicRequestService<DummyRequest> createRequest = new CreateBasicRequestService<DummyRequest>();
            createRequest.BaseRequest = "http://www.dummyRequest.com/apiSearch?";
            createRequest.Equal = "=";
            createRequest.Separator = "&";

            var url=createRequest.GetUrl(request);
            Assert.AreEqual(@"http://www.dummyRequest.com/apiSearch?name=Dummy&location=DummyLocation&age=30", url);
        }

        [TestMethod]
        public void NullPropertyRequestTest()
        {
            DummyRequest request = new DummyRequest() { Location = "DummyLocation", Age = 30 };
            CreateBasicRequestService<DummyRequest> createRequest = new CreateBasicRequestService<DummyRequest>();
            createRequest.BaseRequest = "http://www.dummyRequest.com/apiSearch?";
            createRequest.Equal = "=";
            createRequest.Separator = "&";

            var url = createRequest.GetUrl(request);
            Assert.AreEqual(@"http://www.dummyRequest.com/apiSearch?location=DummyLocation&age=30", url);
        }
    }
}
