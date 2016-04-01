/*
    Problem 8. Catalan Numbers
    In combinatorics, the Catalan numbers are calculated by the following formula: catalan-formula
    Write a program to calculate the nth Catalan number by given n (0 ≤ n ≤ 100)
*/

namespace CatalanNumbers
{
    using System;
    using System.Numerics;

    public class CatalanNumbers
    {
        public static void Main()
        {
            Console.Write("n : ");
            BigInteger n = BigInteger.Parse(Console.ReadLine());
            BigInteger result = CalculateFactorial(2 * n) / (CalculateFactorial(n + 1) * CalculateFactorial(n));

            Console.WriteLine(result);
        }

        private static BigInteger CalculateFactorial(BigInteger number)
        {
            BigInteger currentProduct = 1;

            for (BigInteger i = 1; i <= number; i++)
            {
                currentProduct *= i;
            }

            return currentProduct;
        }
    }
}