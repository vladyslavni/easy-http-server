using System.Net;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace easy_http_server
{
    public interface IRequest
    {
        Task<WebResponse[]> makeRequest(string[] urls);
    }
}