/*  
    Problem 7. Selection sort
    Sorting an array means to arrange its elements in increasing order. Write a program to sort an array.
    Use the Selection sort algorithm: Find the smallest element, move it at the first position, find the
    smallest from the rest, move it at the second position, etc. 
*/

namespace SelectionSort
{
    using System;
    using System.Linq;

    public class NumbersSorter
    {
        private static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(' ')
                .Select(n => int.Parse(n))
                .ToArray();

            SortBySelection(numbers);

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void SortBySelection(int[] numbers)
        {
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                int minIndex = i;

                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[j] < numbers[minIndex])
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    int oldValue = numbers[minIndex];
                    numbers[minIndex] = numbers[i];
                    numbers[i] = oldValue;
                }
            }
        }
    }
}