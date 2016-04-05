/* 
    Problem 14. Integer calculations
    Write methods to calculate minimum, maximum, average, sum and product of given set of integer numbers.
    Use variable number of arguments.
*/

namespace IntegerCalculations
{
    using System;
    using System.Linq;

    public class IntegerOperations
    {
        private static void Main()
        {
            var max = GetMax(1, 2, 3, 4, 5);
            var min = GetMin(1, 2, 3, 4, 5);
            var avg = GetAverage(1, 2, 3, 4, 5);
            var sum = GetSum(1, 2, 3, 4, 5);
            var product = GetProduct(1, 2, 3, 4, 5);

            Console.WriteLine($"Max: {max}; Min: {min}; Average: {avg}; Sum: {sum}; Product: {product}");
        }

        private static int GetMax(params int[] numbers)
        {
            var max = numbers.Max();

            return max;
        }

        private static int GetMin(params int[] numbers)
        {
            var min = numbers.Min();

            return min;
        }

        private static double GetAverage(params int[] numbers)
        {
            var average = numbers.Average();

            return average;
        }

        private static double GetSum(params int[] numbers)
        {
            var sum = numbers.Sum();

            return sum;
        }

        private static int GetProduct(params int[] numbers)
        {
            var product = 1;

            for (int i = 0; i < numbers.Length; i++)
            {
                product *= numbers[i];
            }

            return product;
        }
    }
}