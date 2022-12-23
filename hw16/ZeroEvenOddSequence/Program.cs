using ZeroEvenOddSequence;

void Simulate(int n)
{
    var zeroEvenOdd = new ZeroEvenOdd(n);
    var threads = new List<Thread>
    {
        new(() => zeroEvenOdd.Zero(Console.Write)),
        new(() => zeroEvenOdd.Even(Console.Write)),
        new(() => zeroEvenOdd.Odd(Console.Write))
    };
    threads.ForEach(t => t.Start());
    threads.ForEach(t => t.Join());
    Console.WriteLine();
}

Simulate(1); // 01
Simulate(2); // 0102
Simulate(5); // 0102030405
Simulate(9); // 010203040506070809
