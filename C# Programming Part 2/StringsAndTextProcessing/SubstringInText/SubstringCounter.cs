/*
    Problem 4. Sub-string in text
    
        Write a program that finds how many times a sub-string is contained in a given text (perform case insensitive search).
    
    Example:
    
    The target sub-string is in
    
    The text is as follows: We are living in an yellow submarine. We don't have anything else. inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.
    
    The result is: 9
*/

namespace SubstringInText
{
    using System;

    public class SubstringCounter
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            string targetSubstring = Console.ReadLine();
            int targetLength = targetSubstring.Length;
            int counter = 0;

            for (int i = 0; i < input.Length - targetLength; i++)
            {
                if (input.Substring(i, targetLength) == targetSubstring)
                {
                    counter++;
                    i += targetLength;
                }
            }

            Console.WriteLine($"Count: {counter}");
        }
    }
}