/*
    Problem 5. Third Digit is 7?
    Write an expression that checks for given integer if its third digit from right-to-left is 7.
*/

namespace ThirdDigitIsSeven
{
    using System;

    public class ThirdDigitChecker
    {
        public static void Main()
        {
            Console.Write("Number: ");
            int number = int.Parse(Console.ReadLine());
            int thirdDigit = (number / 100) % 10;
            bool isThirdDigitSeven = thirdDigit == 7;

            Console.WriteLine($"Third digit is 7? {isThirdDigitSeven}");
        }
    }
}