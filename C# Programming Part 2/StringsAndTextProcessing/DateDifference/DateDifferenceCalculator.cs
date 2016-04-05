/*
    Problem 16. Date difference
    
        Write a program that reads two dates in the format: day.month.year and calculates the number of days between them.
    
    Example:
    
    Enter the first date: 27.02.2006
    Enter the second date: 3.03.2006
    Distance: 4 days
*/

namespace DateDifference
{
    using System;
    using System.Linq;
    public class DateDifferenceCalculator
    {
        public static void Main()
        {
            Console.Write("Enter first date: ");
            DateTime firstDate = ReadDate();
            Console.Write("Enter second date: ");
            DateTime secondDate = ReadDate();
            int daysDistance = CalculateDateDifferenceInDays(firstDate, secondDate);

            Console.WriteLine($"Dstance: {daysDistance} days");
        }

        private static DateTime ReadDate()
        {
            int[] datePartsAsStrings = Console.ReadLine()
                .Split('.')
                .Select(p => int.Parse(p))
                .ToArray();
            int day = datePartsAsStrings[0];
            int month = datePartsAsStrings[1];
            int year = datePartsAsStrings[2];
            var date = new DateTime(year, month, day);

            return date;
        }

        private static int CalculateDateDifferenceInDays(DateTime firstDate, DateTime secondDate)
        {
            TimeSpan timeSpan = firstDate - secondDate;
            int differenceInDays = Math.Abs(timeSpan.Days);

            return differenceInDays;
        }
    }
}