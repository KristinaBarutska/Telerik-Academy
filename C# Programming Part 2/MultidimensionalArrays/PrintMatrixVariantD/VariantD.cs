/* 
    Problem 1. Fill the matrix
    Write a program that fills and prints a matrix of size (n, n) as shown below:
    
    1	12	11	10
    2	13	16	9
    3	14	15	8
    4	5	6	7
*/

namespace PrintMatrixVariantD
{
    using System;
    using Matrix;

    public class VariantD
    {
        private static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var matrix = new Matrix<int>(n, n);
            int index = 1;
            int row = 0;
            int col = 0;

            for (int i = 0; i < n * n; i++)
            {
                int cellCounter = 0;

                // down
                while (cellCounter < n)
                {
                    matrix[row, col] = index;
                    row++;
                    index++;
                    cellCounter++;
                }

                // right
                cellCounter = 0;
                row--;

                while (cellCounter < n - 1)
                {
                    col++;
                    matrix[row, col] = index;
                    index++;
                    cellCounter++;
                }

                // top
                cellCounter = 0;

                while (cellCounter < n - 1)
                {
                    row--;
                    matrix[row, col] = index;
                    index++;
                    cellCounter++;
                }

                // left
                cellCounter = 0;

                while (cellCounter < n - 2)
                {
                    col--;
                    matrix[row, col] = index;
                    index++;
                    cellCounter++;
                }

                n -= 2;
                row++;
            }

            Console.WriteLine(matrix);
        }
    }
}