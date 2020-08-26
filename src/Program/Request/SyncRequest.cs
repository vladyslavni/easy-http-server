using Extension;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;

namespace easy_http_server
{
    public class SyncRequest : IRequest
    {
        public async Task<WebResponse[]> makeRequest(string[] urls)
        {
            WebResponse whoResponse = Startup.MakeRequest(urls[0], "who").Result;
            WebResponse howResponse = Startup.MakeRequest(urls[1], "how").Result;
            WebResponse doesResponse = Startup.MakeRequest(urls[2], "does").Result;
            WebResponse whatResponse = Startup.MakeRequest(urls[3], "what").Result;

            return new WebResponse[] {whoResponse, howResponse, doesResponse, whatResponse};
        }
    }
}