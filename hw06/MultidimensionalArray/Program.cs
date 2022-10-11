using System.Diagnostics;
using MultidimensionalArray;

var array = new MultidimensionalArray<int>
{
    [1, 2, 3] = 123,
    [6, 7, 12] = 6712,
    [207982231, 98264982, 18279121] = -1247462893,
};

Console.WriteLine(string.Join(", ", array)); // 123, 6712, -1247462893

array[1, 2, 3] = 321;
array[36129, 282863, 873463] = 9999999;
Console.WriteLine(string.Join(", ", array)); // 321, 6712, -1247462893, 9999999

Console.WriteLine("array[36129, 282863, 873463] = " + array[36129, 282863, 873463]); // 9999999

// Performance
var sw = new Stopwatch();
sw.Start();
for (var i = 0; i < 1e6; ++i)
{
    var j = i * i;
    array[i, j, i + j] = 1;
}
sw.Stop();
Console.WriteLine("Elapsed = " + sw.Elapsed); // 00:00:00.5570606

sw.Start();
foreach (var value in array)
{
    if (value == -1)
        Console.WriteLine("Never happens");
}
sw.Stop();
Console.WriteLine("Elapsed = " + sw.Elapsed); // 00:00:00.5961634