namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            Node<T> newNode = new Node<T>(item);

            if (Count == 0)
            {
                head = newNode;
                tail = newNode;
            }

            else
            {
                var oldHead = head;
                oldHead.Previous = newNode;
                head = newNode;
                head.Next = oldHead;

            }

            Count++;
        }

        public void AddLast(T item)
        {
            Node<T> newNode = new Node<T>(item);

            if (Count == 0)
            {
                head = newNode;
                tail = newNode;
            }

            else
            {
                var oldTail = tail;
                oldTail.Next = newNode;
                tail = newNode;
                tail.Previous = oldTail;

            }

            Count++;
        }

        public T GetFirst()
        {
            CheckIfListIsEmpty();
            return head.Item;
        }

        public T GetLast()
        {
            CheckIfListIsEmpty();
            return tail.Item;
        }

        public T RemoveFirst()
        {
            CheckIfListIsEmpty();
            var oldHead = head;
            head = head.Next;

            Count--;
            return oldHead.Item;
        }

        public T RemoveLast()
        {
            CheckIfListIsEmpty();
            var oldTail = tail;
            tail = tail.Previous;

            Count--;
            return oldTail.Item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = head;

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

        private void CheckIfListIsEmpty()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
        }
    }
}