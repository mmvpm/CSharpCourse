using SleepingBarber;

void Simple()
{
    var barber = new Barber(nChairs: 4);
    barber.AddClient(new Client("A", 1000));
    barber.AddClient(new Client("B", 1200));
    barber.AddClient(new Client("C", 500));
    barber.AddClient(new Client("D", 2000));
    barber.Terminate();
    Console.WriteLine();

    /* Output:

        + Added Client(A)
        + Added Client(B)
        + Added Client(C)
        + Added Client(D)
        - Served: Client(A)
        - Served: Client(B)
        - Served: Client(C)
        - Served: Client(D)
    */
}

void QueueOverflow()
{
    var barber = new Barber(nChairs: 2);
    barber.AddClient(new Client("A", 1000));
    barber.AddClient(new Client("B", 1200));
    barber.AddClient(new Client("C", 500));
    barber.AddClient(new Client("D", 2000));
    barber.Terminate();
    Console.WriteLine();

    /* Output:

        + Added Client(A)
        + Added Client(B)
        + Added Client(C)
        = Skipped Client(D)
        - Served: Client(A)
        - Served: Client(B)
        - Served: Client(C)
    */
}

void ManyClients()
{
    var barber = new Barber(nChairs: 3);
    barber.AddClient(new Client("A", 1000));
    barber.AddClient(new Client("B", 1200));
    Thread.Sleep(1100);
    barber.AddClient(new Client("C", 500));
    barber.AddClient(new Client("D", 2000));
    barber.AddClient(new Client("E", 500));
    barber.AddClient(new Client("F", 10000));
    Thread.Sleep(1300);
    barber.AddClient(new Client("G", 700));
    barber.Terminate();
    Console.WriteLine();

    /* Output:

        + Added Client(A)
        + Added Client(B)
        - Served: Client(A)
        + Added Client(C)
        + Added Client(D)
        + Added Client(E)
        = Skipped Client(F)
        - Served: Client(B)
        + Added Client(G)
        - Served: Client(C)
        - Served: Client(D)
        - Served: Client(E)
        - Served: Client(G)
    */
}


Simple();
QueueOverflow();
ManyClients();