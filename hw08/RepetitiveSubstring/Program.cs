string LongestRepetitiveSubstring(string s)
{
    var result = "";
    for (var i = 0; i < s.Length; ++i)
    {
        for (var j = i + 1; j < s.Length; ++j)
        {
            var k = 0;
            for (; Math.Max(i + k, j + k) < s.Length && s[i + k] == s[j + k]; ++k) {}

            if (k > result.Length)
            {
                result = s.Substring(i, k);
            }
        }
    }

    return result;
} 

Console.WriteLine(LongestRepetitiveSubstring("")); // ""
Console.WriteLine(LongestRepetitiveSubstring("a")); // ""
Console.WriteLine(LongestRepetitiveSubstring("abcd")); // ""
Console.WriteLine(LongestRepetitiveSubstring("abacaba")); // "aba"
Console.WriteLine(LongestRepetitiveSubstring("mask4cask")); // "ask"
Console.WriteLine(LongestRepetitiveSubstring("sdwoerkjlswoerwoettq")); // "woer"
Console.WriteLine(LongestRepetitiveSubstring("aaaaa")); // "aaaa"