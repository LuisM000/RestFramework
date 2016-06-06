using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.IServices
{
    public interface ICreateRequestService<T>
    {
        string BaseRequest { get; set; }
        string Separator { get; set; }
        string Equal { get; set; }

        string GetUrl(T request);
    }
}
