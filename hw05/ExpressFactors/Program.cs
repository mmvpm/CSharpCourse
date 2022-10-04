using System.Text;

string ExpressFactors(int number)
{
    var divisors = new List<string>();
    for (var divisor = 2; divisor <= number; divisor++)
    {
        if (number % divisor != 0)
            continue;
        var degree = 0;
        while (number % divisor == 0)
        {
            number /= divisor;
            degree++;
        }
        
        divisors.Add(divisor + (degree > 1 ? "^" + degree : ""));
    }

    return string.Join(" x ", divisors);
}

var inputs = new List<int> { 2, 4, 10, 60, 81, 144, 9997, 9999 };
inputs.ForEach(number =>
    Console.WriteLine("ExpressFactors(" + number + ") = " + ExpressFactors(number))
);

/*
    ExpressFactors(2) = 2
    ExpressFactors(4) = 2^2
    ExpressFactors(10) = 2 x 5
    ExpressFactors(60) = 2^2 x 3 x 5
    ExpressFactors(81) = 3^4
    ExpressFactors(144) = 2^4 x 3^2
    ExpressFactors(9997) = 13 x 769
    ExpressFactors(9999) = 3^2 x 11 x 101
*/