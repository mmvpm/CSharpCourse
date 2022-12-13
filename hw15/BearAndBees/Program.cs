object honeyLock = new();
var currentHoneyPortions = 0;

void BeeWork(int beeIndex, int maxHoneyPortions)
{
    var random = new Random();
    while (true)
    {
        Thread.Sleep(random.Next() % 100);
        
        lock (honeyLock)
        {
            if (currentHoneyPortions < maxHoneyPortions)
            {
                currentHoneyPortions++;
                Console.WriteLine("+ Bee #" + beeIndex + ", Honey = " + currentHoneyPortions);
                Monitor.PulseAll(honeyLock);
            }
        }
    }
}

void BearWork(int maxHoneyPortions)
{
    while (true)
    {
        lock (honeyLock) {
            while (currentHoneyPortions < maxHoneyPortions)
            {
                Monitor.Wait(honeyLock);
            }
            
            currentHoneyPortions = 0;
            Console.WriteLine("- Bear, Honey = 0");
        }
    }
}

void Simulate(int nBees, int maxHoneyPortions)
{
    for (var i = 0; i < nBees; ++i)
    {
        var beeIndex = i;
        Task.Run(() => BeeWork(beeIndex, maxHoneyPortions));
    }
    Task.Run(() => BearWork(maxHoneyPortions)).Wait();
}

Simulate(1, 2);
/* Output:

    + Bee #0, Honey = 1
    + Bee #0, Honey = 2
    - Bear, Honey = 0
    + Bee #0, Honey = 1
    + Bee #0, Honey = 2
    - Bear, Honey = 0
    + Bee #0, Honey = 1
    ...
*/

Simulate(3, 7);
/* Output:

    + Bee #2, Honey = 1
    + Bee #1, Honey = 2
    + Bee #0, Honey = 3
    + Bee #1, Honey = 4
    + Bee #0, Honey = 5
    + Bee #2, Honey = 6
    + Bee #1, Honey = 7
    - Bear, Honey = 0
    + Bee #0, Honey = 1
    + Bee #0, Honey = 2
    + Bee #1, Honey = 3
    + Bee #0, Honey = 4
    + Bee #2, Honey = 5
    + Bee #2, Honey = 6
    + Bee #1, Honey = 7
    - Bear, Honey = 0
    + Bee #0, Honey = 1
    + Bee #0, Honey = 2
    + Bee #2, Honey = 3
    ...
*/