namespace Problem03.ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class ReversedList<T> : IAbstractList<T>
    {
        private const int DefaultCapacity = 4;

        private T[] _items;

        public ReversedList()
            : this(DefaultCapacity) { }

        public ReversedList(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity));

            this._items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                ValidateIndex(index);
                return _items[Count - index - 1];
            }
            set
            {
                ValidateIndex(index);
                _items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            GrowIfNecessary();
            _items[Count++] = item;
        }

        public bool Contains(T item)
        {
            if (_items.Contains(item))
            {
                return true;
            }

            return false;
        }

        public int IndexOf(T item)
        {
            if (_items.Contains(item))
            {
                int index = 0;

                for (int i = Count - 1; i >= 0; i--)
                {
                    if (item.Equals(_items[i]))
                    {
                        index = Count - i - 1;
                        return index;
                    }
                }
                                   
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            ValidateIndex(index);
            GrowIfNecessary();

            for (int i = Count; i >= Count - index; i--)
            {
                _items[i] = _items[i - 1];
            }

            _items[Count - index] = item;
            Count++;
        }

        public bool Remove(T item)
        {
            if (_items.Contains(item))
            {
                int index = IndexOf(item);
                RemoveAt(index);
                return true;
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            ValidateIndex(index);

            for (int i = Count; i >= Count - index; i--)
            {
                _items[i] = _items[i - 1];
            }

            _items[Count - index] = default;
            Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                yield return _items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException(nameof(index));
            }
        }

        private void GrowIfNecessary()
        {
            if (Count == _items.Length)
            {
                _items = Grow();
            }
        }

        private T[] Grow()
        {
            var copy = new T[_items.Length * 2];

            for (int i = 0; i < _items.Length; i++)
            {
                copy[i] = _items[i];
            }

            return copy;
        }
    }
}