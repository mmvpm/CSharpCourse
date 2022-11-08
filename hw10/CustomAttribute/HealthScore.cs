namespace CustomAttribute;

[Custom("Joe", 2, "Class to work with health data.", "Arnold", "Bernard")]
public class HealthScore
{
    [Custom("Andrew", 3, "Method to collect health data.", "Sam", "Alex")]
    public static long CalcScoreData() => 0;

    public static long NoAttributes() => 0;
    
    [Custom("Mike", 5, "Method to do something.", "Andrew", "Joe")]
    public static long AnotherAttributes() => 0;
} 
