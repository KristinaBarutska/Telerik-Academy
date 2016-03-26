/*
    Problem 7. Quotes in Strings
    Declare two string variables and assign them with following value: The "use" of quotations causes difficulties.
    Do the above in two different ways - with and without using quoted strings.
    Print the variables to ensure that their value was correctly defined.
*/

namespace QuotesInStrings
{
    using System;

    public class Quotes
    {
        public static void Main()
        {
            string firstVariant = @"The ""use"" of quotations causes difficulties";
            string secondVariant = "The \"use\" of quotations causes difficulties";

            Console.WriteLine($"{firstVariant}\n{secondVariant}");
        }
    }
}