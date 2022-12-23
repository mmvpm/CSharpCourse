namespace ZeroEvenOddSequence;

public class ZeroEvenOdd
{
    private readonly int _n;

    private int _order = 1;
    private readonly object _orderLock = new();

    public ZeroEvenOdd(int n)
    {
        _n = n;
    }

    // printNumber(x) outputs "x", where x is an integer.
    public void Zero(Action<int> printNumber) =>
        CommonPart(cycleSize: 2, cycleNum: 1, _ => printNumber(0));

    public void Even(Action<int> printNumber) =>
        CommonPart(cycleSize: 4, cycleNum: 0, order => printNumber(order / 2));

    public void Odd(Action<int> printNumber) =>
        CommonPart(cycleSize: 4, cycleNum: 2, order => printNumber(order / 2));

    private void CommonPart(int cycleSize, int cycleNum, Action<int> printNumberByOrder)
    {
        while (_order <= 2 * _n)
        {
            lock (_orderLock)
            {
                while (_order % cycleSize != cycleNum)
                {
                    Monitor.Wait(_orderLock);
                }

                if (_order <= 2 * _n)
                {
                    printNumberByOrder(_order);
                }

                _order += 1;
                Monitor.PulseAll(_orderLock);
            }
        }
    }
}