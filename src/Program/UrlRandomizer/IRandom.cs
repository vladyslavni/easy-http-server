using System.Threading.Tasks;
using System.Collections.Generic;

namespace easy_http_server
{
    public interface IRandom
    {
        string[] GetRandomUrls(List<string> urls);
    }
}