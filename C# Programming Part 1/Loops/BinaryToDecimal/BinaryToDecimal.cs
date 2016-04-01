/*
    Problem 13. Binary to Decimal Number
    Using loops write a program that converts a binary integer number to its decimal form.
    The input is entered as string. The output should be a variable of type long.
    Do not use the built-in .NET functionality.
*/

namespace BinaryToDecimal
{
    using System;
    using System.Linq;

    public class BinaryToDecimal
    {
        public static void Main()
        {
            Console.Write("Enter a bit representation of a integer number : ");
            int[] binaryRepresentation = Console.ReadLine()
                .ToCharArray()
                .Select(n => (int)(n - '0'))
                .Reverse()
                .ToArray();
            long number = 0;

            for (int i = 0; i < binaryRepresentation.Length; i++)
            {
                if (binaryRepresentation[i] == 1)
                {
                    number += 1 * (int)Math.Pow(2, i);
                }
                else
                {
                    number += 0 * (int)Math.Pow(2, i);
                }
            }

            Console.WriteLine($"The number in decimal format is : {number}");
        }
    }
}