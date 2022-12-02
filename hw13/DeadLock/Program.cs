object locker1 = new();
object locker2 = new();

void Function1()
{
    lock (locker1)
    {
        Thread.Sleep(1000);
        lock (locker2)
        {
            Console.WriteLine("function 1");
        }
    }
}

void Function2()
{
    lock (locker2)
    {
        Thread.Sleep(1000);
        lock (locker1)
        {
            Console.WriteLine("function 2");
        }
    }
}

var t1 = new Thread(Function1);
var t2 = new Thread(Function2);

t1.Start();
t2.Start();

// Output: <nothing>
