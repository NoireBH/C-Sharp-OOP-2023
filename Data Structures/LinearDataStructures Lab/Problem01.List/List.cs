namespace Problem01.List
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class List<T> : IAbstractList<T>
    {
        private const int DEFAULT_CAPACITY = 4;
        private T[] _items;

        public List()
            : this(DEFAULT_CAPACITY)
        {
        }

        public List(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

            this._items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                this.ValidateIndex(index);
                return this._items[index];
            }
            set
            {
                this.ValidateIndex(index);
                this._items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            this.GrowIfNecessary();
            this._items[Count++] = item;
        }

        public bool Contains(T item)
        {
            if (this._items.Contains(item))
            {
                return true;
            }

            return false;
        }


        public int IndexOf(T item)
        {
            if (this._items.Contains(item))
            {
                int index = 0;

                for (int i = 0; i < this._items.Length; i++)
                {
                    if (item.Equals(this._items[i]))
                    {
                        index = i;
                        return index;
                    }
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            this.ValidateIndex(index);
            this.GrowIfNecessary();

            for (int i = this.Count - 1; i >= index; i--)
            {
                this._items[i] = this._items[i - 1];
            }

            this._items[index] = item;
            this.Count++;

        }

        public bool Remove(T item)
        {
            if (this._items.Contains(item))
            {
               int index = this.IndexOf(item);
                this.RemoveAt(index);
                return true;
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            this.ValidateIndex(index);

            for (int i = index; i < this.Count - 1; i++)
            {
                this._items[i] = this._items[i + 1];
            }

            this._items[this.Count - 1] = default;
            this.Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this._items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException(nameof(index));
            }
        }

        private void GrowIfNecessary()
        {
            if (this.Count == this._items.Length)
            {
                this._items = Grow();
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