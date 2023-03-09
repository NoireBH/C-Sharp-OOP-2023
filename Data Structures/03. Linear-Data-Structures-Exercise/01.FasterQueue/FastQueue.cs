namespace Problem01.FasterQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class FastQueue<T> : IAbstractQueue<T>
    {
        private Node<T> _head;
        private Node<T> _tail;
        public int Count { get; private set; }

        public bool Contains(T item)
        {
            var current = _head;
            while (current != null)
            {
                if (current.Item.Equals(item))
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
            var elementToDequeue = _head.Item;
            _head = _head.Next;
            Count--;

            return elementToDequeue;
        }

        public void Enqueue(T item)
        {
            Node<T> newNode = new Node<T>(item);

            if (Count == 0)
            {
                _head = newNode;
                _tail = newNode;
            }

            else
            {
                _tail.Next = newNode;
                _tail = _tail.Next;
            }

            Count++;
        }

        public T Peek()
        {
            CheckIfQueueIsEmpty();
            return _head.Item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = _head;

            while (current != null)
            {
                yield return current.Item;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
          return  GetEnumerator();
        }

        private void CheckIfQueueIsEmpty()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
        }
    }
}