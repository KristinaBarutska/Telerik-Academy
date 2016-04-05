/*
    Problem 7. Reverse number
    Write a method that reverses the digits of given decimal number.Problem 7. Reverse number
    Write a method that reverses the digits of given decimal number.
*/

namespace ReverseNumbers
{
    using System;

    public class NumberReverser
    {
        private static void Main()
        {
            Console.Write("Number: ");
            var number = double.Parse(Console.ReadLine());
            var reversed = ReverseNumber(number);

            Console.WriteLine($"{number} reversed is {reversed}");
        }

        private static double ReverseNumber(double number)
        {
            var result = string.Empty;
            var numberAsString = number.ToString();

            for (int i = numberAsString.Length - 1; i >= 0; i--)
            {
                result += numberAsString[i];
            }

            return double.Parse(result);
        }
    }
}