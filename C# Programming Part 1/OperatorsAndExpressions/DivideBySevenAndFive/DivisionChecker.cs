/*
    Problem 3. Divide by 7 and 5
    Write a Boolean expression that checks for given integer if it can be divided (without remainder) by 7 and 5 at the same time.
*/

namespace DivideBySevenAndFive
{
    using System;

    public class DivisionChecker
    {
        public static void Main()
        {
            Console.Write("Enter integer number: ");
            int number = int.Parse(Console.ReadLine());
            bool isDivisibleBySevenAndFive = number % (7 * 5) == 0;

            Console.WriteLine($"Is divisible by 7 and 5 ? : {isDivisibleBySevenAndFive}");
        }
    }
}