namespace SortCollection;

public class Person
{
    public string Name { get; set; }
    
    public int Age { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public override string ToString()
    {
        return "Person(" + Name + ", " + Age + ")";
    }
}

internal class ByNameComparer : IComparer<Person>
{
    public int Compare(Person? p1, Person? p2)
    {
        if (p1 is null || p2 is null)
            throw new ArgumentException("Person should be not null");
        if (p1.Name.Length < p2.Name.Length)
            return -1;
        if (p1.Name.Length > p2.Name.Length)
            return +1;
        return p1.Name.Length == 0 ? 
            0 : p1.Name.ToLower()[0].CompareTo(p2.Name.ToLower()[0]);
    }
}

internal class ByAgeComparer : IComparer<Person>
{
    public int Compare(Person? p1, Person? p2)
    {
        if (p1 is null || p2 is null)
            throw new ArgumentException("Person should be not null");
        return p1.Age.CompareTo(p2.Age);
    }
}