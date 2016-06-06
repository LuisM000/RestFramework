using Infrastructure.IServices;
using Infrastructure.Services;
using Model.IServices;
using Model.Services;
using RestExample.Model.Request;
using RestExample.Model.Response;
using Services.IServices;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestExample
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().Wait();

           
        }
        static async Task MainAsync()
        {
            Console.WriteLine("Introduce una dirección");
            var city = Console.ReadLine();
            var location = await GetCoordinates(city);
            Console.WriteLine("Las coordenadas de {0} son {1},{2}", city, location.Latitude, location.Longitude);
            MainAsync().Wait();

        }

        private static async Task<Location> GetCoordinates(string address)
        {
            ICreateRequestService<GeocodeRequest> requestService = new CreateBasicRequestService<GeocodeRequest>();
            requestService.BaseRequest = @"http://maps.googleapis.com/maps/api/geocode/xml?";
            requestService.Equal = "=";
            requestService.Separator = "&";
            IClientService clientService = new ClientRequestService();
            ISerializeService<GeocodeResponse> serializeService = new SerializeXmlService<GeocodeResponse>();

            IRestService<GeocodeRequest, GeocodeResponse> restService = new RestService<GeocodeRequest, GeocodeResponse>(
                                                                    requestService, clientService, serializeService);

            GeocodeRequest request = new GeocodeRequest()
            {
                Address = address,
                Language = "es",
                Region = "es",
                Sensor = "false"
            };
            var response = await restService.Get(request);

            return response.Geocode.Geometry.Location;
        }
    }
}
