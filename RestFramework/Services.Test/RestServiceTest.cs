using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.Services;
using Services.Test.DummyClasses;
using Moq;
using Model.IServices;
using Infrastructure.IServices;
using System.Threading.Tasks;

namespace Services.Test
{
    [TestClass]
    public class RestServiceTest
    {
        [TestMethod]
        public void UseCaseTest()
        {
            Mock<ICreateRequestService<DummyRequest>> createRequestService = new Mock<ICreateRequestService<DummyRequest>>();
            Mock<IClientService> clientService = new Mock<IClientService>();
            Mock<ISerializeService<DummyResponse>> serializeService = new Mock<ISerializeService<DummyResponse>>();

            DummyRequest request=new DummyRequest()
            {
                Age=30,
                Location="DummyLocation",
                Name="Dummy"
            };
            DummyResponse response=new DummyResponse()
            {
                Id=1,
                RealName="DummyReal"
            };
            createRequestService.Setup(r => r.GetUrl(request)).Returns("www.dummy.com?foo=2");
            clientService.Setup(s => s.GetData("www.dummy.com?foo=2")).Returns(Task.FromResult("<xml>values</xml>"));
            serializeService.Setup(ss => ss.Deserialize("<xml>values</xml>")).Returns(response);

            RestService<DummyRequest,DummyResponse> restService = 
                new RestService<DummyRequest,DummyResponse>(createRequestService.Object,clientService.Object,serializeService.Object);

            var resultResponse=restService.Get(request).Result;
            Assert.AreEqual(response, resultResponse);
        }

       
    }
}
