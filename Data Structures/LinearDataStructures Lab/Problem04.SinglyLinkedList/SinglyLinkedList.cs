namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> _head;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            Node<T> newNode = new Node<T>(item);
            newNode.Next = _head;
            _head = newNode;
            Count++;
        }

        public void AddLast(T item)
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

        public T GetFirst()
        {
            CheckIfListIsEmpty();
            return _head.Element;
        }

        public T GetLast()
        {
            CheckIfListIsEmpty();

            var nodeToReturn = _head;

            while (nodeToReturn.Next != null)
            {
                nodeToReturn = nodeToReturn.Next;
            }

            return nodeToReturn.Element;
        }

        public T RemoveFirst()
        {
            CheckIfListIsEmpty();
            var oldHead = _head;
            var newHead = _head.Next;
            
            if (newHead != null)
            {
                _head = newHead;
            }

            else
            {
                _head = null;
            }
            Count--;
            return oldHead.Element;
        }

        public T RemoveLast()
        {
            CheckIfListIsEmpty();

            var current = _head;
            Node<T> last = null;

            if (current.Next == null)
            {
                last = _head;
                _head = null;
            }

            else
            {
                while (current != null)
                {
                    if (current.Next.Next == null)
                    {
                        last = current.Next;
                        current.Next = null;
                        break;
                    }

                    current = current.Next;
                }
            }

            Count--;
            return last.Element;
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
            => this.GetEnumerator();

        private void CheckIfListIsEmpty()
        {
            if (_head == null)
            {
                throw new InvalidOperationException();
            }
        }
    }
}