/*
    Problem 9. Sum of n Numbers
    Write a program that enters a number n and after that enters more n numbers and calculates and 
    prints their sum. Note: You may need to use a for-loop.
*/

namespace SumOfNNumbers
{
    using System;
    using System.Linq;

    public class SumCalculator
    {
        public static void Main()
        {
            Console.Write("n: ");
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write($"№ {i}: ");
                numbers[i] = int.Parse(Console.ReadLine());
            }

            int sum = numbers.Sum();

            Console.WriteLine($"Sum: {sum}");
        }
    }
}