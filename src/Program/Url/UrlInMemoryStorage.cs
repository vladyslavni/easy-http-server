using System.Collections.Generic;
using System;

namespace easy_http_server
{
    public class UrlInMemoryStorage : IUrlStorage
    {
        private List<string> urls = new List<string>();

        public List<string> Get()
        {
            return urls;
        }

        public void Add(string url)
        {
            urls.Add(url);
        }

        public void AddAll(string[] newUrls)
        {
            foreach (var url in newUrls)
            {
                urls.Add(url);
            }
        }

        public void Clear()
        {
            urls.Clear();
        }

        public void Remove(int index)
        {
            urls.RemoveAt(index);
        }

        public void RemoveLast()
        {
            urls.RemoveAt(urls.Count - 1);
        }
    }
}