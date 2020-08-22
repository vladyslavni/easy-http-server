using System;
using System.Collections.Generic;

namespace easy_http_server
{
    public class ValuedParameter : IParameter
    {
        public readonly string fullKey;
        public readonly string desctription;
        public readonly Action<string> handler;
        private string value;

        public ValuedParameter(string fullKey, string desctription, Action<string> handler)
        {
            this.fullKey = fullKey;
            this.desctription = desctription;
            this.handler = handler;
        }

        public void Apply()
        {
            handler(value);
        }

        public bool IsValid(string arg)
        {
            if (arg.Contains("=")) {
                string[] valuedArg = arg.Split("=");
                this.value = valuedArg[1];
                
                return valuedArg[0].Equals(fullKey);

            } else {
                return false;
            }
        }

        public override string ToString()
        {
            return "\t" + fullKey + "\t" + desctription + "\n";
        }
    }
}