string Fibonacci(int n)
{
    if (n < 2)
        return "invalid";

    var a = "a";
    var b = "b";
    var result = new List<string> { a, b };
    for (var i = 2; i < n; ++i)
    {
        (a, b) = (b, a + b);
        result.Add(b);
    }

    return string.Join(", ", result);
}

Console.WriteLine(Fibonacci(1)); // invalid
Console.WriteLine(Fibonacci(2)); // a, b
Console.WriteLine(Fibonacci(3)); // a, b, ab
Console.WriteLine(Fibonacci(4)); // a, b, ab, bab
Console.WriteLine(Fibonacci(5)); // a, b, ab, bab, abbab
Console.WriteLine(Fibonacci(7)); // a, b, ab, bab, abbab, bababbab, abbabbababbab
Console.WriteLine(Fibonacci(9)); // a, b, ab, bab, abbab, bababbab, abbabbababbab, bababbababbabbababbab, abbabbababbabbababbababbabbababbab