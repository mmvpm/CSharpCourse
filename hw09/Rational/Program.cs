using System.Text;

string Rational(int a, int b)
{
    if (a % b == 0)
        return (a / b).ToString();

    var result = new StringBuilder();
    var remainders = new List<int>();

    result.Append(a / b);

    var intLength = result.Length;
    result.Append('.');
    remainders.Add(a % b);

    a = a % b * 10;
    var hasPeriod = false;
    while (a % b != 0)
    {
        if (remainders.Contains(a % b))
        {
            hasPeriod = true;
            break;
        }
        result.Append(a / b);
        remainders.Add(a % b);
        a = a % b * 10;
    }
    result.Append(a / b);
    if (!hasPeriod) 
        return result.ToString();
    
    var periodStartIndex = remainders.IndexOf(a % b);
    var stringResult = result.ToString();
    var beforePeriod = stringResult[..(periodStartIndex + intLength + 1)];
    var period = stringResult[(periodStartIndex + intLength + 1)..];
    return beforePeriod + "(" + period + ")";
}

Console.WriteLine(Rational(5, 5));     // 1
Console.WriteLine(Rational(10, 2));    // 5
Console.WriteLine(Rational(2, 5));     // 0.4
Console.WriteLine(Rational(1, 6));     // 0.1(6)
Console.WriteLine(Rational(1, 3));     // 0.(3)
Console.WriteLine(Rational(1, 7));     // 0.(142857)
Console.WriteLine(Rational(1, 77));    // 0.(012987)
Console.WriteLine(Rational(379, 60));  // 6.31(6)
Console.WriteLine(Rational(719, 990)); // 0.7(26)