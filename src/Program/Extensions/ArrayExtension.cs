using System;
using System.Collections.Generic;

namespace Extension
{
    public static class ArrayExtension
    {
        private static Random rand = new Random();
        public static T GetRandomValue<T>(this T[] array)
        {
            int index = rand.Next(array.Length);
            return array[index];
        }

        public static T GetRandomValue<T>(this List<T> list)
        {
            int index = rand.Next(list.Count);
            return list[index];
        }
    }
}