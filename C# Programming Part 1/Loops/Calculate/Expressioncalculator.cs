/*
    Problem 5. Calculate 1 + 1!/X + 2!/X^2 + … + N!/X^N
    Write a program that, for a given two integer numbers n and x, calculates the sum S = 1 + 1!/x + 2!/x2 + … + n!/x^n.
    Use only one loop. Print the result with 5 digits after the decimal point.
*/

namespace Calculate
{
    using System;

    public class ExpressionCalculator
    {
        public static void Main()
        {
            Console.Write("N : ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("X : ");
            int x = int.Parse(Console.ReadLine());
            double s = 1;

            for (int i = 1; i <= n; i++)
            {
                s += CalculateFactorial(i) / Math.Pow(x, i);
            }

            Console.WriteLine($"S : {s:0.00000}");
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