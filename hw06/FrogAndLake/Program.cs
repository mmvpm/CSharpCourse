using FrogAndLake;

var lake1 = new Lake(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 });
foreach (var stone in lake1)
{
    Console.Write(stone + " ");
}
Console.WriteLine(); // 1 3 5 7 8 6 4 2

var lake2 = new Lake(new List<int> { 13, 23, 1, -8, 4, 9 });
foreach (var stone in lake2)
{
    Console.Write(stone + " ");
}
Console.WriteLine(); // 13 1 4 9 -8 23
