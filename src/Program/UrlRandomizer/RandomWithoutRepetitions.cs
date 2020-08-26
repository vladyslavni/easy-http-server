using System;
using System.Collections.Generic;
using System.Linq;

namespace easy_http_server
{
    public class RandomWithoutRepetitions : IRandom
    {
        private static Random rand = new Random();

        public string[] Random(List<string> urls)
        {
            if( urls.Count < 4) return new RandomWithRepetitions().Random(urls);

            return urls.Select(x => new { value = x, order = rand.Next() })
                .OrderBy(x => x.order)
                .Select(x => x.value)
                .ToArray();
        }
    }
}