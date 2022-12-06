int number;

void MaybeSleep()
{
    if (new Random().Next() % 2 == 1)
    {
        Thread.Sleep(1);
    }
}

void IncrementNumber(int by)
{
    MaybeSleep();
    if (number == 0)
    {
        MaybeSleep();
        number += by;
    }
}

void Example()
{
    number = 0;
    var t1 = new Thread(_ => IncrementNumber(by: 1));
    var t2 = new Thread(_ => IncrementNumber(by: 2));
    t1.Start();
    t2.Start();
    t1.Join();
    t2.Join();
    Console.WriteLine("number = " + number);
}

for (var i = 0; i < 10; ++i)
{
    Example();
}
/* Output:

    number = 3
    number = 3
    number = 3
    number = 1
    number = 3
    number = 2
    number = 1
    number = 3
    number = 1
    number = 3
*/