namespace EventBus;

public interface IPublisher
{
    public event Action OnPost;

    public void Post();
}

public class PublisherA : IPublisher
{
    public event Action OnPost = delegate {};

    public void Post()
    {
        Console.WriteLine("PublisherA.Post()");
        OnPost.Invoke();
    }
}

public class PublisherB : IPublisher
{
    public event Action OnPost = delegate {};

    public void Post()
    {
        Console.WriteLine("PublisherB.Post()");
        OnPost.Invoke();
    }
}