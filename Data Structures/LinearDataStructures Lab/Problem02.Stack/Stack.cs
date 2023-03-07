namespace Problem02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IAbstractStack<T>
    {
        private Node<T> _top;

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            var current = _top;
            while (current != null)
            {
                if (current.Element.Equals(item))
                {
                    return true;
                }
                current = current.Next;
            }

            return false;
        }

        public T Peek()
        {   
            CheckIfStackIsEmpty();
            return _top.Element;
        }

        public T Pop()
        {
            CheckIfStackIsEmpty();
            var previousTopNode = _top.Element;
            var newTop = _top.Next;
            _top.Next = null;
            _top = newTop;
            Count--;

            return previousTopNode;
        }

        public void Push(T item)
        {
            Node<T> newNode = new Node<T>(item);
            newNode.Next = _top;
            _top = newNode;
            Count++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = _top;

            while (current != null)
            {
                yield return current.Element;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() 
            => GetEnumerator();

        private void CheckIfStackIsEmpty()
        {
            if (_top == null)
            {
                throw new InvalidOperationException();
            }
        }
            
    }
}