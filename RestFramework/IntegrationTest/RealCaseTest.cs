using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.IServices;
using Infrastructure.IServices;
using Infrastructure.Services;
using IntegrationTest.Classes;
using Model.Services;
using Services.Services;
using System.Threading.Tasks;
using Services.IServices;

namespace IntegrationTest
{
    [TestClass]
    public class RealCaseTest
    {
        [TestMethod]
        public async Task RealCaseXMLGeocodeTest()
        {
            ICreateRequestService<GeocodeRequest> requestService = new CreateBasicRequestService<GeocodeRequest>();
            requestService.BaseRequest = @"http://maps.googleapis.com/maps/api/geocode/xml?";
            requestService.Equal = "=";
            requestService.Separator = "&";
            IClientService clientService = new ClientRequestService();
            ISerializeService<IntegrationTest.Classes.XMLClasses.GeocodeResponse> serializeService = new SerializeXmlService<IntegrationTest.Classes.XMLClasses.GeocodeResponse>();

            IRestService<GeocodeRequest, IntegrationTest.Classes.XMLClasses.GeocodeResponse> restService = new RestService<GeocodeRequest, IntegrationTest.Classes.XMLClasses.GeocodeResponse>(
                                                                    requestService, clientService, serializeService);

            GeocodeRequest request = new GeocodeRequest()
            {
                Address = "Valladolid",
                Language = "es",
                Region = "es",
                Sensor = "false"
            };

            var response=await restService.Get(request);

            Assert.AreEqual("OK", response.Status);
            Assert.IsTrue(response.Geocode.Geometry.Location.Latitude>0f);
            Assert.IsTrue(response.Geocode.Geometry.Location.Longitude < 0f);
        }

        [TestMethod]
        public async Task RealCaseJSONGeocodeTest()
        {
            ICreateRequestService<GeocodeRequest> requestService = new CreateBasicRequestService<GeocodeRequest>();
            requestService.BaseRequest = @"http://maps.googleapis.com/maps/api/geocode/json?";
            requestService.Equal = "=";
            requestService.Separator = "&";
            IClientService clientService = new ClientRequestService();
            ISerializeService<IntegrationTest.Classes.JSONClasses.GeocodeResponse> serializeService = new SerializeJsonService<IntegrationTest.Classes.JSONClasses.GeocodeResponse>();

            IRestService<GeocodeRequest, IntegrationTest.Classes.JSONClasses.GeocodeResponse> restService = new RestService<GeocodeRequest, IntegrationTest.Classes.JSONClasses.GeocodeResponse>(
                                                                    requestService, clientService, serializeService);

            GeocodeRequest request = new GeocodeRequest()
            {
                Address = "Valladolid",
                Language = "es",
                Region = "es",
                Sensor = "false"
            };

            var response = await restService.Get(request);

            Assert.AreEqual("OK", response.Status);
            Assert.IsTrue(response.Geocode[0].Geometry.Location.Latitude > 0f);
            Assert.IsTrue(response.Geocode[0].Geometry.Location.Longitude < 0f);
        }
    }
}
