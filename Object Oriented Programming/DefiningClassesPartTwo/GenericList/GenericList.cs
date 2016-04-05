namespace GenericList
{
    using System;

    class GenericList<T> where T : IComparable
    {
        private int containerCapacity = 4;
        private int count = 0;
        private T[] container;

        public GenericList()
        {
            this.container = new T[containerCapacity];
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public void Add(T item)
        {
            if (this.count == this.containerCapacity - 1)
            {
                this.containerCapacity = this.containerCapacity * 2;

                var newContainer = new T[containerCapacity];

                for (int i = 0; i < container.Length; i++)
                {
                    newContainer[i] = this.container[i];
                }

                this.container = newContainer;
            }

            this.container[count] = item;
            this.count++;
        }

        public void InsertAt(int index, T value)
        {
            var newArray = new T[this.container.Length + 1];

            for (int i = 0; i < index; i++)
            {
                newArray[i] = this.container[i];
            }

            newArray[index] = value;

            for (int i = index; i < newArray.Length - 1; i++)
            {
                newArray[i + 1] = this.container[i];
            }

            for (int i = 0; i < this.container.Length; i++)
            {
                this.container[i] = newArray[i];
            }

            this.containerCapacity++;
            this.count++;
        }

        public int GetIndexOf(T value)
        {
            for (int i = 0; i < this.container.Length; i++)
            {
                if (this.container[i].Equals(value))
                {
                    return i;
                }             
            }

            return -1;
        }

        public void RemoveAt(int index)
        {
            var arrayWithRemovedValue = new T[container.Length];
            int i = 0;
            int j = 0;

            while (i < container.Length - 1)
            {
                if (i != index)
                {
                    arrayWithRemovedValue[j] = container[i];
                    j++;
                }

                i++;
            }

            for (int k = 0; k < arrayWithRemovedValue.Length; k++)
            {
                container[k] = arrayWithRemovedValue[k];
            }

            this.count--;
        }
        
        public void Clear()
        {
            for (int i = 0; i < this.container.Length; i++)
            {
                this.container[i] = default(T);
            }
        }

        public T Min()
        {
            T min = default(T);

            if (this.count > 0)
            {
                min = this.container[0];

                for (int i = 1; i <= this.count - 1; i++)
                {
                    if (min.CompareTo(this.container[i]) > 0)
                    {
                        min = this.container[i];
                    }
                }
            }

            return min;
        }

        public T Max()
        {
            T max = default(T);

            if (this.count > 0)
            {
                max = this.container[0];

                for (int i = 1; i <= this.count - 1; i++)
                {
                    if (max.CompareTo(this.container[i]) < 0)
                    {
                        max = this.container[i];
                    }
                }
            }

            return max;
        }

        public T this[int index]
        {
            get
            {
                return this.container[index];
            }
            set
            {
                this.container[index] = value;
            }
        }

        public override string ToString()
        {
            return string.Join(" ", this.container);
        }
    }
}