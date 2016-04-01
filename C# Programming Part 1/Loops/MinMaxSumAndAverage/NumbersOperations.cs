/*
    Problem 3. Min, Max, Sum and Average of N Numbers
    Write a program that reads from the console a sequence of n integer numbers and returns the minimal, 
    the maximal number, the sum and the average of all numbers (displayed with 2 digits after the decimal point).
    The input starts by the number n (alone in a line) followed by n lines, each holding an integer number.
    The output is like in the examples below.
*/

namespace MinMaxSumAndAverage
{
    using System;
    using System.Linq;

    public class NumbersOperations
    {
        public static void Main()
        {
            Console.Write("N: ");
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write($"n[{i + 1}] = ");
                numbers[i] = int.Parse(Console.ReadLine());
            }

            int min = numbers.Min();
            int max = numbers.Max();
            int sum = numbers.Sum();
            double average = numbers.Average();

            Console.WriteLine($"Min: {min}\nMax: {max}\nSum: {sum}\nAverage: {average:0.##}");
        }
    }
}