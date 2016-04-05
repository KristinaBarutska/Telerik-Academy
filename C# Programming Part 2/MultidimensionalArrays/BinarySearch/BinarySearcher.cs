/*
    Problem 4. Binary search
    Write a program, that reads from the console an array of N integers and an integer K, sorts the array and using the method 
    Array.BinSearch() finds the largest number in the array which is ≤ K.
*/

namespace BinarySearch
{
    using System;

    public class BinarySearcher
    {
        private static void Main()
        {
            Console.Write("N: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("K: ");
            int k = int.Parse(Console.ReadLine());
            Console.Write("Numbers: ");
            int[] numbers = new int[n];

            for (int i = 0; i < n; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            Array.Sort(numbers);

            var result = GetLargestNumBeforeK(numbers, k);

            Console.WriteLine($"Result: {result}");
        }

        private static object GetLargestNumBeforeK(int[] numbers, int k)
        {
            if (numbers[0] > k)
            {
                return "There is no such number lower than K.";
            }
            else
            {
                int index = Array.BinarySearch(numbers, k);

                if (index >= 0)
                {
                    return numbers[index];
                }
                else
                {
                    return "There is no such number lower than K.";
                }
            }
        }
    }
}