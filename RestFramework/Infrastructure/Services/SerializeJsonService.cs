using Infrastructure.IServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class SerializeJsonService<T>:ISerializeService<T>
    {
        public T Deserialize(string data)
        {
            return JsonConvert.DeserializeObject<T>(data);
        }

        public string Serialize(T data)
        {
            return JsonConvert.SerializeObject(data);
        }
    }
}
