namespace Matrix
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            Matrix<int> firstMatrix = new Matrix<int>(3, 3);
            Matrix<int> secondMatrix = new Matrix<int>(3, 3);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    firstMatrix[i, j] = i;
                    secondMatrix[i, j] = 2;
                }
            }

            Matrix<int> additionResult = firstMatrix + secondMatrix;
            Matrix<int> substractionResul = firstMatrix - secondMatrix;
            Matrix<int> multiplicationResult = firstMatrix * secondMatrix;

            if (additionResult)
            {
                Console.WriteLine(true);
            }
            else
            {
                Console.WriteLine(false);
            }

            additionResult[1, 1] = 9999999;

            Console.WriteLine(additionResult);            
        }
    }
}