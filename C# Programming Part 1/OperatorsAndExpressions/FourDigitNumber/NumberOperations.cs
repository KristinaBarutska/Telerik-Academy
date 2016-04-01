/*
    Problem 6. Four-Digit Number
    Write a program that takes as input a four-digit number in format abcd (e.g. 2011) and performs the following:
    Calculates the sum of the digits (in our example 2 + 0 + 1 + 1 = 4).
    Prints on the console the number in reversed order: dcba (in our example 1102).
    Puts the last digit in the first position: dabc (in our example 1201).
    Exchanges the second and the third digits: acbd (in our example 2101).
*/

namespace FourDigitNumber
{
    using System;

    public class NumberOperations
    {
        private static int number = 2011;
        private static int firstDigit = (number / 1000) % 10;
        private static int secondDigit = (number / 100) % 10;
        private static int thirdDigit = (number / 10) % 10;
        private static int fourthDigit = number % 10;

        public static void Main()
        {
            int sum = CalculateSumOfDigits();
            int reversed = GetNumberInReversedOrder();
            int dabc = GetNumberInDabcForm();
            int acbd = GetNumberInAcbdForm();

            Console.WriteLine($"Sum: {sum}\nReversed: {reversed}\nDABC: {dabc}\nACBD: {acbd}");
        }

        private static int CalculateSumOfDigits()
        {
            int sum = firstDigit + secondDigit + thirdDigit + fourthDigit;
            return sum;
        }

        private static int GetNumberInReversedOrder()
        {
            int number = (fourthDigit * 1000) + (thirdDigit * 100) +
                (secondDigit * 10) + firstDigit;
            return number;
        }

        private static int GetNumberInDabcForm()
        {
            int number = (fourthDigit * 1000) + (firstDigit * 100) + 
                (secondDigit * 10) + thirdDigit;
            return number;
        }

        private static int GetNumberInAcbdForm()
        {
            int number = (firstDigit * 1000) + (thirdDigit * 100) +
                (secondDigit * 10) + fourthDigit;
            return number;
        }
    }
}