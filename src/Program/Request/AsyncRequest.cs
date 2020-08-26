using Extension;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;


namespace easy_http_server
{
    public class AsyncRequest : IRequest
    {
        public async Task<List<ResponseInfo>> makeRequest(string[] urls)
        {
            Task<WebResponse> whoResponse = Task.Run( () => MakeRequest(urls[0], "who"));
            Task<WebResponse> howResponse = Task.Run( () => MakeRequest(urls[1], "how"));
            Task<WebResponse> doesResponse = Task.Run( () => MakeRequest(urls[2], "does"));
            Task<WebResponse> whatResponse = Task.Run( () => MakeRequest(urls[3], "what"));

            return await Task.WhenAll(whoResponse, howResponse, doesResponse, whatResponse)
                    .ContinueWith(async task =>
                            task.Result.Select(response => response.GetInformation()).ToList()).Result;
        }

        private async Task<WebResponse> MakeRequest(string url, string endpoint)
        {  
            return await WebRequest.Create($"{url}/{endpoint}").GetResponseAsync();
        }
    }
}