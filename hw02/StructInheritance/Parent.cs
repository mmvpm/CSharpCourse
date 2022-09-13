using System;

namespace StructInheritance
{
    public struct Parent
    {
        public void MethodA(int someValue)
        {
            Console.WriteLine("Parent.MethodA({0})", someValue);
        }

        public int MethodB(string someString)
        {
            Console.WriteLine("Parent.MethodB({0})", someString);
            return 0;
        }
    }
}