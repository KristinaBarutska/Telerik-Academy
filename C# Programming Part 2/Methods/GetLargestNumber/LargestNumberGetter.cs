/*
    Problem 2. Get largest number
    Write a method GetMax() with two parameters that returns the larger of two integers.
    Write a program that reads 3 integers from the console and prints the largest of them 
    using the method GetMax(). 
*/

namespace GetLargestNumber
{
    using System;

    public class LargestNumberGetter
    {
        private static void Main()
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            var largestNumber = GetMax(firstNumber, secondNumber);

            Console.WriteLine($"Largest number: {largestNumber}");
        }

        private static int GetMax(int firstNumber, int secondNumber)
        {
            return Math.Max(firstNumber, secondNumber);
        }
    }
}