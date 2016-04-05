/* 
    Problem 4. Maximal sequence
    Write a program that finds the maximal sequence of equal elements in an array. 
*/

namespace MaximalSequence
{
    using System;
    using System.Linq;

    public class MaximalSequenceFounder
    {
        private static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n))
                .ToArray();
            var sequenceInfo = FindLongestSequence(numbers);

            Console.Write("Longes sequence : ");

            for (int i = 0; i <= sequenceInfo[0]; i++)
            {
                Console.Write("{0} ", sequenceInfo[1]);
            }
        }

        private static int[] FindLongestSequence(int[] numbers)
        {
            int currentCounter = 0;
            int bestCounter = 0;
            int bestNumber = numbers[0];

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

                if (bestCounter < currentCounter)
                {
                    bestCounter = currentCounter;
                    bestNumber = numbers[i];
                }
            }

            return new int[2] { bestCounter, bestNumber };
        }
    }
}