namespace IEnumerableExtensions.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class IEnumerableExtensions
    {
        public static T Min<T>(this IEnumerable<T> collection)
            where T : IComparable
        {
            T minElement = collection.First();

            foreach (T element in collection)
            {
                if (element.CompareTo(minElement) < 0)
                {
                    minElement = element;
                }
            }

            return minElement;
        }

        public static T Max<T>(this IEnumerable<T> collection)
            where T : IComparable
        {
            T maxElement = collection.First();

            foreach (T element in collection)
            {
                if (element.CompareTo(maxElement) > 0)
                {
                    maxElement = element;
                }
            }

            return maxElement;
        }

        public static T Sum<T>(this IEnumerable<T> collection)
        {
            dynamic sum = default(T);

            foreach (T element in collection)
            {
                sum += element;
            }

            return sum;
        }

        public static T Product<T>(this IEnumerable<T> collection)
        {
            dynamic product = 1;

            foreach (T element in collection)
            {
                product *= element;
            }

            return product;
        }

        public static T Average<T>(this IEnumerable<T> collection)
        {
            T sum = collection.Sum();
            int elementsCount = 0;

            foreach (T element in collection)
            {
                elementsCount++;
            }

            T average = (dynamic)sum / elementsCount;

            return average;
        }
    }
}