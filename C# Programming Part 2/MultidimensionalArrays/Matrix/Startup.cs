namespace Matrix
{
    using System;

    public class Startup
    {
        private static void Main()
        {
            var firstMatrix = new Matrix<int>(4, 4);
            var secondMatrix = new Matrix<int>(4, 4);
            int index = 0;

            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    firstMatrix[row, col] = index;
                    secondMatrix[row, col] = index;
                    index++;
                }
            }

            var addMatrices = firstMatrix + secondMatrix;
            Console.WriteLine(addMatrices);
            Console.WriteLine(Environment.NewLine);

            var productOfMatrices = firstMatrix * secondMatrix;
            Console.WriteLine(productOfMatrices);
            Console.WriteLine(Environment.NewLine);

            var substractionOfMatrices = firstMatrix - secondMatrix;
            Console.WriteLine(substractionOfMatrices);
            Console.WriteLine(Environment.NewLine);
        }
    }
}