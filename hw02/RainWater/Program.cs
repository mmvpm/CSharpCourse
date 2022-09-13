using System;

namespace RainWater
{
    internal static class Program
    {
        public static int RainWater(int[] columns)
        {
            if (columns.Length == 0)
            {
                return 0;
            }
            
            var prefixMax = new int[columns.Length];
            var suffixMax = new int[columns.Length];

            prefixMax[0] = columns[0];
            for (var i = 1; i < columns.Length; i++)
            {
                prefixMax[i] = Math.Max(prefixMax[i - 1], columns[i]);
            }
            
            suffixMax[columns.Length - 1] = columns[columns.Length - 1];
            for (var i = columns.Length - 2; i >= 0; i--)
            {
                suffixMax[i] = Math.Max(suffixMax[i + 1], columns[i]);
            }

            var result = 0;
            for (var i = 0; i < columns.Length; i++)
            {
                result += Math.Min(prefixMax[i], suffixMax[i]) - columns[i];
            }

            return result;
        }
        
        public static void Main(string[] args)
        {
            Console.WriteLine(RainWater(new [] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 })); // 6
            Console.WriteLine(RainWater(new [] { 4, 2, 0, 3, 2, 5 })); // 9
            Console.WriteLine(RainWater(new [] { 1, 2, 3, 4, 5, 6, 7 })); // 0
            Console.WriteLine(RainWater(new [] { 8, 1, 2, 3, 4, 5, 6, 7 })); // 21
        }
    }
}