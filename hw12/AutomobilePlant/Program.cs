using AutomobilePlant;

var carFactory = new CarFactory();

var cars = new List<Car>
{
    carFactory.CreateCheapCar(),
    carFactory.CreateCustomCar(),
    carFactory.CreateExpensiveCar()
};

cars.ForEach(Console.WriteLine);

/* Output:
    
    Car(Cheap)
    Car(Custom)
    Car(Expensive)
*/
