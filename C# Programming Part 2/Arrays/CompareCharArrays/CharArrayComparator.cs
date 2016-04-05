/* 
    Problem 3. Compare char arrays
    Write a program that compares two char arrays lexicographically (letter by letter).
*/

namespace CompareCharArrays
{
    using System;
    using System.Linq;

    public class CharArrayComparator
    {
        public static void Main()
        {
            Console.Write("Enter first array of characters on a single line : ");
            char[] firstArray = Console.ReadLine().ToCharArray();
            Console.Write("Enter first array of characters on a single line : ");
            char[] secondArray = Console.ReadLine().ToCharArray();
            var areEqual = firstArray.Length == secondArray.Length &&
                           firstArray.OrderBy(s => s).SequenceEqual(secondArray.OrderBy(s => s));

            Console.WriteLine("Are equal ? : {0}", areEqual);
        }
    }
}