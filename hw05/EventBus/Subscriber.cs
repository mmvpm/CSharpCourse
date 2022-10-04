namespace EventBus;

public interface ISubscriber
{
    public void OnEvent();
}

public class SubscriberA : ISubscriber
{
    public void OnEvent()
    {
        Console.WriteLine("SubscriberA.OnEvent()");
    }
}

public class SubscriberB : ISubscriber
{
    public void OnEvent()
    {
        Console.WriteLine("SubscriberB.OnEvent()");
    }
}