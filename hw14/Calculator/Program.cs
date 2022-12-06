using System.Globalization;

const string pathPrefix = "../../../files/";

(int, float, float) ReadFile(string name)
{
    using var reader = File.OpenText(pathPrefix + name);
    var operation = int.Parse(reader.ReadLine()!);
    var numbers = reader
        .ReadLine()!
        .Split(" ")
        .Select(f => float.Parse(f, CultureInfo.InvariantCulture))
        .ToList();
    return (operation, numbers[0], numbers[1]);
}

float Compute(int operation, float a, float b) =>
    operation switch
    {
        1 => a + b,
        2 => a * b,
        3 => a * a + b * b,
        _ => throw new Exception("Unknown operation: " + operation)
    };

void WriteResult(string label, float result)
{
    using var writer = File.AppendText(pathPrefix + "out.dat");
    writer.Write(label + ": ");
    writer.WriteLine(result.ToString(CultureInfo.InvariantCulture));
}

object locker = new();

void ThreadWork(string fileName)
{
    var (operation, a, b) = ReadFile(fileName);
    var result = Compute(operation, a, b);
    lock (locker)
    {
        WriteResult(fileName, result);
    }
}

void Example(int nThreads, List<string> fileNames)
{
    var batchSize = (fileNames.Count + nThreads - 1) / nThreads;
    var batches = fileNames.Chunk(batchSize).Select(b => b.ToList()).ToList();

    var threads = batches.Select(batch => {
        return new Thread(() => batch.ForEach(ThreadWork));
    }).ToList();

    threads.ForEach(t => t.Start());
    threads.ForEach(t => t.Join());
}

Example(nThreads: 7, fileNames: Enumerable.Range(0, 100).Select(i => i + ".txt").ToList());
