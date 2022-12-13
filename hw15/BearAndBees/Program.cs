object honeyLock;
int currentHoneyPortions;

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
            }
            else
            {
                break;
            }
        }
    }
}

void BearWork()
{
    lock (honeyLock)
    {
        currentHoneyPortions = 0;
        Console.WriteLine("- Bear, Honey = 0");
    }
}

void Simulate(int nBees, int maxHoneyPortions, int nIterations = 2)
{
    honeyLock = new object();

    for (var iteration = 0; iteration < nIterations; ++iteration)
    {
        Console.WriteLine("===== Iteration #" + iteration + " =====");
        currentHoneyPortions = 0;

        var bees = new List<Task>();
        for (var i = 0; i < nBees; ++i)
        {
            var beeIndex = i;
            bees.Add(Task.Run(() => BeeWork(beeIndex, maxHoneyPortions)));
        }

        Task.WhenAny(bees).ContinueWith(_ => Task.Run(BearWork)).Wait();
    }
}

Simulate(1, 2);
/* Output:

    ===== Iteration #0 =====
    + Bee #0, Honey = 1
    + Bee #0, Honey = 2
    - Bear, Honey = 0
    ===== Iteration #1 =====
    + Bee #0, Honey = 1
    + Bee #0, Honey = 2
    - Bear, Honey = 0    
*/

Simulate(3, 10);
/* Output:

    ===== Iteration #0 =====
    + Bee #0, Honey = 1
    + Bee #2, Honey = 2
    + Bee #1, Honey = 3
    + Bee #0, Honey = 4
    + Bee #1, Honey = 5
    + Bee #2, Honey = 6
    + Bee #1, Honey = 7
    + Bee #2, Honey = 8
    + Bee #0, Honey = 9
    + Bee #1, Honey = 10
    - Bear, Honey = 0
    ===== Iteration #1 =====
    + Bee #0, Honey = 1
    + Bee #2, Honey = 2
    + Bee #1, Honey = 3
    + Bee #1, Honey = 4
    + Bee #2, Honey = 5
    + Bee #0, Honey = 6
    + Bee #1, Honey = 7
    + Bee #1, Honey = 8
    + Bee #2, Honey = 9
    + Bee #2, Honey = 10
    - Bear, Honey = 0
*/