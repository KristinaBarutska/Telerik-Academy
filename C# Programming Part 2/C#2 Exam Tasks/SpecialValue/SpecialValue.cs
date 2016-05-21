namespace SpecialValue
{
    using System;
    using System.Linq;
    using System.Numerics;

    public class SpecialValue
    {
        private static int[][] inputRows;
        private static int[,] field;
        private static bool[,] visited;
        
        public static void Main()
        {
            ReadInput();

            FillField();

            FindSpecialValue();
        }

        private static void ReadInput()
        {
            int n = int.Parse(Console.ReadLine());

            inputRows = new int[n][];

            for (int i = 0; i < n; i++)
            {
                int[] currentRow = Console.ReadLine()
                    .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                inputRows[i] = currentRow;
            }
        }

        private static void FillField()
        {
            int maxRowLength = inputRows.Max(s => s.Length);

            field = new int[inputRows.GetLength(0), maxRowLength];
            visited = new bool[inputRows.GetLength(0), maxRowLength];

            for (int row = 0; row < inputRows.GetLength(0); row++)
            {
                int[] currentRow = inputRows[row];

                for (int col = 0; col < currentRow.Length; col++)
                {
                    field[row, col] = currentRow[col];
                }
            }
        }

        private static void PrintField()
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write(field[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        private static void FindSpecialValue()
        {
            int firstRowLastIndex = inputRows[0].Length - 1;
            BigInteger bestSpecialValue = 0;

            for (int i = 0; i <= firstRowLastIndex; i++)
            {
                int row = 0;
                int col = i;
                BigInteger currentSpecialValue = 0;
                int passedCellsCount = 0;
                bool hasSpacialValue = true;

                while (true)
                {
                    int currentCellValue = field[row, col];
                    passedCellsCount++;

                    if (currentCellValue < 0)
                    {
                        currentSpecialValue += Math.Abs(currentCellValue);
                        visited[row, col] = true;
                        break;
                    }
                    else if (visited[row, col])
                    {
                        hasSpacialValue = false;
                        break;
                    }

                    visited[row, col] = true;
                    ++row;
                    col = currentCellValue;

                    if (row >= field.GetLength(0))
                    {
                        row = 0;
                    }
                }

                if (hasSpacialValue)
                {
                    currentSpecialValue += passedCellsCount;
                }
                else
                {
                    currentSpecialValue = 0;
                }

                if (currentSpecialValue > bestSpecialValue)
                {
                    bestSpecialValue = currentSpecialValue;
                }
            }

            Console.WriteLine(bestSpecialValue);
        }
    }
}