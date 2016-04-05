/* 
    Problem 9. Sorting array
    Write a method that return the maximal element in a portion of array of integers starting at given index.
    Using it write another method that sorts an array in ascending / descending order. 
*/

namespace SortingArray
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Sorter
    {
        private static void Main()
        {
            Console.Write("Enter array of numbers on a single line: ");
            var numbers = Console.ReadLine()
                .Split(' ')
                .Select(n => int.Parse(n))
                .ToList();

            var sortedDescending = SortDescending(numbers);
            var sortedAscending = SortAscending(numbers);

            Console.WriteLine($"Descending : {string.Join(" ", sortedDescending)}");
            Console.WriteLine($"Ascending : {string.Join(" ", sortedAscending)}");
        }

        private static int GetMaxElementOfProtion(List<int> numbers, int start, int end)
        {
            int max = numbers[start];
            int maxIndex = start;

            for (int i = start; i < end; i++)
            {
                int currentMax = Math.Max(numbers[i], numbers[i + 1]);

                if (max < currentMax)
                {
                    max = currentMax;
                    maxIndex = numbers.IndexOf(max);
                }
            }

            return maxIndex;
        }

        private static int[] SortDescending(List<int> numbers)
        {
            var copy = new List<int>(numbers);
            var sorted = new int[numbers.Count];
            int index = 0;

            while (copy.Count > 0)
            {
                var maxElementIndex = GetMaxElementOfProtion(copy, 0, copy.Count - 1);

                sorted[index] = copy[maxElementIndex];
                copy.RemoveAt(maxElementIndex);
                index++;
            }

            return sorted;
        }

        private static int[] SortAscending(List<int> numbers)
        {
            var copy = new List<int>(numbers);
            var sorted = new int[numbers.Count];
            int index = sorted.Length - 1;

            while (copy.Count > 0)
            {
                var maxElementIndex = GetMaxElementOfProtion(copy, 0, copy.Count - 1);

                sorted[index] = copy[maxElementIndex];
                copy.RemoveAt(maxElementIndex);
                index--;
            }

            return sorted;
        }
    }
}