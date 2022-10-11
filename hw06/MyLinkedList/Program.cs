using MyLinkedList;

var myList = new MyLinkedList<int>();
Console.WriteLine(myList.Count);                          // 0
Console.WriteLine("[" + string.Join(", ", myList) + "]"); // []

myList.PushBack(1);
myList.PushBack(2);
myList.PushBack(3);
Console.WriteLine(myList.Count);                          // 3
Console.WriteLine("[" + string.Join(", ", myList) + "]"); // [1, 2, 3]

myList.RemoveFirst(2);
Console.WriteLine(myList.Count);                          // 2
Console.WriteLine("[" + string.Join(", ", myList) + "]"); // [1, 3]

Console.WriteLine(myList.RemoveFirst(999));         // False
Console.WriteLine(myList.Count);                          // 2
Console.WriteLine("[" + string.Join(", ", myList) + "]"); // [1, 3]

myList.RemoveFirst(1);
myList.RemoveFirst(3);
Console.WriteLine(myList.Count);                          // 0
Console.WriteLine("[" + string.Join(", ", myList) + "]"); // []

myList.PushBack(5);
myList.PushBack(7);
Console.WriteLine(myList.Count);                           // 2
Console.WriteLine("[" + string.Join(", ", myList) + "]"); // [5, 7]
