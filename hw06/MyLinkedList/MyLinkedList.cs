using System.Collections;

namespace MyLinkedList;

public class MyLinkedList<T> : IEnumerable<T>
{
    private MyNode<T>? _head;
    private MyNode<T>? _tail;

    public int Count { get; private set; } 

    public MyLinkedList()
    {
        _head = null;
        _tail = null;
        Count = 0;
    }
    
    public void PushBack(T element)
    {
        var newNode = new MyNode<T>(element);
        if (_tail == null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            _tail.Next = newNode;
            _tail = _tail.Next;
        }
        Count += 1;
    }

    public bool RemoveFirst(T element)
    {
        MyNode<T>? lastNode = null;
        var currentNode = _head;
        while (currentNode != null)
        {
            if (currentNode.Value?.Equals(element) == true)
            {
                if (_tail == currentNode)
                    _tail = lastNode;
                if (lastNode == null)
                    _head = currentNode.Next;
                else
                    lastNode.Next = currentNode.Next;
                Count -= 1;
                return true;
            }

            lastNode = currentNode;
            currentNode = currentNode.Next;
        }

        return false;
    }

    public IEnumerator<T> GetEnumerator()
    {
        var current = _head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}