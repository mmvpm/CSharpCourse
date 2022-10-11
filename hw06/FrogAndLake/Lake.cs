using System.Collections;

namespace FrogAndLake;

public class Lake : IEnumerable<int>
{
    private List<int> _stones;

    public Lake(List<int> stones)
    {
        _stones = stones;
    }

    public IEnumerator<int> GetEnumerator()
    {
        var i = 0;
        for (; i < _stones.Count; i += 2)
        {
            yield return _stones[i];
        }

        i -= 2;
        if (_stones.Count % 2 == 0)
            i += 1;

        for (; i >= 0; i -= 2)
        {
            yield return _stones[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}