/*
    Problem 2. Numbers Not Divisible by 3 and 7
    Write a program that enters from the console a positive integer n and prints all the numbers 
    from 1 to n not divisible by 3 or 7, on a single line, separated by a space.
*/

namespace NumbersNotDivisibleBySevenAndThree
{
    using System;

    public class NumbersPrinter
    {
        public static void Main()
        {
            Console.Write("N: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                if (i % (3 * 7) != 0)
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}