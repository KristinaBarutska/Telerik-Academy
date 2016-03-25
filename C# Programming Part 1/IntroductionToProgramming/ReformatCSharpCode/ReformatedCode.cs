/*
    Problem 10. Reformat C# Code
    Reformat the following C# code to make it readable according to the C# best practices for code formatting. 
    Change the casing of the identifiers in the code (e.g. use PascalCase for the class name): HorribleCode.cs
*/

namespace ReformatCSharpCode
{
    using System;

    public class ReformatedCode
    {
        public static void Main()
        {
            Console.WriteLine("Hi, I am perfectly formatted program");
            Console.WriteLine("Numbers and squares:");

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i + " --> " + (i * i));
            }
        }
    }
}
