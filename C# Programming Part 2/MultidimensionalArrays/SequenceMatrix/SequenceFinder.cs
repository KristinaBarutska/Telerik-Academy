/* 
    Problem 3. Sequence n matrix
    We are given a matrix of strings of size N x M. Sequences in the matrix we define as sets of several neighbour elements located on the same line, column or diagonal.
    Write a program that finds the longest sequence of equal strings in the matrix.
    Example:
    matrix:                
    		               result:
    ha	fifi ho	hi         ha, ha, ha
    fo	ha	 hi	xx
    xxx	ho	 ha	xx
*/

namespace SequenceMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SequenceFinder
    {
        private static List<string> sequence = new List<string>();
        private static int currentCounter = 1;
        private static int bestCounter = 0;
        private static string value = string.Empty;

        private static void Main()
        {
            var matrix = new string[3, 4]
            {
                { "ha", "fifi", "ho", "hi" },
                { "fo", "ha", "hi", "xx" },
                { "xxx", "hi", "ha", "xx" }
            };
            var sequences = new List<List<string>>();
            var verticalSequence = CheckVertically(matrix);
            var horizontalSequence = CheckHorizontally(matrix);
            var mainDiagonalSequence = CheckMainDiagonal(matrix);
            var secondaryDiagSeq = CheckSecondaryDiagonal(matrix);

            sequences.Add(verticalSequence);
            sequences.Add(horizontalSequence);
            sequences.Add(mainDiagonalSequence);
            sequences.Add(secondaryDiagSeq);

            var sortedByLength = sequences.OrderBy(seq => seq.Count).ToList();
            var longestSequence = sortedByLength[3];

            Console.WriteLine($"Longest sequence in the matrix: {string.Join(" ", longestSequence)}");
        }

        private static List<string> CheckVertically(string[,] matrix)
        {
            sequence.Clear();

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                for (int row = 0; row < matrix.GetLength(0) - 1; row++)
                {
                    if (matrix[row, col] == matrix[row + 1, col])
                    {
                        currentCounter++;
                    }
                    else
                    {
                        currentCounter = 1;
                    }

                    if (bestCounter < currentCounter)
                    {
                        bestCounter = currentCounter;
                        value = matrix[row, col];
                    }
                }
            }

            FillList(value, bestCounter, sequence);

            return sequence;
        }

        private static List<string> CheckHorizontally(string[,] matrix)
        {
            sequence.Clear();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    if (matrix[row, col] == matrix[row, col + 1])
                    {
                        currentCounter++;
                    }
                    else
                    {
                        currentCounter = 1;
                    }

                    if (bestCounter < currentCounter)
                    {
                        bestCounter = currentCounter;
                        value = matrix[row, col];
                    }
                }
            }

            FillList(value, bestCounter, sequence);

            return sequence;
        }

        private static List<string> CheckMainDiagonal(string[,] matrix)
        {
            sequence.Clear();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    for (int row = i, col = j; row < matrix.GetLength(0) - 1 &&
                        col < matrix.GetLength(1) - 1; row++, col++)
                    {
                        if (matrix[row, col] == matrix[row + 1, col + 1])
                        {
                            currentCounter++;
                        }
                        else
                        {
                            currentCounter = 1;
                        }

                        if (bestCounter < currentCounter)
                        {
                            bestCounter = currentCounter;
                            value = matrix[row, col];
                        }
                    }
                }
            }

            FillList(value, bestCounter, sequence);

            return sequence;
        }

        private static List<string> CheckSecondaryDiagonal(string[,] matrix)
        {
            sequence.Clear();

            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    for (int row = i, col = j; row < matrix.GetLength(0) - 1 && col > 0; row++, col--)
                    {
                        if (matrix[row, col] == matrix[row + 1, col - 1])
                        {
                            currentCounter++;
                        }
                        else
                        {
                            currentCounter = 1;
                        }

                        if (bestCounter < currentCounter)
                        {
                            bestCounter = currentCounter;
                            value = matrix[row, col];
                        }
                    }
                }
            }

            FillList(value, bestCounter, sequence);

            return sequence;
        }

        private static void FillList(string value, int count, List<string> sequence)
        {
            for (int i = 0; i < count; i++)
            {
                sequence.Add(value);
            }
        }
    }
}