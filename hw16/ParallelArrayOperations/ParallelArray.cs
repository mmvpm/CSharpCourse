namespace ParallelArrayOperations;

public class ParallelArray
{
    private readonly List<int> _array;
    private readonly Random _random;
    private bool _terminated;
    private readonly ReaderWriterLockSlim _readWriteLock;
    
    public ParallelArray(List<int> array)
    {
        _array = array;
        _random = new Random();
        _terminated = false;
        _readWriteLock = new ReaderWriterLockSlim();
    }
    
    public void ThreadAverage()
    {
        while (!_terminated)
        {
            _readWriteLock.EnterReadLock();
            var result = _array.Average();
            Console.WriteLine("Average: " + result);
            _readWriteLock.ExitReadLock();
            Thread.Sleep(_random.Next(10, 100));
        }
    }
    
    public void ThreadMin()
    {
        while (!_terminated)
        {
            _readWriteLock.EnterReadLock();
            var result = _array.Min();
            Console.WriteLine("Min: " + result);
            _readWriteLock.ExitReadLock();
            Thread.Sleep(_random.Next(10, 100));
        }
    }
    
    public void ThreadSwap()
    {
        while (!_terminated)
        {
            _readWriteLock.EnterWriteLock();
            var (i, j) = (_random.Next(_array.Count), _random.Next(_array.Count));
            (_array[i], _array[j]) = (_array[j], _array[i]);
            Console.WriteLine("Swap: array[" + i + "] = " + _array[i] + " & array[" + j + "] = " + _array[j]);
            _readWriteLock.ExitWriteLock();
            Thread.Sleep(_random.Next(50, 200));
        }
    }
    
    public void ThreadSort()
    {
        while (!_terminated)
        {
            _readWriteLock.EnterWriteLock();
            _array.Sort();
            Console.WriteLine("Sort: array = [" + string.Join(", ", _array) + "]");
            _readWriteLock.ExitWriteLock();
            Thread.Sleep(_random.Next(100, 1000));
        }
    }

    public void Terminate()
    {
        _terminated = true;
    } 
}