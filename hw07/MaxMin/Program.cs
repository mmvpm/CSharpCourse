List<char> SwapTwoChars(int i, int j, List<char> list)
{
    var result = new List<char> (list);
    (result[i], result[j]) = (result[j], result[i]);
    return result;
}

ulong DigitsToULong(List<char> digits)
{
    return ulong.Parse(string.Join("", digits));
}

ulong[] MaxMin(ulong number)
{
    var digits = number.ToString().ToList();

    var allPermutations = new List<ulong> { number };
    for (var i = 0; i < digits.Count; ++i)
    {
        for (int j = i + 1; j < digits.Count; ++j)
        {
            var newDigits = SwapTwoChars(i, j, digits);
            if (newDigits[0] == '0')
                continue;
            var newNumber = DigitsToULong(newDigits);
            allPermutations.Add(newNumber);
        }
    }
    
    return new[] { allPermutations.Max(), allPermutations.Min() };
}

Console.WriteLine("[" + string.Join(", ", MaxMin(12340)) + "]"); // [42310, 10342]
Console.WriteLine("[" + string.Join(", ", MaxMin(98761)) + "]"); // [98761, 18769]
Console.WriteLine("[" + string.Join(", ", MaxMin(9000)) + "]");  // [9000, 9000]
Console.WriteLine("[" + string.Join(", ", MaxMin(11321)) + "]"); // [31121, 11123]
