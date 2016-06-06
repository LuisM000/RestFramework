using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IServices
{
    public interface IClientService
    {
        string Url { get; set; }
        string User { get; set; }
        string Password { get; set; }

        Task<string> GetData(string url);
    }
}
