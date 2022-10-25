bool DifferenceInOneChar(string s, string t)
{
    if (Math.Abs(s.Length - t.Length) > 1)
        return false;
    if (s.Length > t.Length)
        (s, t) = (t, s);
    // now s.Length <= t.Length

    var firstDifferentChar = 0;
    for (; firstDifferentChar < s.Length; ++firstDifferentChar)
    {
        if (s[firstDifferentChar] != t[firstDifferentChar])
            break;
    }

    if (firstDifferentChar == s.Length)
        return t.Length > s.Length;

    string sSuffix;
    string tSuffix;

    if (s.Length == t.Length)
    {
        sSuffix = s.Substring(firstDifferentChar + 1, s.Length - firstDifferentChar - 1);
        tSuffix = t.Substring(firstDifferentChar + 1, t.Length - firstDifferentChar - 1);
    }
    else // s.Length + 1 == t.Length
    {
        sSuffix = s.Substring(firstDifferentChar, s.Length - firstDifferentChar);
        tSuffix = t.Substring(firstDifferentChar + 1, t.Length - firstDifferentChar - 1);
    }

    return sSuffix == tSuffix;
}

new List<(string, string)>
{
    ("", ""), // False
    ("", "a"), // True
    ("a", ""), // True
    ("a", "a"), // False
    ("a", "b"), // True
    ("a", "ab"), // True
    ("a", "ba"), // True
    ("a", "aba"), // False
    ("ab", "aba"), // True
    ("aba", "aba"), // False
    ("some string", "somestring"), // True
    ("some string", "some ttring"), // True
    ("some strin", "some ttring"), // False
    ("Some string", "some string"), // True
    ("Some string", "some String"), // False
    ("some string", "another string"), // False
}.ForEach(testCase =>
    Console.WriteLine(DifferenceInOneChar(testCase.Item1, testCase.Item2))
);