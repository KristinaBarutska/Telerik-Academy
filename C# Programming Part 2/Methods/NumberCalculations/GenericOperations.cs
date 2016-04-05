/* 
    Problem 15.* Number calculations
    Modify your last program and try to make it work for any number type,
    not just integer(e.g. decimal, float, byte, etc.)
    Use generic method (read in Internet about generic methods in C#). 
*/

namespace NumberCalculations
{
    using System;
    using System.Linq;

    public class GenericOperations
    {
        private static void Main()
        {
            var max = GetMax(1.1, 2.2, 3.3, 4.4, 5.5);
            var min = GetMin(1.1, 2.2, 3.3, 4.4, 5.5);
            var avg = GetAverage(1.1, 2.2, 3.3, 4.4, 5.5);
            var sum = GetSum(1.1, 2.2, 3.3, 4.4, 5.5);
            var product = GetProduct(1.1, 2.2, 3.3, 4.4, 5.5);

            Console.WriteLine($"Max: {max}; Min: {min}; Average: {avg}; Sum: {sum}; Product: {product}");
        }

        private static T GetMax<T>(params T[] numbers)
        {
            var max = numbers.Max();

            return max;
        }

        private static T GetMin<T>(params T[] numbers)
        {
            var min = numbers.Min();

            return min;
        }

        private static T GetAverage<T>(params T[] numbers)
        {
            dynamic sum = Sum(numbers);
            dynamic average = sum / numbers.Length;

            return average;
        }

        private static T GetSum<T>(params T[] numbers)
        {
            var sum = Sum(numbers);

            return sum;
        }

        private static T GetProduct<T>(params T[] numbers)
        {
            dynamic product = 1;

            for (int i = 0; i < numbers.Length; i++)
            {
                product *= numbers[i];
            }

            return product;
        }

        private static T Sum<T>(params T[] numbers)
        {
            dynamic sum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }

            return sum;
        }
    }
}