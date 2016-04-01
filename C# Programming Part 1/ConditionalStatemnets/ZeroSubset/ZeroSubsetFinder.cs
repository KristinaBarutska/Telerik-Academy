/*
    Problem 12.* Zero Subset
    We are given 5 integer numbers. Write a program that finds all subsets of these numbers whose sum is 0.
    Assume that repeating the same subset several times is not a problem.
*/

namespace ZeroSubset
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ZeroSubsetFinder
    {
        public static void Main()
        {
            Console.Write("Numbers: ");
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(n => int.Parse(n))
                .ToArray();

            IList<int> zeroSubset = GetZeroSubset(numbers);

            if (zeroSubset.Count == 0)
            {
                Console.WriteLine("no zero subset");
            }
            else
            {
                Console.WriteLine(string.Join(" + ", zeroSubset) + " = 0");
            }
        }

        private static IList<int> GetZeroSubset(int[] numbers)
        {
            IList<int> currentSequence = new List<int>();
            IList<int> zeroSubset = new List<int>();
            int sum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i; j < numbers.Length; j++)
                {
                    currentSequence.Add(numbers[j]);
                    sum += numbers[j];

                    if (sum == 0)
                    {
                        zeroSubset = new List<int>(currentSequence);
                    }
                }

                currentSequence.Clear();
                sum = 0;
            }

            return zeroSubset;
        }
    }
}