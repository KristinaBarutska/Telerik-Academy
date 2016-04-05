/*
    Problem 5. Workdays
    Write a method that calculates the number of workdays between today and given date, passed as parameter.
    Consider that workdays are all days from Monday to Friday except a fixed list of public holidays
    specified preliminary as array. 
*/

namespace WorkDays
{
    using System;
    using System.Collections.Generic;

    public class WorkdaysCounter
    {
        private static void Main()
        {
            Console.Write("End date in format yyyy.mm.dd: ");
            DateTime endDate = DateTime.Parse(Console.ReadLine());
            DateTime today = DateTime.Today;
            int workDays = CountWorkDays(today, endDate);

            Console.WriteLine($"Workdays: {workDays}");
        }

        private static int CountWorkDays(DateTime startDate, DateTime endDate)
        {
            var publicHolydays = new List<DateTime>()
            {
                new DateTime(2016, 1, 1),
                new DateTime(2016, 3, 3),
                new DateTime(2016, 5, 1),
                new DateTime(2016, 5, 6),
                new DateTime(2016, 5, 24),
                new DateTime(2016, 9, 6),
                new DateTime(2016, 9, 22),
                new DateTime(2016, 12, 23),
                new DateTime(2016, 12, 24),
                new DateTime(2016, 12, 25)
            };
            int workDaysCount = 0;

            while (startDate < endDate)
            {
                if (!publicHolydays.Contains(startDate) && (int)startDate.DayOfWeek != 0 &&
                    (int)startDate.DayOfWeek != 6)
                {
                    workDaysCount++;
                }

                startDate = startDate.AddDays(1);
            }

            return workDaysCount;
        }
    }
}