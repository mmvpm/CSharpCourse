using ThreadsH2O;

object locker = new();
var (maxH, maxO) = (2, 1);
var (currentH, currentO) = (0, 0);

void ReleaseHydrogen()
{
    lock (locker)
    {
        while (!(currentH < maxH))
        {
            Monitor.Wait(locker);
        }

        Console.Write("H");
        currentH += 1;

        if (currentH == maxH && currentO == maxO)
        {
            Console.Write(" ");
            (currentH, currentO) = (0, 0);
            Monitor.PulseAll(locker);
        }
    }
}

void ReleaseOxygen()
{
    lock (locker)
    {
        while (!(currentO < maxO))
        {
            Monitor.Wait(locker);
        }

        Console.Write("O");
        currentO += 1;

        if (currentH == maxH && currentO == maxO)
        {
            (currentH, currentO) = (0, 0);
            Console.Write(" ");
            Monitor.PulseAll(locker);
        }
    }
}

void Simulate(string input)
{
    var h2O = new H2O();
    var threads = input.Select(c =>
            c == 'H' ? new Thread(() => h2O.Hydrogen(ReleaseHydrogen)) : new Thread(() => h2O.Oxygen(ReleaseOxygen)))
        .ToList();
    threads.ForEach(t => t.Start());
    threads.ForEach(t => t.Join());
    Console.WriteLine();
}

Simulate("HHO");             // OHH
Simulate("HHOHOH");          // HHO HOH
Simulate("OOOHHHHHH");       // OHH OHH HOH
Simulate("OOOHHHHHOOHHHHH"); // OHH OHH OHH HOH OHH
