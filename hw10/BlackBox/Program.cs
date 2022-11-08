using System.Reflection;

const BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance;

var blackBoxType = typeof(BlackBox.BlackBox);
var blackBox = (BlackBox.BlackBox) blackBoxType
    .GetConstructor(bindingFlags, null, new[] { typeof(int) }, null)!
    .Invoke(new object[]{ 0 });

while (true)
{
    var command = Console.ReadLine()!;
    var parsedCommand = command.Split('(', ')');
    var methodName = parsedCommand[0];
    var argument = int.Parse(parsedCommand[1]);

    var method = blackBoxType.GetMethod(methodName, bindingFlags);
    if (method == null)
    {
        Console.WriteLine("No such method: {0}", methodName);
        continue;
    }
    method.Invoke(blackBox, new object[]{ argument });

    var innerValue = (int) blackBoxType
        .GetField("innerValue", bindingFlags)!
        .GetValue(blackBox)!;
    Console.WriteLine(innerValue);
}

/* Output:
 
> Add(100)
> 100
> Subtract(20)
> 80
> Divide(5)
> 16
> Multiply(2)
> 32
> Pow(3)
> No such method: Pow
*/