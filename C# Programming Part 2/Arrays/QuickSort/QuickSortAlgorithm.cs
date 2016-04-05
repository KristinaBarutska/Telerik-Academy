/*  
    Problem 14. Quick sort
    Write a program that sorts an array of integers using the Quick sort algorithm. 
*/

namespace QuickSortAlgorithm
{
    using System;
    using System.Linq;

    public class QuickSortAlgorithm
    {
        private static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split(new char[] { ',', '.', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n))
                .ToArray();

            QuickSort(numbers, 0, numbers.Length - 1);

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void QuickSort(int[] numbers, int left, int right)
        {
            int i = left;
            int j = right;
            int pivot = numbers[(left + right) / 2];

            while (i <= j)
            {
                while (numbers[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (numbers[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    int tmp = numbers[i];
                    numbers[i] = numbers[j];
                    numbers[j] = tmp;

                    i++;
                    j--;
                }
            }

            if (left < j)
            {
                QuickSort(numbers, left, j);
            }

            if (i < right)
            {
                QuickSort(numbers, i, right);
            }
        }
    }
}