namespace RangeException
{
    using System;

    public class InvalidRangeException<T> : Exception
    {
        private const string DefaultRangeMessage = "Elements must be in range: ";

        public InvalidRangeException()
        {
        }

        public InvalidRangeException(string message)
            : base(message)
        {
        }

        public InvalidRangeException(string message, T start, T end)
            : this(message + string.Format("{0} {1} - {2}!", DefaultRangeMessage, start, end))
        {
        }

        public T Start
        {
            get;
            private set;
        }

        public T End
        {
            get;
            private set;
        }
    }
}