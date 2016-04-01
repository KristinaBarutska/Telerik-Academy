/*
    Problem 7. Sum of 5 Numbers
    Write a program that enters 5 numbers (given in a single line, separated by a space), calculates and prints their sum.
*/

namespace SumOfFiveNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class NumbersAdder
    {
        public static void Main()
        {
            Console.Write("Enter five numbers on single line: ");
            List<double> numbers = Console.ReadLine()
                .Split(' ')
                .Select(n => double.Parse(n))
                .ToList();
            double sum = 0;

            numbers.ForEach(n => sum += n);

            Console.WriteLine($"Sum: {sum}");
        }
    }
}