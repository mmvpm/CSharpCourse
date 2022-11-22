namespace AutomobilePlant.part;

public interface IEngine
{
    public void Start();
    
    public void Stop();
}

public class EngineCheap : IEngine
{
    private List<EngineCylinder> _cylinders;

    public EngineCheap()
    {
        _cylinders = new List<EngineCylinder> { new(), new() };
    }
    
    public void Start()
    {
        Console.WriteLine("EngineCheap.Start()");
    }

    public void Stop()
    {
        Console.WriteLine("EngineCheap.Stop()");
    }
}

public class EngineExpensive : IEngine
{
    private List<EngineCylinder> _cylinders;
    
    public EngineExpensive()
    {
        _cylinders = new List<EngineCylinder> { new(), new(), new(), new() };
    }
    
    public void Start()
    {
        Console.WriteLine("EngineExpensive.Start()");
    }

    public void Stop()
    {
        Console.WriteLine("EngineExpensive.Stop()");
    }
}
