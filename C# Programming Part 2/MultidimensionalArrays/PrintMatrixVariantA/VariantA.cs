/*  
    Problem 1. Fill the matrix
    Write a program that fills and prints a matrix of size (n, n) as shown below: 

    1	5	9	13
    2	6	10	14
    3	7	11	15
    4	8	12	16

*/

namespace PrintMatrixVariantA
{
    using System;

    using Matrix;

    public class VariantA
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
                    matrix[row, col] = index;
                    index++;
                }
            }

            Console.WriteLine(matrix);
        }
    }
}