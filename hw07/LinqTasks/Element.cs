namespace LinqTasks;

public class Element
{
    public string Name;

    public Element(string name)
    {
        Name = name;
    }

    public override string ToString()
    {
        return "Element(" + Name + ")";
    }
}