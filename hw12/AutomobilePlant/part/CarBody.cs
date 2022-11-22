namespace AutomobilePlant.part;

public interface ICarBody
{
    public int Number { get; set; }
}

public class CarBody : ICarBody
{
    public int Number { get; set; }

    public CarBody(int number)
    {
        Number = number;
    }
}
