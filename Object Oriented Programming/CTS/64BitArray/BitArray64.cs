namespace _64BitArray
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class BitArray64 : IEnumerable<int>
    {
        private ulong number;

        public BitArray64(ulong value)
        {
            this.number = value;
        }

        public int this[int index]
        {
            get
            {
                this.ValidateIndexRange(index);
                return (int)(this.number >> index) & 1;
            }

            set
            {
                this.ValidateIndexRange(index);
                this.ValidateValue(value);

                if (value == 1)
                {
                    this.number = this.number | ((ulong)1 << index);
                }
                else
                {
                    this.number = this.number & (~((ulong)1 << index));
                }
            }
        }

        public static bool operator ==(BitArray64 first, BitArray64 second)
        {
            return BitArray64.Equals(first, second);
        }

        public static bool operator !=(BitArray64 first, BitArray64 second)
        {
            return !BitArray64.Equals(first, second);
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 63; i >= 0; i--)
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override bool Equals(object obj)
        {
            if (obj as BitArray64 == null)
            {
                return false;
            }
            else
            {
                var secondArray = obj as BitArray64;
                bool areEqual = this.number == secondArray.number;

                return areEqual;
            }
        }

        public override int GetHashCode()
        {
            return this.number.GetHashCode();
        }

        private void ValidateIndexRange(int index)
        {
            if (index < 0 || index > 63)
            {
                throw new ArgumentException("The index must be between 0 and 63!");
            }
        }

        private void ValidateValue(int value)
        {
            if (value < 0 || value > 1)
            {
                throw new ArgumentException("Bit value must be either 0 or 1");
            }
        }
    }
}