namespace EventBus;

public class EventBus
{
    private readonly Dictionary<string, IPublisher> _publishers;

    public EventBus()
    {
        _publishers = new Dictionary<string, IPublisher>();
    }
    
    public void AddPublisher(string publisherId, IPublisher publisher)
    {
        _publishers[publisherId] = publisher;
    }

    public void RemovePublisher(string publisherId)
    {
        _publishers.Remove(publisherId);
    }

    public void Subscribe(string publisherId, ISubscriber subscriber)
    {
        _publishers[publisherId].OnPost += subscriber.OnEvent;
    }
}