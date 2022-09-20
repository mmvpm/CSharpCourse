long GCD(long a, long b)
{
    return a == 0 ? b : GCD(b % a, a);
}

string Simplify(string fraction)
{
    var numbers = fraction.Split("/");
    if (numbers.Length != 2)
    {
        throw new Exception("Incorrect fraction");
    }

    var numerator = long.Parse(numbers[0]);
    var denominator = long.Parse(numbers[1]);
    var gcd = GCD(numerator, denominator);
    return numerator / gcd + "/" + denominator / gcd;
}

var examples = new List<string> { "1/2", "2/4", "4/6", "10/11", "100/400", "8/4", "7/33", "33/7" };  

foreach (var example in examples)
{
    Console.WriteLine("Simplify(" + example + ") = " + Simplify(example));
}
/*
    Simplify(1/2) = 1/2
    Simplify(2/4) = 1/2
    Simplify(4/6) = 2/3
    Simplify(10/11) = 10/11
    Simplify(100/400) = 1/4
    Simplify(8/4) = 2/1
    Simplify(7/33) = 7/33
    Simplify(33/7) = 33/7
*/