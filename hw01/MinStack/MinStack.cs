using System;
using System.Collections.Generic;

namespace MinStack
{
    public class MinStack<T> where T : IComparable
    {
        private Stack<T> Stack { get;  }
        private Stack<T> PrefixMins { get; }

        public MinStack()
        {
            Stack = new Stack<T>();
            PrefixMins = new Stack<T>();
        }

        public void Push(T element)
        {
            Stack.Push(element);
            if (PrefixMins.Count == 0 || element.CompareTo(PrefixMins.Peek()) < 0)
            {
                PrefixMins.Push(element);
            }
            else
            {
                PrefixMins.Push(PrefixMins.Peek());
            }
        }

        public T Pop()
        {
            PrefixMins.Pop();
            return Stack.Pop();
        }

        public T Peek()
        {
            return Stack.Peek();
        }

        public T MinValue()
        {
            return PrefixMins.Peek();
        }

        public override string ToString()
        {
            return "Stack(" + string.Join(", ", Stack) + ")";
        }
    }
}