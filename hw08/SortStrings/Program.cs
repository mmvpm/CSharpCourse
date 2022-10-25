int CharComparison(char a, char b)
{
    if (char.IsLetter(a) && char.IsDigit(b))
        return -1;
    if (char.IsDigit(a) && char.IsLetter(b))
        return +1;
    if (char.IsDigit(a) && char.IsDigit(b))
        return a.CompareTo(b);
    if (!char.IsLetter(a) || !char.IsLetter(b))
        return a.CompareTo(b);
    // now (char.IsLetter(a) && char.IsLetter(b))
    if (char.IsLower(a) && char.IsLower(b) || char.IsUpper(a) && char.IsUpper(b))
        return a.CompareTo(b);
    if (string.Equals(a.ToString(), b.ToString(), StringComparison.OrdinalIgnoreCase) && a != b)
        return char.IsLower(a) ? -1 : +1;
    return string.Compare(a.ToString(), b.ToString(), StringComparison.OrdinalIgnoreCase);
}

string Sorting(string s)
{
    var chars = s.ToList();
    chars.Sort(CharComparison);
    return string.Join("", chars);
}

Console.WriteLine(Sorting("eA2a1E"));  // "aAeE12"
Console.WriteLine(Sorting("Re4r"));    // "erR4"
Console.WriteLine(Sorting("6jnM31Q")); // "jMnQ136"
Console.WriteLine(Sorting("846ZIbo")); // "bIoZ468" 
