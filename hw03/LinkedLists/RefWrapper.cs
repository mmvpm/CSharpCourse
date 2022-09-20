namespace LinkedLists;

internal class RefWrapper
{
    private readonly int _value;

    public RefWrapper(int value)
    {
        _value = value;
    }

    public override string ToString()
    {
        return "Ref(" + _value + ")";
    }
}