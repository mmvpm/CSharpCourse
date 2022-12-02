void PrintNTimes(int n)
{
    var counter = 0;
    object locker = new();
    var foobar = new FooBar.FooBar(n);
    
    void PrintFoo()
    {
        while (true)
        {
            lock (locker)
            {
                if (counter % 2 != 0) continue;
                counter += 1;
                Console.Write("foo");
                break;
            }
        }
    }

    void PrintBar()
    {
        while (true)
        {
            lock (locker)
            {
                if (counter % 2 != 1) continue;
                counter += 1;
                Console.WriteLine("bar");
                break;
            }
        }
    }

    var t1 = new Thread(_ => foobar.Foo(PrintFoo));
    var t2 = new Thread(_ => foobar.Bar(PrintBar));

    Console.WriteLine("n = " + n + ":");
    t1.Start();
    t2.Start();
    t1.Join();
    t2.Join();
    Console.WriteLine();
}

PrintNTimes(1);
PrintNTimes(3);
PrintNTimes(7);

/* Output:

    n = 1:
    foobar

    n = 3:
    foobar
    foobar
    foobar

    n = 7:
    foobar
    foobar
    foobar
    foobar
    foobar
    foobar
    foobar
*/