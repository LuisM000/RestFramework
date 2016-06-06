using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IServices
{
    public interface ISerializeService<T>
    {
        T Deserialize(string data);

        string Serialize(T data);
    }
}
