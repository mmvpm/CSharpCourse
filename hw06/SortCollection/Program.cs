using SortCollection;

var persons = new List<Person>()
{
    new Person("name1", 1),
    new Person("Egor", 27),
    new Person("", 33),
    new Person("b", 9),
    new Person("aaa", 0),
    new Person("name2", 2),
    new Person("Masha", 21),
    new Person("AAA", 70),
    new Person("Misha", 18),
};

persons.Sort(new ByNameComparer());
Console.WriteLine(string.Join("\n", persons));
/* Output:
    Person(, 33)
    Person(b, 9)
    Person(aaa, 0)
    Person(AAA, 70)
    Person(Egor, 27)
    Person(Masha, 21)
    Person(Misha, 18)
    Person(name1, 1)
    Person(name2, 2)
*/
Console.WriteLine();

persons.Sort(new ByAgeComparer());
Console.WriteLine(string.Join("\n", persons));
/* Output:
    Person(aaa, 0)
    Person(name1, 1)
    Person(name2, 2)
    Person(b, 9)
    Person(Misha, 18)
    Person(Masha, 21)
    Person(Egor, 27)
    Person(, 33)
    Person(AAA, 70)
*/
