namespace SleepingBarber;

public class Client
{
    private string Name { get; }
    public int RequiredWorkMilliseconds { get; }


    public Client(string name, int requiredWorkMilliseconds)
    {
        Name = name;
        RequiredWorkMilliseconds = requiredWorkMilliseconds;
    }

    public override string ToString()
    {
        return "Client(" + Name + ")";
    }
}