/*
    Problem 10. Fibonacci Numbers
    Write a program that reads a number n and prints on the console the first n members of the 
    Fibonacci sequence (at a single line, separated by comma and space - ,) : 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, ….
*/

namespace FibonacciNumbers
{
    using System;
    using System.Collections.Generic;

    public class FibonacciNumbers
    {
        public static void Main()
        {
            Console.Write("N: ");
            int n = int.Parse(Console.ReadLine());

            if (n == 0)
            {
                Console.WriteLine(1);
            }

            if (n == 1)
            {
                Console.WriteLine(1);
            }

            IList<int> fibonacciSequence = new List<int>();

            if (n > 1)
            {
                fibonacciSequence.Add(0);
                fibonacciSequence.Add(1);

                for (int i = 2; i < n; i++)
                {
                    fibonacciSequence.Add(fibonacciSequence[i - 1] + fibonacciSequence[i - 2]);
                }

                Console.WriteLine(string.Join(", ", fibonacciSequence));
            }
        }
    }
}