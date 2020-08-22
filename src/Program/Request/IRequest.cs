using System.Threading.Tasks;
using System.Collections.Generic;

namespace easy_http_server
{
    public interface IRequest
    {
        Task<List<ResponseInfo>> makeRequest();
    }
}