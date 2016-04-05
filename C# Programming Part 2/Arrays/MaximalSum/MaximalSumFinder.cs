/* 
    Problem 8. Maximal sum
    Write a program that finds the sequence of maximal sum in given array.
    Example:
    input                                  result
    2, 3, -6, -1, 2, -1, 6, 4, -8, 8       2, -1, 6, 4   
    Can you do it with only one loop (with single scan through the elements of the array)? 
*/

namespace MaximalSum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MaximalSumFinder
    {
        private static void Main()
        {
            var numbers = Console.ReadLine()
              .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
              .Select(n => int.Parse(n))
              .ToArray();
            var bestSumSequence = GetMaxSumSequence(numbers);

            Console.WriteLine(string.Join(" ", bestSumSequence));
        }

        private static List<int> GetMaxSumSequence(int[] numbers)
        {
            int currentStartIndex = numbers[0];
            int bestStartIndex = numbers[0];
            int currentSum = 0;
            int bestSum = 0;
            int endIndex = 0;
            var bestSumSequence = new List<int>();

            for (int i = 1; i < numbers.Length; i++)
            {
                if (currentSum < 0)
                {
                    currentSum = numbers[i];
                    currentStartIndex = i;
                }
                else
                {
                    currentSum += numbers[i];
                }

                if (bestSum < currentSum)
                {
                    bestSum = currentSum;
                    bestStartIndex = currentStartIndex;
                    endIndex = i;
                }
            }

            foreach (int number in numbers)
            {
                for (int j = bestStartIndex; j <= endIndex; j++)
                {
                    bestSumSequence.Add(numbers[j]);
                }

                break;
            }

            return bestSumSequence;
        }
    }
}