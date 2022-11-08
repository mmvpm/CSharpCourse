int PairMin((int, int) pair) =>
    Math.Min(pair.Item1, pair.Item2);

int PairMax((int, int) pair) =>
    Math.Max(pair.Item1, pair.Item2);

bool IsNested((int, int) outer, (int, int) inner) =>
    PairMax(outer) > PairMax(inner) && PairMin(outer) > PairMin(inner);

int MaxEnvelopes(List<(int, int)> envelopes)
{
    if (envelopes.Count == 0)
        return 0;

    envelopes.Sort((a, b) => PairMin(a).CompareTo(PairMin(b)));

    var maxSequence = new int[envelopes.Count];
    for (var i = 0; i < envelopes.Count; ++i)
    {
        maxSequence[i] = 1;
        for (var j = 0; j < i; ++j)
        {
            if (IsNested(envelopes[i], envelopes[j]) && maxSequence[j] + 1 > maxSequence[i])
            {
                maxSequence[i] = maxSequence[j] + 1;
            }
        }
    }
    
    return maxSequence.Max();
}

Console.WriteLine(MaxEnvelopes(new List<(int, int)> { (1, 1) })); // 1
Console.WriteLine(MaxEnvelopes(new List<(int, int)> { (1, 1), (1, 1), (1, 1) })); // 1
Console.WriteLine(MaxEnvelopes(new List<(int, int)> { (5, 4), (6, 4), (6, 7), (2, 3) })); // 3
Console.WriteLine(MaxEnvelopes(new List<(int, int)> { (7, 2), (8, 8), (1, 6), (5, 5), (4, 3), (1, 1), (2, 3) })); // 5