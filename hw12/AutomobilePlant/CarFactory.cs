using AutomobilePlant.part;

namespace AutomobilePlant;

public class CarFactory
{
    public Car CreateCheapCar() =>
        new Car(
            name: "Cheap",
            body: new CarBody(1),
            engine: new EngineCheap(),
            panel: new CarPanel(),
            stereoSystem: new StereoSystemSamsung(),
            transmission: new TransmissionCheap(),
            wheels: new List<IWheel>
            {
                new WheelSmall(), new WheelSmall(),
                new WheelSmall(), new WheelSmall()
            }
        );
    
    public Car CreateExpensiveCar() =>
        new Car(
            name: "Expensive",
            body: new CarBody(2),
            engine: new EngineExpensive(),
            panel: new CarPanel(),
            stereoSystem: new StereoSystemSony(),
            transmission: new TransmissionExpensive(),
            wheels: new List<IWheel>
            {
                new WheelBig(), new WheelBig(),
                new WheelBig(), new WheelBig()
            }
        );
    
    public Car CreateCustomCar() =>
        new Car(
            name: "Custom",
            body: new CarBody(3),
            engine: new EngineCheap(),
            panel: new CarPanel(),
            stereoSystem: new StereoSystemSony(),
            transmission: new TransmissionCheap(),
            wheels: new List<IWheel>
            {
                new WheelSmall(), new WheelSmall(),
                new WheelBig(), new WheelBig()
            }
        );
}