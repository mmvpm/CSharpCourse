using CustomCache;

void PrintMaybeNull<T>(T value) =>
    Console.WriteLine(value == null ? "null" : value);

void ClearAfterAddExample()
{
    const int maxSize = 5;
    var maxTimeSpan = new TimeSpan(0, 0, seconds: 2);
    var cache = new Cache<FileStreamWrapper>(maxSize, maxTimeSpan);

    var fileStreamWrappers = new List<FileStreamWrapper>();
    for (var i = 0; i < maxSize; ++i)
    {
        fileStreamWrappers.Add(new FileStreamWrapper(i + ".txt"));
    }

    var indicesInCache = new List<int>();
    for (var i = 0; i < maxSize; ++i)
    {
        var newId = cache.Add(fileStreamWrappers[i]);
        indicesInCache.Add(newId!.Value);
    }

    foreach (var id in indicesInCache)
    {
        Console.WriteLine(cache.GetById(id));
    }
    /* Output:

        FSW(name = 0.txt, disposed = False)
        FSW(name = 1.txt, disposed = False)
        FSW(name = 2.txt, disposed = False)
        FSW(name = 3.txt, disposed = False)
        FSW(name = 4.txt, disposed = False)
    */

    var idShouldBeNull = cache.Add(new FileStreamWrapper("5.txt"));
    PrintMaybeNull(idShouldBeNull); // Output: null

    Thread.Sleep(maxTimeSpan); // waiting for 2 seconds

    var idShouldBeNotNull = cache.Add(new FileStreamWrapper("6.txt"));
    PrintMaybeNull(idShouldBeNotNull); // Output: 5

    foreach (var id in indicesInCache)
    {
        PrintMaybeNull(cache.GetById(id)); // `null` expected
    }
    /* Output:

        null
        null
        null
        null
        null
    */

    foreach (var wrapper in fileStreamWrappers)
    {
        Console.WriteLine(wrapper);
    }
    /* Output

        FSW(name = 0.txt, disposed = True)
        FSW(name = 1.txt, disposed = True)
        FSW(name = 2.txt, disposed = True)
        FSW(name = 3.txt, disposed = True)
        FSW(name = 4.txt, disposed = True)
    */

    var renewWrapperId = cache.Add(new FileStreamWrapper("1.txt"));
    PrintMaybeNull(renewWrapperId); // Output: 6
    PrintMaybeNull(cache.GetById(renewWrapperId!.Value)); // Output: FSW(name = 1.txt, disposed = False)
}

void ClearDuringGarbageCollectionExample()
{
    var data = new List<byte[]>();

    const int maxSize = 1000;
    var maxTimeSpan = new TimeSpan(0, 0, seconds: 1);
    var cache = new Cache<FileStreamWrapper>(maxSize, maxTimeSpan);
    
    var secondsPassed = 0;
    var lastCacheCount = 0;
    while (true)
    {
        for (var i = 0; i < 1000; i++)
            data.Add(new byte[1000]);

        var wrapper = new FileStreamWrapper(secondsPassed++ + ".log");
        cache.Add(wrapper);
        Console.WriteLine("cache.Count = " + cache.Count);

        if (cache.Count < lastCacheCount)
            break;
        lastCacheCount = cache.Count;

        Thread.Sleep(1000);
    }
    /* Output:
    
        cache.Count = 1
        cache.Count = 2
        cache.Count = 3
        cache.Count = 4
        cache.Count = 5
        cache.Count = 6
        cache.Count = 7
        cache.Count = 8
        cache.Count = 9
        cache.Count = 10
        cache.Count = 11
        cache.Count = 12
        cache.Count = 13
        cache.Count = 14
        cache.Count = 15
        cache.Count = 16 <--- Garbage Collection
        cache.Count = 1
    */
}

ClearAfterAddExample();
ClearDuringGarbageCollectionExample();
