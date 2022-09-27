namespace Delegates;

public delegate double Function(double x);

internal static class Program
{
    private static double Integrate(Function f, double a, double b)
    {
        const int segments = (int) 1e6;

        var result = 0.0;
        var step = (b - a) / segments;
        for (var i = 0; i <= segments; ++i)
        {
            var x = a + step * i;
            result += f(x) * step;
        }
        return result;
    }
    
    public static void Main()
    {
        var identity = new Function(x => x);
        var sin = new Function(Math.Sin);
        var sinCos = new Function(x => Math.Sin(x) * Math.Cos(x));

        Console.WriteLine(Integrate(identity, 0, 1));                   // 0,5000005000000001
        Console.WriteLine(Integrate(sin, 0, Math.PI));                  // 1,9999999999983495
        Console.WriteLine(Integrate(sin, -Math.PI, Math.PI));           // -2,1050541816778272E-16
        Console.WriteLine(Integrate(sinCos, Math.PI / 2, 3 * Math.PI)); // -0,49999999998972555
    } 
}