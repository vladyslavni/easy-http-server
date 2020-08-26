using System;
using System.Linq;
using System.Collections.Generic;
using Extension;


namespace easy_http_server
{
    public class RandomWithRepetitions : IRandom
    {
        public string[] GetRandomUrls(List<string> urls)
        {
            string[] result = new string[4];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = urls.GetRandomValue();
            }

            return result;
        }
    }
}