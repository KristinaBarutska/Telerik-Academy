/*
    Problem 18.* Trailing Zeroes in N!
    Write a program that calculates with how many zeroes the factorial of a given number n has at its end.
    Your program should work well for very big numbers, e.g. n=100000.
*/

namespace TrailingZeros
{
    using System;
    using System.Linq;
    using System.Numerics;

    public class TrailingZeros
    {
        public static void Main()
        {
            Console.Write("n : ");
            int n = int.Parse(Console.ReadLine());
            BigInteger factorial = CalculateFactorial(n);
            char[] digits = factorial.ToString().ToCharArray().Reverse().ToArray();
            int trailingZeros = 0;

            for (int i = 0; i < digits.Length; i++)
            {
                if (digits[i] == '0')
                {
                    trailingZeros++;
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine($"Trailing zeros : {trailingZeros}");
        }

        private static BigInteger CalculateFactorial(long number)
        {
            BigInteger currentProduct = 1;

            for (int i = 1; i <= number; i++)
            {
                currentProduct *= i;
            }

            return currentProduct;
        }
    }
}