using System.Linq;
using System.Net.Http;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.IO;
using easy_http_server;

namespace Extension
{
    public static class ResponseExtension
    {
        public static string GetBody(this WebResponse response)
        {      
            var encoding = UTF8Encoding.UTF8;
            using (var reader = new StreamReader(response.GetResponseStream(), encoding))
            {
                return reader.ReadToEnd();
            }
        }

        public static ResponseInfo GetInformation(this WebResponse response)
        {
            var endpointValue = response.GetBody();
            var endpointStudent = response.Headers.GetValues("InCamp-Student").First();

            return new ResponseInfo(endpointValue, endpointStudent);
        }
    
        public static string BuildResponse(this List<ResponseInfo> responses)
        {
            string result = "";

            foreach (var response in responses)
            {
                result += response.body + " ";
            }

            foreach (var response in responses)
            {
                result += "</br>" + response.GetFullInfo();
            }

            return result;
        }
    }
}