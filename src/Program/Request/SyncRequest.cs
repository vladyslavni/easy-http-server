using Extension;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;

namespace easy_http_server
{
    public class SyncRequest : IRequest
    {
        public async Task<List<ResponseInfo>> makeRequest(string[] urls)
        {
            WebResponse whoResponse = MakeRequest(urls[0], "who");
            WebResponse howResponse = MakeRequest(urls[1], "how");
            WebResponse doesResponse = MakeRequest(urls[2], "does");
            WebResponse whatResponse = MakeRequest(urls[3], "what");

            List<WebResponse> responses = new List<WebResponse>() {whoResponse, howResponse, doesResponse, whatResponse};

            return responses.Select(request => request.GetInformation()).ToList();
        }

        private WebResponse MakeRequest(string url, string endpoint)
        {  
            return WebRequest.Create($"{url}/{endpoint}").GetResponse();
        }
    }
}