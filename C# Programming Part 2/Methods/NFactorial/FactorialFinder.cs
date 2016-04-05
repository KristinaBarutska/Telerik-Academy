/* 
    Problem 10. N Factorial
    Write a program to calculate n! for each n in the range [1..100]. 
*/

namespace NFactorial
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    public class FactorialFinder
    {
        private static void Main()
        {
            var factorials = FindFactorialsInRange();

            for (int i = 0; i < factorials.Count; i++)
            {
                Console.WriteLine($"!{i + 1} = {factorials[i]}");
            }
        }

        private static BigInteger CalcFactorial(int n)
        {
            if (n == 1)
            {
                return 1;
            }

            return n * CalcFactorial(n - 1);
        }

        private static List<BigInteger> FindFactorialsInRange()
        {
            var factorials = new List<BigInteger>();

            for (int i = 1; i < 101; i++)
            {
                var currentFactorial = CalcFactorial(i);

                factorials.Add(currentFactorial);
            }

            return factorials;
        }
    }
}