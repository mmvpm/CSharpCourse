using System.Collections.Concurrent;

void SortTask(ref List<int> elementsToSort, int startIndex, int batchSize)
{
    var realBatchSize = Math.Min(batchSize, elementsToSort.Count - startIndex);
    elementsToSort.Sort(startIndex, realBatchSize, Comparer<int>.Default);
    Thread.Sleep(new Random().Next() % 2000);
}

List<int> MergeTask(IReadOnlyList<int> left, IReadOnlyList<int> right)
{
    var result = new List<int>();
    var (leftIndex, rightIndex) = (0, 0);

    while (leftIndex < left.Count && rightIndex < right.Count)
    {
        result.Add(left[leftIndex] < right[rightIndex] ? left[leftIndex++] : right[rightIndex++]);
    }

    while (leftIndex < left.Count)
    {
        result.Add(left[leftIndex++]);
    }

    while (rightIndex < right.Count)
    {
        result.Add(right[rightIndex++]);
    }

    return result;
}

List<int> MergeSort(List<int> elementsToSort, int nThreads)
{
    var batchSize = (elementsToSort.Count + nThreads - 1) / nThreads;

    var result = new List<int>();
    var resultLock = new object();
    var finishedTasks = new ConcurrentQueue<int>();

    var tasks = new List<Task>();
    for (var i = 0; i < nThreads; ++i)
    {
        var startIndex = i * batchSize;
        var task = Task.Run(() => SortTask(ref elementsToSort, startIndex, batchSize));
        task.ContinueWith(_ =>
        {
            lock (resultLock)
            {
                finishedTasks.Enqueue(startIndex);
                Monitor.Pulse(resultLock);
            }
        });
        tasks.Add(task);
    }

    while (result.Count != elementsToSort.Count)
    {
        lock (resultLock)
        {
            while (finishedTasks.IsEmpty)
            {
                Monitor.Wait(resultLock);
            }
            if (finishedTasks.TryDequeue(out var startIndex))
            {
                var realBatchSize = Math.Min(batchSize, elementsToSort.Count - startIndex);
                var sortedBatch = elementsToSort.GetRange(startIndex, realBatchSize);
                result = MergeTask(result, sortedBatch);
            }
        }
    }

    Task.WaitAll(tasks.ToArray());
    return result;
}

void RunExample(int nThreads, params int[] elements)
{
    Console.WriteLine(string.Join(" ", MergeSort(new List<int>(elements), nThreads)));
}

RunExample((1), 1); // 1
RunExample((1), 5, 2, 3, 1, 4); // 1 2 3 4 5
RunExample((5), 5, 2, 3, 1, 4); // 1 2 3 4 5
RunExample((6), 5, 2, 3, 1, 4); // 1 2 3 4 5
RunExample((8), 9, 4, 1, 6, 2, 8, 7, 2, 3, 1, 9, 5, 2, 4, 6); // 1 1 2 2 2 3 4 4 5 6 6 7 8 9 9
