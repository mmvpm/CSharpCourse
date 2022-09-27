long LuckyTicket(int numberLength)
{
    if (numberLength % 2 != 0)
    {
        return 0;
    }

    var halfLength = numberLength / 2;
    var maxSum = 9 * halfLength;
    var countNumbersWithSum = Enumerable
        .Repeat(0L, halfLength + 1)
        .Select(_ =>
            Enumerable.Repeat(0L, maxSum + 1).ToList()
        ).ToList();

    countNumbersWithSum[0][0] = 1;
    for (var len = 1; len <= halfLength; ++len)
    {
        for (var sum = 0; sum <= maxSum; ++sum)
        {
            for (var k = 0; k <= Math.Min(9, sum); ++k)
            {
                countNumbersWithSum[len][sum] += countNumbersWithSum[len - 1][sum - k];
            }
        }
    }

    var answer = 0L;
    for (var sum = 0; sum <= maxSum; sum++)
    {
        answer += countNumbersWithSum[halfLength][sum] * countNumbersWithSum[halfLength][sum];
    }
    
    return answer;
}

Console.WriteLine("LuckyTicket(2) = " + LuckyTicket(2));   // = 10
Console.WriteLine("LuckyTicket(4) = " + LuckyTicket(4));   // = 670
Console.WriteLine("LuckyTicket(6) = " + LuckyTicket(6));   // = 55252
Console.WriteLine("LuckyTicket(8) = " + LuckyTicket(8));   // = 4816030
Console.WriteLine("LuckyTicket(10) = " + LuckyTicket(10)); // = 432457640
Console.WriteLine("LuckyTicket(12) = " + LuckyTicket(12)); // = 39581170420
Console.WriteLine("LuckyTicket(14) = " + LuckyTicket(14)); // = 3671331273480