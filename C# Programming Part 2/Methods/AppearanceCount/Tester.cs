/*
    Problem 4. Appearance count
    Write a method that counts how many times given number appears in given array.
    Write a test program to check if the method is workings correctly.
*/

namespace AppearanceCount
{
    using System;
    using System.Linq;

    public class Tester
    {
        private static void Main()
        {
            Console.Write("Enter sequence of numbers on a single line : ");
            var numbers = Console.ReadLine()
                .Split(' ')
                .Select(n => double.Parse(n))
                .ToArray();
            Console.Write("Enter specified number : ");
            double num = double.Parse(Console.ReadLine());

            var testArray = new double[] { 1, 2, 2, 1, 2, 2, 2, 3.4 };
            TestCounter(testArray, 2, 5);

            var result = AppearanceCounter<double>.CountAppearances(numbers, num);

            Console.WriteLine($"{num} appears {result} times in {string.Join(" ", numbers)}.");
        }

        private static void TestCounter<T>(T[] testArray, T testValue, T expectedResult)
        {
            var result = AppearanceCounter<T>.CountAppearances(testArray, testValue);

            if (result.Equals(expectedResult))
            {
                throw new ArgumentException("The method does not return the expected result");
            }

            Console.WriteLine("The method works properly.The result is as expected.");
        }
    }
}