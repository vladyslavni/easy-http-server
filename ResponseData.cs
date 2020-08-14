using System;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace easy_http_server
{
    public static class ResponseData
    {
        public static string GetBody(this WebResponse response)
        {      
            var encoding = UTF8Encoding.UTF8;
            using (var reader = new StreamReader(response.GetResponseStream(), encoding))
            {
                return reader.ReadToEnd();
            }
        }

        public static ResponseInfo<string, string> GetInformation(this WebResponse response)
        {
            string endpointValue = response.GetBody();
            string endpointStudent = response.Headers.GetValues("InCamp-Student").First();

            return new ResponseInfo<string, string>(endpointValue, endpointStudent);
        }
    }
}