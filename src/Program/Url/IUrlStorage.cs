using System.Collections.Generic;

namespace easy_http_server
{
    public interface IUrlStorage
    {
        List<string> Get();

        void Add(string url);

        void AddAll(string[] urls);
        void Remove(int index);
        
        void RemoveLast();

        void Clear();
    }
}