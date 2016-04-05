/*
    Problem 2. Reverse string
    Write a program that reads a string, reverses it and prints the result at the console.
    Example:
    input 	output
    sample 	elpmas
*/

namespace ReverseString
{
    using System;
    using System.Text;

    public class StringReverser
    {
        public static void Main()
        {
            string stringToReverse = Console.ReadLine();

            Console.WriteLine(stringToReverse);

            ReverseString(ref stringToReverse);

            Console.WriteLine(stringToReverse);
        }

        private static void ReverseString(ref string stringToReverse)
        {
            var reversedStringContainer = new StringBuilder();

            for (int i = stringToReverse.Length - 1; i >= 0; i--)
            {
                reversedStringContainer.Append(stringToReverse[i]);
            }

            stringToReverse = reversedStringContainer.ToString();
        }
    }
}