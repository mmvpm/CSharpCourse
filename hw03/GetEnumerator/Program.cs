namespace GetEnumerator;

/*
    var x = new
    {
        Items = new List<int> { 1, 2, 3 }.GetEnumerator()
    };
    while (x.Items.MoveNext())
        Console.WriteLine(x.Items.Current);
*/

/*
    > Если запустить, то будут бесконечно выводиться нули.

    > Если посмотреть во что декомпилируется эта программа, а потом привести её к человеко-читаемому виду,
    то получим примерно следующий код:
*/

internal sealed class AnonymousType<T>
{
    public readonly T Items;

    public AnonymousType(T items)
    {
        Items = items;
    }
}

internal static class Program
{
    private static void Main()
    {
        var list = new List<int> { 4, 4, 4 };
        var anon = new AnonymousType<List<int>.Enumerator>(list.GetEnumerator());
        while (anon.Items.MoveNext())
        {
            Console.WriteLine(anon.Items.Current);
        }
    }
}

/*
    > В строке 35 получаем предупреждение от IDE
    "Possibly impure struct method called on readonly variable: struct value always copied before invocation"
    То есть при обращении к Items происходит копирование структуры List<int>.Enumerator

    > В документации Microsoft сказано, что
    "Initially, the enumerator is positioned before the first element in the collection.
    At this position, Current is undefined"
    Поэтому при обращении к Current мы получаем 0 -- значение по умолчанию для int
*/