/*  
    Problem 9. Frequent number
    Write a program that finds the most frequent number in an array.
    Example:
    input                                   result
    4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3   4 (5 times) */

namespace FrequentNumber
{
    using System;
    using System.Linq;

    public class FrequentNumber
    {
        private static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split(new char[] { ',', '.', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n))
                .ToArray();
            int mostFrequentNumber = GetMostFrequentNum(numbers);

            Console.Write(mostFrequentNumber);
        }

        private static int GetMostFrequentNum(int[] numbers)
        {
            int mostFrequent = numbers[0];
            int currentCounter = 0;
            int maxCounter = 0;

            Array.Sort(numbers);

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (numbers[i] == numbers[i + 1])
                {
                    currentCounter++;
                }
                else
                {
                    currentCounter = 0;
                }

                if (maxCounter < currentCounter)
                {
                    maxCounter = currentCounter;
                    mostFrequent = numbers[i];
                }
            }

            return maxCounter;
        }
    }
}
