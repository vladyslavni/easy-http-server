using System;

namespace Extension
{
    public static class ArrayExtension
    {
        public static string GetRandomValue(this string[] str)
        {
            Random random = new Random();
            int index = random.Next(str.Length);
            return str[index];
        }
    }
}