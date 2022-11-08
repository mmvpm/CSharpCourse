using System.Reflection;
using CustomAttribute;

var healthScoreType = typeof(HealthScore);

Console.WriteLine("HealthScore attributes:");
healthScoreType.GetCustomAttributes().ToList().ForEach(Console.WriteLine);

Console.WriteLine("HealthScore methods:");
foreach (var method in healthScoreType.GetMethods())
{
    Console.WriteLine("> " + method.Name);
    foreach (var attribute in method.GetCustomAttributes())
    {
        if (attribute is Custom)
            Console.WriteLine("  " + attribute);
    }
}

/* Output:
    HealthScore attributes:
    Custom(Joe, 2, Class to work with health data., [Arnold, Bernard])
    HealthScore methods:
    > CalcScoreData
      Custom(Andrew, 3, Method to collect health data., [Sam, Alex])
    > NoAttributes
    > AnotherAttributes
      Custom(Mike, 5, Method to do something., [Andrew, Joe])
    > GetType
    > ToString
    > Equals
    > GetHashCode
*/
