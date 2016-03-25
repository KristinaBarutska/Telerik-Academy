/*
    Problem 16.* Print Long Sequence
    Write a program that prints the first 1000 members of the sequence: 2, -3, 4, -5, 6, -7, …
    You might need to learn how to use loops in C# (search in Internet).
*/

namespace PrintLongSequence
{
    using System;
    using System.Collections.Generic;

    public class LongSequencePrinter
    {
        public static void Main()
        {
            int number = 2;
            IList<int> sequence = new List<int>();

            for (int i = 0; i < 1000; i++, number++)
            {
                if (i % 2 == 0)
                {
                    sequence.Add(number);
                }
                else
                {
                    sequence.Add(-number);
                }
            }

            Console.WriteLine(string.Join("\n", sequence));
        }
    }
}