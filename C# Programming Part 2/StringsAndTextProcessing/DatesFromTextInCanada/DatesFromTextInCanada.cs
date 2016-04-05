/*
    Problem 19. Dates from text in Canada
    Write a program that extracts from a given text all dates that match the format DD.MM.YYYY.
    Display them in the standard date format for Canada.
*/

using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace DatesFromTextInCanada
{
    public class DatesFromTextInCanada
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            foreach (var item in Regex.Matches(input, @"\w+\.\w+\.\w+"))
            {
                Console.WriteLine("{0}", item, CultureInfo.GetCultureInfo("en-CA"));
            }
        }
    }
}