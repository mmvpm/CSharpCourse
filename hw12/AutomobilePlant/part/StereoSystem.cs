namespace AutomobilePlant.part;

public interface IStereoSystem
{
    public void On();
    
    public void Off();
}

public class StereoSystemSony : IStereoSystem
{
    public void On()
    {
        Console.WriteLine("StereoSystemSony.On()");
    }

    public void Off()
    {
        Console.WriteLine("StereoSystemSony.Off()");
    }
}

public class StereoSystemSamsung : IStereoSystem
{
    public void On()
    {
        Console.WriteLine("StereoSystemSamsung.On()");
    }

    public void Off()
    {
        Console.WriteLine("StereoSystemSamsung.Off()");
    }
}
