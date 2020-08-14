using System;
using System.Collections.Generic;

namespace easy_http_server
{
    public static class ListRandom
    {
        public static T GetRandomValue<T>(this List<T> list)
        {
            Random random = new Random();
            int index = random.Next(list.Count);
            return list[index];
        }
    }
}