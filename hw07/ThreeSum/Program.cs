(int, int, int)[] ThreeSum(int[] numbers)
{
    var result = new HashSet<(int, int, int)>();
    for (var i = 0; i < numbers.Length; ++i)
        for (var j = i + 1; j < numbers.Length; ++j)
            for (var k = j + 1; k < numbers.Length; ++k)
                if (numbers[i] + numbers[j] + numbers[k] == 0)
                    result.Add((numbers[i], numbers[j], numbers[k]));
    return result.OrderBy(x => x.Item1).ToArray();
}

Console.WriteLine("Hello, World!");

PrintArray(ThreeSum(new[] { 0, 1, -1, -1, 2 })); // {(-1, -1, 2), (0, 1, -1)}
PrintArray(ThreeSum(new[] { 0, 0, 0, 5, -5 }));  // {(0, 0, 0), (0, 5, -5)}
PrintArray(ThreeSum(new[] { 1, 2, 3 }));         // {}
PrintArray(ThreeSum(new int[1]));                // {}

// util

void PrintArray((int, int, int)[] array)
{
    Console.WriteLine("{" + string.Join(", ", array) + "}");
}