using Infrastructure.IServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ClientRequestService : IClientService
    {
        public string Url { get; set; }
        public string User { get; set; }
        public string Password { get; set; }

 
        public async Task<string> GetData(string url)
        {
            this.Url = url;
            var request = (HttpWebRequest)WebRequest.Create(url);

            request.Credentials = new NetworkCredential(this.User, this.Password);
            var uri = new Uri(string.Format(
              url,
              "action",
              "get",
              DateTime.Now.Ticks
              ));

            var response = await request.GetResponseAsync();
            using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                return await sr.ReadToEndAsync();
        }

      
     
    }
}
