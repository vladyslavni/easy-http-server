using System;
namespace easy_http_server
{
    public struct ResponseInfo<T,K>
    {
        public readonly T body;
        public readonly K user;
    
        public ResponseInfo(T body, K user)
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