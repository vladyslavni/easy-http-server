using System;

namespace Extension
{
    public static class ArrayExtension
    {
        private static Random rand = new Random();
        public static T GetRandomValue<T>(this T[] array)
        {
            int index = rand.Next(0, array.Length);
            return array[index];
        }
    }
}