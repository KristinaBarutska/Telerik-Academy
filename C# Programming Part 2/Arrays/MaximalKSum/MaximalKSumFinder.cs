/*
    Problem 6. Maximal K sum
    Write a program that reads two integer numbers N and K and an array 
    of N elements from the console.
    Find in the array those K elements that have maximal sum. 
*/

namespace MaximalK_Sum
{
    using System;

    public class MaximalKSumFinder
    {
        private static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            var numbers = new int[n];

            for (int i = 0; i < n; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            Array.Sort(numbers);
            Array.Reverse(numbers);

            for (int i = 0; i < k; i++)
            {
                Console.Write($"{numbers[i]} ");
            }
        }
    }
}