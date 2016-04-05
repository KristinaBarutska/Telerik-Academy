namespace Matrix
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var firstMatrix = new Matrix<string>(3, 3);
            var secondMatrix = new Matrix<string>(3, 3);
            int index = 0;

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    firstMatrix[row, col] = "a";
                    secondMatrix[row, col] = "b";
                    index++;
                }
            }

            var sumOfMatrices = firstMatrix + secondMatrix;

            for (int row = 0; row < sumOfMatrices.Width; row++)
            {
                for (int col = 0; col < sumOfMatrices.Height; col++)
                {
                    Console.Write(" " + sumOfMatrices[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}