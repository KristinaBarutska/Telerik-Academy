/*
    Problem 6. Sum integers
    You are given a sequence of positive integer values written into a string, separated by spaces.
    Write a function that reads these values from given string and calculates their sum. 
*/

namespace SumIntegers
{
    using System;
    using System.Linq;

    public class SumIntegers
    {
        private static void Main()
        {
            string input = Console.ReadLine();
            int[] numbers = input
                .Split(new char[] { ' ', '"' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n))
                .ToArray();
            int sum = numbers.Sum();

            Console.WriteLine($"Sum : {sum}");
        }
    }
}