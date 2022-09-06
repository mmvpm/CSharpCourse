using System;

namespace HashTable
{
    internal static class Program
    {
        public static void Main()
        {
            var table = new HashTable<string, int>();

            table.Add("a", 1);
            table.Add("b", 2);
            table.Add("d", 4);
            Console.WriteLine(table); // {b -> 2, d -> 4, a -> 1}

            table.Remove("b");
            table.Remove("c");
            Console.WriteLine(table); // {d -> 4, a -> 1}

            Console.WriteLine();
            Console.WriteLine(table.Contains("c")); // False
            Console.WriteLine(table.Find("c"));     // 0
            Console.WriteLine(table.Contains("d")); // True
            Console.WriteLine(table.Find("d"));     // 4
        }
    }
}