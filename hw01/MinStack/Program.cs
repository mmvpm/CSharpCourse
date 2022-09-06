using System;

namespace MinStack
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var minStack = new MinStack<int>();
            
            minStack.Push(5);
            minStack.Push(2);
            minStack.Push(4);
            minStack.Push(1);
            minStack.Push(3);
            Console.WriteLine(minStack);            // Stack(3, 1, 4, 2, 5)
            Console.WriteLine(minStack.Peek());     // 3
            Console.WriteLine(minStack.MinValue()); // 1
            Console.WriteLine();

            minStack.Pop();
            minStack.Pop();
            Console.WriteLine(minStack);            // Stack(4, 2, 5)
            Console.WriteLine(minStack.Peek());     // 4
            Console.WriteLine(minStack.MinValue()); // 2
        }
    }
}