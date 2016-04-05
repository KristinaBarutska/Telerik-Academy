/* 
    Problem 1. Fill the matrix
    Write a program that fills and prints a matrix of size (n, n) as shown below: 

    7	11	14	16
    4	8	12	15
    2	5	9	13
    1	3	6	10

*/

namespace PrintMatrixVariantC
{
    using System;
    using Matrix;

    public class VariantC
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var matrix = new Matrix<int>(n, n);
            int index = 1;

            for (int i = n - 1; i >= 0; i--)
            {
                int col = 0;
                int row = i;

                while (row < n && col < n)
                {
                    matrix[row, col] = index;
                    row++;
                    col++;
                    index++;
                }
            }

            for (int i = 1; i < n; i++)
            {
                int col = 0;
                int row = i;

                while (row < n && col < n)
                {
                    matrix[col, row] = index;
                    col++;
                    row++;
                    index++;
                }
            }

            Console.WriteLine(matrix);
        }
    }
}