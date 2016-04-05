/*
    Problem 1. Fill the matrix
    Write a program that fills and prints a matrix of size (n, n) as shown below:

    1	8	9	16
    2	7	10	15
    3	6	11	14
    4	5	12	13

*/

namespace PrintMatrixVariantB
{
    using System;
    using Matrix;

    public class VariantB
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var matrix = new Matrix<int>(n, n);
            int index = 1;

            for (int col = 0; col < matrix.Height; col++)
            {
                for (int row = 0; row < matrix.Width; row++)
                {
                    if (col % 2 == 0)
                    {
                        matrix[row, col] = index;
                        index++;
                    }
                    else
                    {
                        index--;
                        matrix[row, col] = index;
                    }
                }

                index += 4;
            }

            Console.WriteLine(matrix);
        }
    }
}