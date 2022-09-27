using System.Reflection.Metadata;

namespace Hamsters;

public class Hamster : IComparable
{
    private readonly int _age;
    private readonly double _weight;
    private readonly double _height;
    private readonly double _woolValue;

    private Hamster(int age, double weight, double height, double woolValue)
    {
        _age = age;
        _weight = weight;
        _height = height;
        _woolValue = woolValue;
    }

    public override string ToString()
    {
        return "Hamster(" + _age + ", " + _weight + ", " + _height + ", " + _woolValue + ")";
    }

    public int CompareTo(object? obj)
    {
        if (obj is not Hamster other)
            return 1;

        if (_age < other._age)
            return -1;
        if (_age > other._age)
            return 1;

        var thisSomeValue = _height + _weight;
        var otherSomeValue = other._height + other._weight;
        if (thisSomeValue < otherSomeValue)
            return -1;
        if (thisSomeValue > otherSomeValue)
            return 1;

        if (_woolValue < other._woolValue)
            return -1;
        return _woolValue > other._woolValue ? 1 : 0;
    }

    public static Hamster CreateRandom()
    {
        var random = new Random();
        return new Hamster(
            age: Math.Abs(random.Next()) % 365,
            weight: Math.Round(random.NextDouble(), 3),
            height: Math.Round(random.NextDouble(), 3),
            woolValue: Math.Round(random.NextDouble(), 3)
        );
    }
}