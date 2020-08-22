using System;
using System.Reflection;

namespace easy_http_server
{
    [System.AttributeUsage(System.AttributeTargets.Method)] 
    public class Parameter : Attribute 
    {
        public readonly string key;
        public readonly string fullKey;
        public readonly string description;

        public Parameter(string fullKey, string description)
        {
            this.fullKey = fullKey;
            this.description = description;
        }

        public Parameter(string key, string fullKey, string description) : this(fullKey, description)
        {
            this.key = key;
        }
    }
}