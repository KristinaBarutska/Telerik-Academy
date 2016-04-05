/*  
    Problem 13.* Merge sort
    Write a program that sorts an array of integers using the Merge sort algorithm. 
*/

namespace MergeSort
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MergeSortAlgorithm
    {
        private static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split(new char[] { ',', '.', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n))
                .ToArray();
            int[] sortedArray = MergeSort(numbers);

            Console.WriteLine(string.Join(" ", sortedArray));
        }

        private static int[] MergeSort(int[] numbers)
        {
            if (numbers.Length <= 1)
            {
                return numbers;
            }

            int middleIndex = numbers.Length / 2;
            int[] left = new int[middleIndex];
            int[] right = new int[numbers.Length - middleIndex];

            Array.Copy(numbers, left, middleIndex);
            Array.Copy(numbers, middleIndex, right, 0, right.Length);

            left = MergeSort(left);
            right = MergeSort(right);

            return Merge(left, right);
        }

        private static int[] Merge(int[] left, int[] right)
        {
            List<int> leftList = left.OfType<int>().ToList();
            List<int> rightList = right.OfType<int>().ToList();
            List<int> resultList = new List<int>();

            while (leftList.Count > 0 || rightList.Count > 0)
            {
                if (leftList.Count > 0 && rightList.Count > 0)
                {
                    if (leftList[0] <= rightList[0])
                    {
                        resultList.Add(leftList[0]);
                        leftList.RemoveAt(0);
                    }
                    else
                    {
                        resultList.Add(rightList[0]);
                        rightList.RemoveAt(0);
                    }
                }
                else if (leftList.Count > 0)
                {
                    resultList.Add(leftList[0]);
                    leftList.RemoveAt(0);
                }
                else if (rightList.Count > 0)
                {
                    resultList.Add(rightList[0]);
                    rightList.RemoveAt(0);
                }
            }

            int[] result = resultList.ToArray();

            return result;
        }
    }
}