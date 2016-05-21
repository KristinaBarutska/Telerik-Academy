namespace _03.LoverOfThree
{
    using System;
    using System.Numerics;

    public class LoverOfThree
    {
        public static void Main()
        {
            int[,] field = GetField();
            int n = int.Parse(Console.ReadLine());
            int row = field.GetLength(0) - 1;
            int col = 0;
            int maxRow = field.GetLength(0) - 1;
            int maxCol = field.GetLength(1) - 1;
            BigInteger pathSum = 0;

            for (int i = 0; i < n; i++)
            {
                string[] moveInfo = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string direction = moveInfo[0];
                int stepsCount = int.Parse(moveInfo[1]);

                for (int j = 0; j < stepsCount - 1; j++)
                {
                    int rowMovesValue = 0;
                    int colMovesValue = 0;

                    GetMoveValue(direction, ref rowMovesValue, ref colMovesValue);

                    int nextRow = row + rowMovesValue;
                    int nextCol = col + colMovesValue;

                    if (IsValidMove(nextRow, maxRow) && IsValidMove(nextCol, maxCol))
                    {
                        row = nextRow;
                        col = nextCol;

                        int cellValue = field[row, col];

                        pathSum += cellValue;
                        field[row, col] = 0;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            Console.WriteLine(pathSum);
        }

        private static int[,] GetField()
        {
            string[] rowsAndCols = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int numberOfRows = int.Parse(rowsAndCols[0]);
            int numberOfCols = int.Parse(rowsAndCols[1]);
            int[,] field = new int[numberOfRows, numberOfCols];
            int rowStartIndex = 0;

            for (int row = numberOfRows - 1; row >= 0; row--, rowStartIndex += 3)
            {
                int currentCellValue = rowStartIndex;

                for (int col = 0; col < numberOfCols; col++, currentCellValue += 3)
                {
                    field[row, col] = currentCellValue;
                }
            }

            return field;
        }

        private static bool IsValidMove(int move, int max)
        {
            bool isValid = false;

            if (move <= max && move >= 0)
            {
                isValid = true;
            }

            return isValid;
        }

        private static void GetMoveValue(string move, ref int rowMovesValue, ref int colMovesValue)
        {
            if (move.Contains("U"))
            {
                rowMovesValue = -1;
            }
            else if (move.Contains("D"))
            {
                rowMovesValue = 1;
            }

            if (move.Contains("R"))
            {
                colMovesValue = 1;
            }
            else if (move.Contains("L"))
            {
                colMovesValue = -1;
            }
        }
    }
}