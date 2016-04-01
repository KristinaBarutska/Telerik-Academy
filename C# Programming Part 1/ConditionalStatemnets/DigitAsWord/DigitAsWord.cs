/*
    Problem 8. Digit as Word
    Write a program that asks for a digit (0-9), and depending on the input, shows the digit as a word (in English).
    Print “not a digit” in case of invalid input.
    Use a switch statement.
*/

namespace DigitAsWord
{
    using System;

    public class DigitAsWord
    {
        public static void Main()
        {
            Console.Write("Digit: ");
            int digit = int.Parse(Console.ReadLine());
            string[] digitWords = { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };

            if (digit < 0 || digit > 9)
            {
                Console.WriteLine("Not a digit.");
            }
            else
            {
                Console.WriteLine(digitWords[digit]);
            }
        }
    }
}