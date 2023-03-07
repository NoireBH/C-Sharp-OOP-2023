namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
    {
        private Node<T> _head;

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            var current = _head;
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

        public T Dequeue()
        {
            CheckIfQueueIsEmpty();
            var elementToDequeue = _head.Element;
            _head = _head.Next;
            Count--;

            return elementToDequeue;
        }

        public void Enqueue(T item)
        {
            Node<T> newNode = new Node<T>(item);

            if (_head == null)
            {
                _head = newNode;               
            }

            else
            {
                var currentNode = _head;

                while (currentNode.Next != null)
                {
                    currentNode = currentNode.Next;                  
                }

                currentNode.Next = newNode;
            }

            Count++;
        }

        public T Peek()
        {
            CheckIfQueueIsEmpty();
            var elementToReturn = _head.Element;

            return elementToReturn;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = _head;

            while (current != null)
            {
                yield return current.Element;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        private void CheckIfQueueIsEmpty()
        {
            if (_head == null)
            {
                throw new InvalidOperationException();
            }
        }
    }
}