/*
    Problem 6. Calculate N! / K!
    Write a program that calculates n! / k! for given n and k (1 < k < n < 100).
    Use only one loop.
*/

namespace CalculateNFactDividedByKFact
{
    using System;

    public class ExpressionCalculator
    {
        public static void Main()
        {
            Console.Write("N : ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("K : ");
            int k = int.Parse(Console.ReadLine());
            double result = CalculateFactorial(n) / CalculateFactorial(k);

            Console.WriteLine(result);
        }

        private static int CalculateFactorial(int number)
        {
            int currentProduct = 1;

            for (int i = 1; i <= number; i++)
            {
                currentProduct *= i;
            }

            return currentProduct;
        }
    }
}