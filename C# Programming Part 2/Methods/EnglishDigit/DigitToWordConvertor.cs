/*
    Problem 3. English digit
    Write a method that returns the last digit of given integer as an English word. 
*/

namespace EnglishDigit
{
    using System;

    public class DigitToWordConvertor
    {
        private static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            int lastDigit = number % 10;
            var lastDigitAsWord = GetDigitAsWord(lastDigit);

            Console.WriteLine($"The last digit of {number} is {lastDigit} and as word is \"{lastDigitAsWord}\"");
        }

        private static string GetDigitAsWord(int digit)
        {
            string[] words = { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };

            return words[digit];
        }
    }
}