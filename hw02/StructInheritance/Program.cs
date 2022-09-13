namespace StructInheritance
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var parent = new Parent();
            parent.MethodA(2);   // "Parent.MethodA(2)"
            parent.MethodB("a"); // "Parent.MethodB(a)"

            var child = new Child(7);
            child.MethodA(3);   // "Parent.MethodA(3)"
            child.MethodB("b"); // "Child.MethodB(b)"
        }
    }
}