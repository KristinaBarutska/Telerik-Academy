﻿/*
    Problem 14.* Current Date and Time
    Create a console application that prints the current date and time. Find out how in Internet.
*/

namespace CurrentDateAndTime
{
    using System;

    public class CurrentTimePrinter
    {
        public static void Main()
        {
            var dateTimeNow = DateTime.Now;

            Console.WriteLine(dateTimeNow);
        }
    }
}