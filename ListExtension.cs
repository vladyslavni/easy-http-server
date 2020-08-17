using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Extension
{
    public static class ListExtension
    {
        public static T GetRandomValue<T>(this List<T> list)
        {
            Random random = new Random();
            int index = random.Next(list.Count);
            return list[index];
        }
    }
}