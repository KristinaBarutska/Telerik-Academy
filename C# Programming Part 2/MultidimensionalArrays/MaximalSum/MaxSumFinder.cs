/*
    Problem 2. Maximal sum
    Write a program that reads a rectangular matrix of size N x M and finds 
    in it the square 3 x 3 that has maximal sum of its elements. 
*/

namespace MaximalSum
{
    using System;

    public class MaxSumFinder
    {
        private static void Main()
        {
            var matrix = new int[5, 5]
            {
                { 1, 2, 3, 4, 9 },
                { 5, 9, 9, 9, 5 },
                { 7, 9, 9, 9, 4 },
                { 5, 9, 9, 9, 1 },
                { 1, 2, 3, 4, 9 }
            };
            int sum = 0;

            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    int currentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] +
                        matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
                        matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                    if (sum < currentSum)
                    {
                        sum = currentSum;
                    }
                }
            }

            Console.WriteLine($"Best sum: {sum}");
        }
    }
}