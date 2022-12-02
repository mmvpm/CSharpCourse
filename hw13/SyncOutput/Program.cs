var counter = 0;
object locker = new();

void Function1()
{
    while (true)
    {
        lock (locker)
        {
            if (counter > 19) break;
            if (counter % 2 != 0) continue;
            counter += 1;
            Console.WriteLine("Function 1: " + counter);
        }
    }
}

void Function2()
{
    while (true)
    {
        lock (locker)
        {
            if (counter > 19) break;
            if (counter % 2 != 1) continue;
            counter += 1;
            Console.WriteLine("Function 2: " + counter);
        }
    }
}

var t1 = new Thread(Function1);
var t2 = new Thread(Function2);

t1.Start();
t2.Start();
