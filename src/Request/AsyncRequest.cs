using Extension;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;


namespace easy_http_server
{
    public class AsyncRequest : IRequest
    {
        public async Task<List<ResponseInfo>> makeRequest()
        {
            var requests = DataStorage.endpoints.Select(endpoint => 
                                            MakeRequest(DataStorage.urls.GetRandomValue(), endpoint));

            return await Task.WhenAll(requests)
                    .ContinueWith(async task =>
                            task.Result.Select(response => response.GetInformation()).ToList()).Result;
        }

        private async Task<WebResponse> MakeRequest(string url, string endpoint)
        {  
            return await WebRequest.Create($"{url}/{endpoint}").GetResponseAsync();
        }
    }
}