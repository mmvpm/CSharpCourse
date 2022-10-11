namespace MyLinkedList;

public class MyNode<T>
{
    public T Value { get; set; }

    public MyNode<T>? Next { get; set; }

    public MyNode(T value, MyNode<T>? next = null)
    {
        Value = value;
        Next = next;
    }
}