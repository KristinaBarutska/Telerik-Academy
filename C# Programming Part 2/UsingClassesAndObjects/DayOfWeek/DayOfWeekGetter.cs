/*
    Problem 3. Day of week
    Write a program that prints to the console which day of the week is today.
    Use System.DateTime.
*/

namespace DayOfWeek
{
    using System;

    public class DayOfWeekGetter
    {
        private static void Main()
        {
            var today = DateTime.Today.DayOfWeek;

            Console.WriteLine($"{today}");
        }
    }
}