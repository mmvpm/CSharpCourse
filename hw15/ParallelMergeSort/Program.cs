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

List<int> MergeSort(List<int> elementsToSort, int nThreads, bool verbose = false)
{
    var batchSize = (elementsToSort.Count + nThreads - 1) / nThreads;
    nThreads = (elementsToSort.Count + batchSize - 1) / batchSize;

    var result = new List<int>();
    var resultLock = new object();
    var finishedTasks = new ConcurrentQueue<int>();

    var tasks = new List<Task>();
    for (var i = 0; i < nThreads; ++i)
    {
        var startIndex = i * batchSize;
        var task = Task.Run(() =>
        {
            SortTask(ref elementsToSort, startIndex, batchSize);
            if (verbose) Console.WriteLine("+ " + startIndex + " sorted");
        });
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
                if (verbose) Console.WriteLine("- " + startIndex + " merged");
            }
        }
    }

    Task.WaitAll(tasks.ToArray());
    return result;
}

void RunExample(int[] elements, int nThreads, bool verbose = false)
{
    Console.WriteLine(string.Join(" ", MergeSort(new List<int>(elements), nThreads, verbose)));
}

RunExample(new[] { 1 }, nThreads: 1); // 1
RunExample(new[] { 5, 2, 3, 1, 4 }, nThreads: 1); // 1 2 3 4 5
RunExample(new[] { 5, 2, 3, 1, 4}, nThreads: 6); // 1 2 3 4 5
RunExample(new[] { 9, 4, 1, 6, 2, 8, 7, 2, 3, 1, 9, 5, 2, 4, 6 }, nThreads: 8); // 1 1 2 2 2 3 4 4 5 6 6 7 8 9 9

RunExample(new[] { 5, 2, 3, 1, 4 }, nThreads: 4, verbose: true); // 1 2 3 4 5
/* Output:

    + 2 sorted
    - 2 merged
    + 4 sorted
    - 4 merged
    + 0 sorted
    - 0 merged
    1 2 3 4 5
*/

RunExample(new[] { -1, 67, 23, -9, 82, 1987, -121, 0, 0, 5, 893, 1 }, nThreads: 6, verbose: true); 
/* Output (verbose):

    + 8 sorted
    - 8 merged
    + 0 sorted
    - 0 merged
    + 4 sorted
    - 4 merged
    + 2 sorted
    - 2 merged
    + 6 sorted
    + 10 sorted
    - 6 merged
    - 10 merged
    -121 -9 -1 0 0 1 5 23 67 82 893 1987
*/
