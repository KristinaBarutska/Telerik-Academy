/*
    Problem 2. Compare arrays
    Write a program that reads two integer arrays from the console and compares 
    them element by element. 
*/

namespace CompareArrays
{
    using System;
    using System.Linq;

    public class IntArrayComparator
    {
        private static void Main()
        {
            Console.Write("Enter the first array of integers on a single line : ");
            var firstArray = ReadArray();
            Console.Write("Enter the second array of integers on a single line : ");
            var secondArray = ReadArray();
            var areEqual = firstArray.Length == secondArray.Length &&
                           firstArray.OrderBy(s => s).SequenceEqual(secondArray.OrderBy(s => s));

            Console.WriteLine("Are equal ? : {0}", areEqual);
        }

        private static int[] ReadArray()
        {
            var readedArray = Console.ReadLine()
                .Split(new char[] { ' ', ',', '.' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n))
                .ToArray();

            return readedArray;
        }
    }
}