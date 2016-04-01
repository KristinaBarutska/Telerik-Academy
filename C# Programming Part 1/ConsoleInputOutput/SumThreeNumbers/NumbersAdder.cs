/*
    Problem 1. Sum of 3 Numbers
    Write a program that reads 3 real numbers from the console and prints their sum.
*/

namespace SumThreeNumbers
{
    using System;

    public class NumbersAdder
    {
        public static void Main()
        {
            Console.Write("First number: ");
            double firstRealNumber = double.Parse(Console.ReadLine());
            Console.Write("Second number: ");
            double secondRealNumber = double.Parse(Console.ReadLine());
            Console.Write("Third number: ");
            double thirdRealNumber = double.Parse(Console.ReadLine());
            double sum = firstRealNumber + secondRealNumber + thirdRealNumber;

            Console.WriteLine($"Sum: {sum}");
        }
    }
}