string LongestRepetitiveSubstring(string s)
{
    var result = "";
    for (var startIndex1 = 0; startIndex1 < s.Length; ++startIndex1)
    {
        for (var startIndex2 = startIndex1 + 1; startIndex2 < s.Length; ++startIndex2)
        {
            var length = 0;
            while (Math.Max(startIndex1 + length, startIndex2 + length) < s.Length && 
                   s[startIndex1 + length] == s[startIndex2 + length])
            {
                length++;
            }

            if (length > result.Length)
            {
                result = s.Substring(startIndex1, length);
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