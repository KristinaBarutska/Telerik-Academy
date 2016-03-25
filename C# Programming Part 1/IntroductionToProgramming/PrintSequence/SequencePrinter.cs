/*
    Problem 9. Print a Sequence
    Write a program that prints the first 10 members of the sequence: 2, -3, 4, -5, 6, -7, ...
*/

namespace PrintSequence
{
    using System;
    using System.Collections.Generic;

    public class SequencePrinter
    {
        public static void Main()
        {
            int number = 2;
            IList<int> sequence = new List<int>();

            for (int i = 0; i < 10; i++, number++)
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