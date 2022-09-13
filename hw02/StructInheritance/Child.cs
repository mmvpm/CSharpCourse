using System;

namespace StructInheritance
{
    public struct Child // : Parent
    {
        private Parent _parent;

        public Child(int someInt)
        {
            _parent = new Parent();
        }
        
        public void MethodA(int someValue)
        {
            _parent.MethodA(someValue);
        }

        public /* override */ int MethodB(string someString)
        {
            Console.WriteLine("Child.MethodB({0})", someString);
            return 1;
        }
    }
}