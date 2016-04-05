/* 
    Problem 5. Maximal increasing sequence
    Write a program that finds the maximal increasing sequence in an array. 
*/

namespace MaximalIncreasingSequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class IncreasingSequenceFounder
    {
        private static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(n => int.Parse(n))
                .ToArray();
            var sequence = FindSequence(numbers);

            Console.WriteLine(string.Join(" ", sequence));
        }

        private static HashSet<int> FindSequence(int[] numbers)
        {
            var currentSequence = new HashSet<int>();
            var bestSequence = new HashSet<int>();

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                int startNumber = numbers[i];

                if (startNumber < numbers[i + 1])
                {
                    currentSequence.Add(startNumber);
                    currentSequence.Add(numbers[i + 1]);
                }
                else
                {
                    currentSequence.Clear();
                }

                if (bestSequence.Count < currentSequence.Count)
                {
                    bestSequence = new HashSet<int>(currentSequence);
                }
            }

            return bestSequence;
        }
    }
}