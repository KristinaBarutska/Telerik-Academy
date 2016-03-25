/*
    Problem 15.* Age after 10 Years
    Write a program to read your birthday from the console and print how old you are now and how old you will be after 10 years.
*/

namespace AgeAfterTenYears
{
    using System;

    public class AgeAfterTenYears
    {
        public static void Main()
        {
            var birthDate = DateTime.Parse(Console.ReadLine());
            TimeSpan ageUntilNow = DateTime.Now - birthDate;
            int ageNow = ageUntilNow.Days / 365;
            Console.WriteLine(ageNow + "\n" + (ageNow + 10));
        }
    }
}