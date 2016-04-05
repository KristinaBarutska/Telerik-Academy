/*  
    Problem 10. Find sum in array
    Write a program that finds in given array of integers a sequence of given sum S (if present).
    Example: 
    
    array                   S            result
    4, 3, 1, 4, 2, 5, 8	    11          4, 2, 5 
*/

namespace FindSumInArray
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SumFinder
    {
        private static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split(new char[] { ',', '.', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n))
                .ToArray();
            int s = int.Parse(Console.ReadLine());
            var sequenceWithSumS = FindSequenceWithSum(numbers, 11);

            foreach (var number in sequenceWithSumS)
            {
                Console.Write(number + " ");
            }
        }

        private static List<int> FindSequenceWithSum(int[] numbers, int s)
        {
            int bestStart = 0;
            int end = 0;
            var sequenceWithSumS = new List<int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                int currentStart = i;
                int currentSum = numbers[currentStart];

                for (int j = currentStart + 1; j < numbers.Length; j++)
                {
                    if (currentSum > s)
                    {
                        currentSum = numbers[currentStart];
                        break;
                    }
                    else
                    {
                        currentSum += numbers[j];
                    }

                    if (currentSum == s)
                    {
                        bestStart = currentStart;
                        end = j;
                    }
                }
            }

            foreach (int number in numbers)
            {
                for (int i = bestStart; i <= end; i++)
                {
                    sequenceWithSumS.Add(numbers[i]);
                }

                break;
            }

            return sequenceWithSumS;
        }
    }
}