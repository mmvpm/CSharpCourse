int? FindFirst(string s, List<string> list, int searchStartIndex = 0)
{
    for (var i = searchStartIndex; i < list.Count; ++i)
        if (s == list[i])
            return i;
    return null;
}

string MergeStrings(string s, string t)
{
    var sWords = s.Split(" ").ToList();
    var tWords = t.Split(" ").ToList();
    var resultWords = new List<string>();

    var sIndex = 0;
    var tIndex = 0;
    while (sIndex < sWords.Count && tIndex < tWords.Count)
    {
        if (sWords[sIndex] == tWords[tIndex])
        {
            resultWords.Add(sWords[sIndex]);
            sIndex++;
            tIndex++;
            continue;
        }

        var sWordIndexInT = FindFirst(sWords[sIndex], tWords, tIndex + 1);
        if (sWordIndexInT == null)
        {
            resultWords.Add(sWords[sIndex]);
            sIndex++;
        }
        else
        {
            for (var i = tIndex; i < sWordIndexInT; ++i)
                resultWords.Add(tWords[i]);
            tIndex = (int) sWordIndexInT;
        }
    }
    
    for (; sIndex < sWords.Count; ++sIndex)
        resultWords.Add(sWords[sIndex]);
    for (; tIndex < tWords.Count; ++tIndex)
        resultWords.Add(tWords[tIndex]);

    return string.Join(" ", resultWords);
}

new List<(string, string)>
{
    ("Шла Маша по шоссе пешком", "Шла Саша по горе"), // Шла Маша Саша по шоссе пешком горе
    ("a a b b b c d e", "a b d f f"), // a a b b b c d e f f
    ("def f ( a: Int, c: List[CaseClass] )", "def g ( c: Int )"), // def f g ( a: Int, c: List[CaseClass] Int )
}.ForEach(testCase =>
    Console.WriteLine(MergeStrings(testCase.Item1, testCase.Item2))
);