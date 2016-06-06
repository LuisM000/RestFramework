using Infrastructure.IServices;
using Model.IServices;
using Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class RestService<T,J>:IRestService<T,J>
    {
        private ICreateRequestService<T> createRequestService;
        private IClientService clientService;
        private ISerializeService<J> serializeService;

        public RestService(ICreateRequestService<T> createRequestService, IClientService clientService,
                                    ISerializeService<J> serializeService)
        {
            this.createRequestService = createRequestService;
            this.clientService = clientService;
            this.serializeService = serializeService;
        }

        public async Task<J> Get(T request)
        {
            var url = this.createRequestService.GetUrl(request);
            var data = await this.clientService.GetData(url);
            var result = serializeService.Deserialize(data);
            return result;
        }
    }
}
