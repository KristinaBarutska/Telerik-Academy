/*  
    Problem 11. Binary search
    Write a program that finds the index of given element in a sorted array of integers by 
    using the Binary search algorithm. 
*/

namespace BinarySearch
{
    using System;
    using System.Linq;

    public class BinarySearch
    {
        private static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split(new char[] { ',', '.', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n))
                .ToArray();
            int key = int.Parse(Console.ReadLine());
            int indexOfKey = GetIndexOfKey(numbers, key);

            Console.WriteLine($"The index of {key} is {indexOfKey}");
        }

        private static int GetIndexOfKey(int[] numbers, int key)
        {
            int index = 0;
            int min = 0;
            int max = numbers.Length - 1;

            while (min <= max)
            {
                int middleElement = (max + min) / 2;

                if (numbers[middleElement] == key)
                {
                    index = middleElement;
                    break;
                }
                else if (numbers[middleElement] < key)
                {
                    min = middleElement + 1;
                }
                else
                {
                    max = middleElement - 1;
                }
            }

            return index;
        }
    }
}