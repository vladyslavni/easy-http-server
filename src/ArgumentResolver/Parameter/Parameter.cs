using System;
using System.Collections.Generic;

namespace easy_http_server
{
    public struct Parameter : IParameter
    {
        public readonly string abbreviatedKey;
        public readonly string fullKey;
        public readonly string desctription;
        public readonly Action handler;

        public Parameter(string abbreviatedKey, string fullKey, string desctription, Action handler)
        {
            this.abbreviatedKey = abbreviatedKey;
            this.fullKey = fullKey;
            this.desctription = desctription;
            this.handler = handler;
        }

        public Parameter(string fullKey, string desctription, Action handler)
        {
            this.abbreviatedKey = null;
            this.fullKey = fullKey;
            this.desctription = desctription;
            this.handler = handler;
        }
        
        public void Apply()
        {
            handler();
        }

        public bool IsValid(string arg)
        {
            return arg.Equals(abbreviatedKey) 
                    || arg.Equals(fullKey);
        }

        public override string ToString()
        {
            return abbreviatedKey + "\t" + fullKey + "\t" + desctription + "\n";
        }
    }
}