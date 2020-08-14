using System;
using System.Collections.Generic;

namespace easy_http_server
{
    public static class ListRandom
    {
        public static String GetRandomValue(this List<string> list)
        {
            Random random = new Random();
            int index = random.Next(list.Count);
            return list[index];
        }
    }
}