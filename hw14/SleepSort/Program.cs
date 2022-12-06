const int maxListSize = 100;

List<string> Sort(List<string> list)
{
    object locker = new();
    var result = new List<string>();

    var threads = list.Select(item => {
        return new Thread(() => {
            Thread.Sleep(item.Length * maxListSize);
            lock (locker)
            {
                result.Add(item);
            }
        });
    }).ToList();
    
    threads.ForEach(t => t.Start());
    threads.ForEach(t => t.Join());

    return result;
}

var list = new List<string>
{
    "scala", "c", "cpp", "java", "rust", "c#", "kotlin",
    "f#", "haskell", "python", "go", "sql", "javascript"
};
var sortedList = Sort(list);
Console.WriteLine(string.Join(" ", sortedList));
// Output: c f# go c# cpp sql rust java scala kotlin python haskell javascript
