/*
    Problem 9. Matrix of Numbers
    Write a program that reads from the console a positive integer number n (1 ≤ n ≤ 20) and prints a 
    matrix like in the examples below. Use two nested loops
*/

namespace MatrixOfNumbers
{
    using System;

    public class MatrixOfNumbers
    {
        public static void Main()
        {
            Console.Write("n : ");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("matrix");

            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(j + i + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
