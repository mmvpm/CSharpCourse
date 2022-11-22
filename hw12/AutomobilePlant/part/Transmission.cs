namespace AutomobilePlant.part;

public interface ITransmission
{
    public void Start();
    
    public void Stop();
}

public class TransmissionCheap : ITransmission
{
    public void Start()
    {
        Console.WriteLine("TransmissionCheap.Start()");
    }

    public void Stop()
    {
        Console.WriteLine("TransmissionCheap.Stop()");
    }
}

public class TransmissionExpensive : ITransmission
{
    public void Start()
    {
        Console.WriteLine("TransmissionExpensive.Start()");
    }

    public void Stop()
    {
        Console.WriteLine("TransmissionExpensive.Stop()");
    }
}