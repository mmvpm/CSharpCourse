using System.Collections.Concurrent;

namespace SleepingBarber;

public class Barber
{
    private readonly int _nChairs;
    private readonly ConcurrentQueue<Client> _clientQueue;

    private bool _isTerminated;
    private readonly object _workLocker;
    private readonly Task _barberTask;

    public Barber(int nChairs)
    {
        _nChairs = nChairs;
        _clientQueue = new ConcurrentQueue<Client>();
        _isTerminated = false;
        _workLocker = new object();
        _barberTask = Task.Run(Work);
    }

    public void AddClient(Client client)
    {
        if (_clientQueue.Count == _nChairs)
        {
            Console.WriteLine("= Skipped " + client);
        }

        _clientQueue.Enqueue(client);
        Console.WriteLine("+ Added " + client);
        lock (_workLocker)
        {
            Monitor.Pulse(_workLocker);
        }
    }

    public void Terminate()
    {
        _isTerminated = true;
        _barberTask.Wait();
    }

    private void Work()
    {
        while (!(_isTerminated &&_clientQueue.IsEmpty))
        {
            lock (_workLocker)
            {
                while (_clientQueue.IsEmpty)
                {
                    Monitor.Wait(_workLocker);
                }
            }
            if (_clientQueue.TryDequeue(out var client))
            {
                Thread.Sleep(client.RequiredWorkMilliseconds);
                Console.WriteLine("- Served: " + client);
            }
        }
    }
}