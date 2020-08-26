using Extension;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;


namespace easy_http_server
{
    public class AsyncRequest : IRequest
    {
        public async Task<WebResponse[]> makeRequest(string[] urls)
        {
            Task<WebResponse> whoResponse = Task.Run( () => Startup.MakeRequest(urls[0], "who"));
            Task<WebResponse> howResponse = Task.Run( () => Startup.MakeRequest(urls[1], "how"));
            Task<WebResponse> doesResponse = Task.Run( () => Startup.MakeRequest(urls[2], "does"));
            Task<WebResponse> whatResponse = Task.Run( () => Startup.MakeRequest(urls[3], "what"));

            return await Task.WhenAll(whoResponse, howResponse, doesResponse, whatResponse);
        }
    }
}