int OptimalDistance(List<int> houses, int mailboxesNumber)
{
    houses.Sort();
    return OptimalDistanceForSorted(houses, mailboxesNumber);
}

int OptimalDistanceForSorted(List<int> houses, int mailboxesNumber)
{
    if (houses.Count <= mailboxesNumber)
        return 0;
    
    var optimalDistance = int.MaxValue;
    
    if (mailboxesNumber == 1)
    {
        for (var mailboxPosition = houses.First(); mailboxPosition <= houses.Last(); ++mailboxPosition)
        {
            var position = mailboxPosition;
            var distance = houses.Sum(house => Math.Abs(house - position));
            optimalDistance = Math.Min(optimalDistance, distance);
        }
    }
    else
    {
        for (var splitIndex = 1; splitIndex <= houses.Count - 1; ++splitIndex)
        {
            var distanceLeft = 
                OptimalDistanceForSorted(houses.Take(splitIndex).ToList(), 1);
            var distanceRight = 
                OptimalDistanceForSorted(houses.Skip(splitIndex).ToList(), mailboxesNumber - 1);
            optimalDistance = Math.Min(optimalDistance, distanceLeft + distanceRight);
        }
    }

    return optimalDistance;
}

Console.WriteLine(OptimalDistance(new List<int> { 1, 4, 8, 10, 20 }, 3)); // 5
Console.WriteLine(OptimalDistance(new List<int> { 2, 3, 5, 12, 18 }, 2)); // 9
Console.WriteLine(OptimalDistance(new List<int> { 7, 4, 6, 1 }, 1)); // 8
Console.WriteLine(OptimalDistance(new List<int> { 3, 6, 14, 10 }, 4)); // 0
Console.WriteLine(OptimalDistance(new List<int> { 10, 11, 1, 1, 1, 4, 4, 20, 21, 23 }, 3)); // 10
