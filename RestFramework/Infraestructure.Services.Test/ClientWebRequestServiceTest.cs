using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Infrastructure.Services;
using System.Threading.Tasks;

namespace Infraestructure.Services.Test
{
    [TestClass]
    public class ClientWebRequestServiceTest
    {
        [TestMethod]
        public async Task SimpleGetDataTest()
        {
            string dummyURL="http://www.google.com";
            ClientRequestService clientWeb = new ClientRequestService();
            var result=await clientWeb.GetData(dummyURL);
            Assert.IsTrue(result.Contains("google"));
        }


    }
}
