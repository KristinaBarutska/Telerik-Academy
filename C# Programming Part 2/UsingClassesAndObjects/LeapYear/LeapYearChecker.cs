/*
    Problem 1. Leap year
    Write a program that reads a year from the console and checks whether it is a leap one.
    Use System.DateTime. 
*/

namespace LeapYear
{
    using System;

    public class LeapYearChecker
    {
        private static void Main()
        {
            int year = int.Parse(Console.ReadLine());
            var result = DateTime.IsLeapYear(year);

            Console.WriteLine($"Is {year} leap? {result}");
        }
    }
}