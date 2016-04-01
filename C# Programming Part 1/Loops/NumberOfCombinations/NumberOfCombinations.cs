/*
    Problem 7. Calculate N! / (K! * (N-K)!)
    In combinatorics, the number of ways to choose k different members out of a group of n 
    different elements (also known as the number of combinations) is calculated by the following formula:
    formula For example, there are 2598960 ways to withdraw 5 cards out of a standard deck of 52 cards.
    Your task is to write a program that calculates n! / (k! * (n-k)!) for given n and k (1 < k < n < 100).
    Try to use only two loops.
*/

namespace NumberOfCombinations
{
    using System;

    public class NumberOfCombinations
    {
        public static void Main()
        {
            Console.Write("N : ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("K : ");
            int k = int.Parse(Console.ReadLine());
            int result = CalculateFactorial(n) / (CalculateFactorial(k) * CalculateFactorial(n - k));

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
