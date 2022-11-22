using AutomobilePlant.part;

namespace AutomobilePlant;

public class Car
{
    public string Name { get; }

    public ICarBody Body { get; }

    public IEngine Engine { get; }

    public ICarPanel Panel { get; }

    public IStereoSystem StereoSystem { get; }

    public ITransmission Transmission { get; }

    public List<IWheel> Wheels { get; }

    public Car(string name, ICarBody body, IEngine engine, ICarPanel panel, IStereoSystem stereoSystem, ITransmission transmission, List<IWheel> wheels)
    {
        Name = name;
        Body = body;
        Engine = engine;
        Panel = panel;
        StereoSystem = stereoSystem;
        Transmission = transmission;
        Wheels = wheels;
    }

    public override string ToString()
    {
        return "Car(" + Name + ")";
    }
}