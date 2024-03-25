using System;

namespace Extensions
{
    public static class CollectionExtensions
    {
        private static readonly Random random = new Random();
     
        public static T GetRandomElement<T>(this T[] array)
        {
            return array[random.Next(0, array.Length)];
        }
    }
}