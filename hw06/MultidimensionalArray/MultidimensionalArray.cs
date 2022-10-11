using System.Collections;

namespace MultidimensionalArray;

public class MultidimensionalArray<T> : IEnumerable<T>
{
    private readonly Dictionary<Tuple<int, int, int>, T> _storage;

    public MultidimensionalArray()
    {
        _storage = new Dictionary<Tuple<int, int, int>, T>();
    }

    public T this[int i, int j, int k]
    {
        get => _storage[new Tuple<int, int, int>(i, j, k)];
        set => _storage[new Tuple<int, int, int>(i, j, k)] = value;
    }

    public IEnumerator<T> GetEnumerator()
    {
        foreach (var (_, value) in _storage)
        {
            yield return value;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}