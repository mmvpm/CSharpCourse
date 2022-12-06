using PrintSequentially;

int counter;
object locker;

void Print(int order, Action action)
{
    lock (locker)
    {
        while (counter < order)
            Monitor.Wait(locker);
        action();
        counter += 1;
        Monitor.PulseAll(locker);
    }
}

void Example()
{
    counter = 0;
    locker = new object();

    var a = new Thread(() => Print(0, Foo.First));
    var b = new Thread(() => Print(1, Foo.Second));
    var c = new Thread(() => Print(2, Foo.Third));
    var threads = new List<Thread> { a, b, c };

    var random = new Random();
    var threadsShuffled = threads.OrderBy(_ => random.Next()).ToList();
    threadsShuffled.ForEach(t => t.Start());
    threadsShuffled.ForEach(t => t.Join());

    Console.WriteLine();
}

for (var i = 0; i < 10; ++i)
{
    Example();
}

/* Output:

    firstsecondthird
    firstsecondthird
    firstsecondthird
    firstsecondthird
    firstsecondthird
    firstsecondthird
    firstsecondthird
    firstsecondthird
    firstsecondthird
    firstsecondthird
*/