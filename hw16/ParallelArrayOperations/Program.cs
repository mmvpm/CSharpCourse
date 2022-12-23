using ParallelArrayOperations;

var array = new List<int> { 1, 5, 2, 3, 3, 1, 7, 5 };
var parallelArray = new ParallelArray(array);

var threads = new List<Thread>
{
    new(() => parallelArray.ThreadAverage()),
    new(() => parallelArray.ThreadMin()),
    new(() => parallelArray.ThreadMin()),
    new(() => parallelArray.ThreadSwap()),
    new(() => parallelArray.ThreadSwap()),
    new(() => parallelArray.ThreadSort()),
};
threads.ForEach(t => t.Start());

Thread.Sleep(300);
parallelArray.Terminate();
threads.ForEach(t => t.Join());

/* Output:

    Min: 1
    Min: 1
    Swap: array[6] = 3 & array[3] = 7
    Sort: array = [1, 1, 2, 3, 3, 5, 5, 7]
    Swap: array[4] = 7 & array[7] = 3
    Average: 3,375
    Min: 1
    Average: 3,375
    Average: 3,375
    Min: 1
    Min: 1
    Swap: array[7] = 3 & array[7] = 3
    Min: 1
    Average: 3,375
    Min: 1
    Average: 3,375
    Swap: array[0] = 1 & array[0] = 1
    Min: 1
    Min: 1
    Swap: array[2] = 2 & array[2] = 2
    Average: 3,375
    Min: 1
*/