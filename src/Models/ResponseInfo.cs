using System;
namespace easy_http_server
{
    public struct ResponseInfo
    {
        public readonly string body;
        public readonly string user;
    
        public ResponseInfo(string body, string user)
        {
            this.body = body;
            this.user = user;
        }

        public string GetFullInfo()
        {
            return body + " - received from " + user;
        }
    }
}