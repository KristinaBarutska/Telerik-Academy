namespace GenericList
{
    using System;
    using System.Text;

    public class GenericList<T> 
        where T : IComparable
    {
        private const double ResizeFactor = 0.75;

        private T[] container;
        private int capacity;
        private int count;

        public GenericList(int capacity)
        {
            this.capacity = capacity;
            this.container = new T[capacity];
            this.count = 0;
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }

            private set
            {
                this.capacity = value;
            }
        }

        public int Count
        {
            get
            {
                return this.count;
            }

            private set
            {
                this.Count = value;
            }
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index > this.count)
                {
                    throw new IndexOutOfRangeException("Invalid index!");
                }

                return this.container[index];
            }

            set
            {
                if (index < 0 || index > this.count)
                {
                    throw new IndexOutOfRangeException("Invalid index!");
                }

                this.container[index] = value;
            }
        }

        public void Add(T element)
        {
            if (this.count == this.capacity * ResizeFactor)
            {
                this.Resize();
            }

            this.container[this.count] = element;
            this.count++;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index > this.count)
            {
                throw new IndexOutOfRangeException("Invalid index to remove at!");
            }

            T[] cachedValues = (T[])this.container.Clone();
            this.container = new T[this.capacity];
            int elementIndex = 0;

            for (int i = 0; i < cachedValues.Length; i++)
            {
                if (i != index)
                {
                    this.container[elementIndex] = cachedValues[i];
                    elementIndex++;
                }
            }

            this.count--;
        }

        public void Insert(int index, T element)
        {
            T[] cachedValues = (T[])this.container.Clone();
            this.count++;

            if (index < 0 || index > this.count)
            {
                throw new IndexOutOfRangeException("Invalid index to insert at!");
            }

            if (this.count == this.capacity * ResizeFactor)
            {
                this.Resize();
            }

            this.container = new T[this.capacity];

            int elementIndex = 0;

            for (int i = 0; i < this.count; i++)
            {
                if (i == index)
                {
                    this.container[i] = element;
                }
                else
                {
                    this.container[i] = cachedValues[elementIndex];
                    elementIndex++;
                }
            }
        }

        public void Clear()
        {
            this.container = new T[this.capacity];
        }

        public int IndexOf(T element)
        {
            int resultIndex = -1;

            for (int i = 0; i < this.count; i++)
            {
                if (this.container[i].Equals(element))
                {
                    resultIndex = i;
                    break;
                }
            }

            return resultIndex;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < this.count; i++)
            {
                result.Append(this.container[i] + " ");
            }

            return result.ToString().Trim();
        }

        public T Min()
        {
            T minElement = this.container[0];

            for (int i = 1; i < this.count; i++)
            {
                if (this.container[i].CompareTo(minElement) < 0)
                {
                    minElement = this.container[i];
                }
            }

            return minElement;
        }

        public T Max()
        {
            T maxElement = this.container[0];

            for (int i = 1; i < this.count; i++)
            {
                if (this.container[i].CompareTo(maxElement) > 0)
                {
                    maxElement = this.container[i];
                }
            }

            return maxElement;
        }

        private void Resize()
        {
            T[] cachedValues = (T[])this.container.Clone();
            this.capacity *= 2;
            this.container = new T[this.capacity];

            for (int i = 0; i < cachedValues.Length; i++)
            {
                this.container[i] = cachedValues[i];
            }
        }
    }
}