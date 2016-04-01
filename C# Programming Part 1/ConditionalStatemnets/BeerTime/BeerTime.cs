/*
    Problem 10.* Beer Time
    A beer time is after 1:00 PM and before 3:00 AM.
    Write a program that enters a time in format “hh:mm tt” (an hour in range [01...12], a minute 
    in range [00…59] and AM / PM designator) and prints beer time or non-beer time according to the 
    definition above or invalid time if the time cannot be parsed. Note: You may need to learn how to parse dates and times
*/

namespace BeerTime
{
    using System;

    public class BeerTime
    {
        public static void Main()
        {
            Console.Write("Enter time in format hh:mm AM/PM : ");
            string timeAsString = Console.ReadLine();
            string designator = timeAsString.Substring(timeAsString.Length - 2, 2);
            string[] timeParts = timeAsString.Split(new char[] { ':', ' ', 'A', 'P', 'M' }, StringSplitOptions.RemoveEmptyEntries);
            int hours = int.Parse(timeParts[0]);
            int minutes = int.Parse(timeParts[1]);

            if (designator == "PM")
            {
                if (hours >= 1)
                {
                    Console.WriteLine("beer time");
                }
                else
                {
                    Console.WriteLine("non-beer time");
                }
            }
            else if (designator == "AM")
            {
                if (hours < 3 && minutes <= 59)
                {
                    Console.WriteLine("beer time");
                }
                else
                {
                    Console.WriteLine("non-beer time");
                }
            }
        }
    }
}