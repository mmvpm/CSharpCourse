namespace CustomCache;

public class Cache<T> where T : class, IDisposable
{
    private readonly Dictionary<int, T> _storage;
    private readonly Dictionary<int, DateTime> _lastAccessAt;

    private readonly int _maxStorageSize;
    private readonly TimeSpan _maxTimeWithoutAccess;

    private int _nextIndex;
    private volatile bool _needToClearGc;

    public int Count => _storage.Count;

    public Cache(int maxSize, TimeSpan maxTimeWithoutAccess)
    {
        _storage = new Dictionary<int, T>(capacity: maxSize);
        _lastAccessAt = new Dictionary<int, DateTime>(capacity: maxSize);
        _maxStorageSize = maxSize;
        _maxTimeWithoutAccess = maxTimeWithoutAccess;
        _nextIndex = 0;
        _needToClearGc = false;
        
        GC.RegisterForFullGCNotification(10, 10);
        StartGcThread();
    }

    ~Cache()
    {
        Clear();
    }

    public int? Add(T element)
    {
        if (_needToClearGc || _storage.Count + 1 > _maxStorageSize)
            Clear();
        if (_storage.Count + 1 > _maxStorageSize)
            return null;

        _storage[_nextIndex] = element;
        _lastAccessAt[_nextIndex] = DateTime.Now;
        _nextIndex += 1;
        return _nextIndex - 1;
    }

    public T? GetById(int id)
    {
        if (_needToClearGc)
            Clear();
        if (!_storage.ContainsKey(id))
            return null;

        _lastAccessAt[id] = DateTime.Now;
        return _storage[id];
    }

    private void Clear()
    {
        var idToRemove = new List<int>();
        foreach (var (id, dateTime) in _lastAccessAt)
        {
            var timeLeft = DateTime.Now - dateTime;
            if (timeLeft > _maxTimeWithoutAccess)
            {
                idToRemove.Add(id);
            }
        }
        foreach (var id in idToRemove)
        {
            _storage[id].Dispose();
            _storage.Remove(id);
            _lastAccessAt.Remove(id);
        }

        if (_needToClearGc)
        {
            StartGcThread();
            _needToClearGc = false;
            Console.WriteLine("_needToClearGc = false;");
        }
    }

    private void StartGcThread() =>
        new Thread(CheckTheGc).Start();

    private void CheckTheGc()
    {
        while (true)
        {
            if (GC.WaitForFullGCApproach() == GCNotificationStatus.Succeeded)
            {
                _needToClearGc = true;
                break;
            }
        }
    }
}