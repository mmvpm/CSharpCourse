bool isPalindrome(long number)
{
    var stringNumber = number.ToString();
    for (var i = 0; i < stringNumber.Length / 2; i++)
    {
        if (stringNumber[i] != stringNumber[stringNumber.Length - i - 1])
        {
            return false;
        }
    }

    return true;
}

(long, int)? PalSeq(long palindrome)
{
    if (palindrome < 10)
    {
        return (palindrome, 0);
    }

    for (var startNumber = 10L; startNumber < 1e4; startNumber++)
    {
        var steps = 0;
        var current = startNumber;
        while (current < palindrome && !isPalindrome(current))
        {
            var reversed = string.Join("", current.ToString().Reverse());
            current += long.Parse(reversed!);
            steps += 1;
        }

        if (current == palindrome)
        {
            return (startNumber, steps);
        }
    }
    return null;
}

var examples = new List<long> { 4884, 1, 0, 11, 3113, 8836886388 };
foreach (var example in examples)
{
    Console.WriteLine("PalSeq(" + example + ") -> " + PalSeq(example));
}
/*
    PalSeq(4884) -> (69, 4)
    PalSeq(1) -> (1, 0)
    PalSeq(0) -> (0, 0)
    PalSeq(11) -> (10, 1)
    PalSeq(3113) -> (199, 3)
    PalSeq(8836886388) -> (177, 15)
*/