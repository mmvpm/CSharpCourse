using LinkedLists;

T? FirstCommonNode<T>(LinkedList<T> first, LinkedList<T> second) where T : class
{
    var firstCurrentNode  = first.First;
    var secondCurrentNode = second.First;
    
    while (firstCurrentNode != null && secondCurrentNode != null)
    {
        if (firstCurrentNode.ValueRef.Equals(secondCurrentNode.ValueRef))
        {
            return firstCurrentNode.Value;
        }
        firstCurrentNode = firstCurrentNode.Next;
        secondCurrentNode = secondCurrentNode.Next;
    }

    return null;
}

var refWrapper = new RefWrapper(17); // common node
var firstList  = new LinkedList<RefWrapper>(new[]
{
    new RefWrapper(0), new RefWrapper(1), refWrapper, new RefWrapper(2)
});
var secondList = new LinkedList<RefWrapper>(new[]
{
    new RefWrapper(0), new RefWrapper(2), refWrapper
});
var emptyList = new LinkedList<RefWrapper>();

var firstCommonNode = FirstCommonNode(firstList, secondList);
Console.WriteLine(firstCommonNode == null ? "null" : firstCommonNode); // Ref(17)

var shouldBeNull = FirstCommonNode(firstList, emptyList);
Console.WriteLine(shouldBeNull == null ? "null" : shouldBeNull); // null