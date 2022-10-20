using LinqTasks;

string Task1(List<Element> elements, char delimiter)
{
    return elements.Count switch
    {
        <= 3 => "",
        _ => elements
            .Skip(3)
            .Select(e => e.Name)
            .Aggregate((acc, name) => acc + delimiter + name)
    };
}

IEnumerable<Element> Task2(IEnumerable<Element> elements)
{
    return elements
        .Where((e, index) => e.Name.Length > index);
}

List<List<string>> Task3(string sentence)
{
    IEnumerable<char> enumerableSentence = sentence;
    
    const string punctuation = ".?!.:;,-()\"'";
    foreach (var mark in punctuation)
    {
        enumerableSentence = enumerableSentence.Where(c => c != mark);
    }

    return string.Join("", enumerableSentence)
        .Split(" ")
        .GroupBy(word => word.Length)
        .Where(group => group.Any(word => word.Length > 0))
        .Select(group => group.ToList())
        .OrderByDescending(group => group.Count)
        .ThenByDescending(group => group.First().Length)
        .ToList();
}

IEnumerable<string> Task4(int n, List<string> englishWords, Dictionary<string, string> ruEnDictionary)
{
    return englishWords
        .Select(word => ruEnDictionary[word].ToUpper())
        .Chunk(n)
        .Select(chunk => string.Join(" ", chunk));
}

IEnumerable<string> Task5(string sentence, int numberOfChars)
{
    var chunks = new List<string>();
    foreach (var word in sentence.Split(" ").Where(w => w.Length > 0))
    {
        if (chunks.Count > 0 && chunks.Last().Length + word.Length + 1 <= numberOfChars)
            chunks[^1] += " " + word;
        else if (word.Length <= numberOfChars)
            chunks.Add(word);
        else
            return new List<string>();
    }
    return chunks;
}


// main

var elements = new List<Element>
{
    new Element("name1"),
    new Element("a"),
    new Element("Name"),
    new Element("b6"),
    new Element("aoaoaoa"),
    new Element("SomeVeryLongName777"),
};

Console.WriteLine(Task1(elements, '#'));
// Task1 Output: b6#aoaoaoa#SomeVeryLongName777

PrintList(Task2(elements));
// Task2 Output: [Element(name1), Element(Name), Element(aoaoaoa), Element(SomeVeryLongName777)]

var task3Result = Task3("Это что же получается: ходишь, ходишь в школу, а потом бац - вторая смена");
foreach (var group in task3Result)
{
    Console.WriteLine("Длина " + group.First().Length + ", Количество " + group.Count);
    Console.WriteLine(string.Join("\n", group) + "\n");
}
// Task3 Output:
/*
    Длина 6, Количество 3
    ходишь
    ходишь
    вторая

    Длина 5, Количество 3
    школу
    потом
    смена

    Длина 3, Количество 3
    Это
    что
    бац

    Длина 1, Количество 2
    в
    а

    Длина 10, Количество 1
    получается

    Длина 2, Количество 1
    же
*/

var ruEnDictionary = new Dictionary<string, string>()
{
    {"This", "это"}, {"dog", "собака"}, {"eats", "ест"}, {"too", "слишком"},
    {"much", "много"}, {"vegetables", "овощей"}, {"after", "после"}, {"lunch", "обед"}
};
var sentence = "This dog eats too much vegetables after lunch".Split(" ").ToList();
var task4Result = Task4(3, sentence, ruEnDictionary);
Console.WriteLine(string.Join("\n", task4Result));
// Task4 Output:
/*
    ЭТО СОБАКА ЕСТ
    СЛИШКОМ МНОГО ОВОЩЕЙ
    ПОСЛЕ ОБЕД
*/

PrintList(Task5("она продает морские раковины у моря", 16)); // [она продает, морские раковины, у моря]
PrintList(Task5("мышь прыгнула через сыр", 8));              // [мышь, прыгнула, через, сыр]
PrintList(Task5("волшебная пыль покрыла воздух", 15));       // [волшебная пыль, покрыла воздух]
PrintList(Task5("a b c d e ", 2));                           // [a, b, c, d, e] 
PrintList(Task5("aaaaaaaaaa", 3));                           // [] 


// util

void PrintList<T>(IEnumerable<T> list)
{
    Console.WriteLine("[" + string.Join(", ", list) + "]");
}