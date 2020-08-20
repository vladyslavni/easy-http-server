using Extension;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;

namespace easy_http_server
{
    public class RegularRequest : IRequest
    {
        public async Task<List<ResponseInfo>> makeRequest()
        {
            return DataStorage.endpoints.Select(endpoint => 
                                            MakeRequest(DataStorage.urls.GetRandomValue(), endpoint))
                                        .Select(request => request.GetInformation()).ToList();
        }

        private WebResponse MakeRequest(string url, string endpoint)
        {  
            return WebRequest.Create($"{url}/{endpoint}").GetResponse();
        }
    }
}