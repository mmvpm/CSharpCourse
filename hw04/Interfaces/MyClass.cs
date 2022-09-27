namespace Interfaces;

public class MyClass : AbstractClass, Interface1, Interface2
{
    public override void PrintName()
    {
        Console.WriteLine("=> MyClass");
    }

    void Interface1.PrintName()
    {
        Console.WriteLine("=> Interface1");
    }
    
    void Interface2.PrintName()
    {
        Console.WriteLine("=> Interface2");
    }
}