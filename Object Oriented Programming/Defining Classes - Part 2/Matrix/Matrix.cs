namespace Matrix
{
    using System;
    using System.Text;

    [Version(1, 12)]
    public class Matrix<T>
        where T : IComparable
    {
        private T[,] container;

        public Matrix(int rows, int cols)
        {
            this.container = new T[rows, cols];
        }

        public int Rows
        {
            get
            {
                return this.container.GetLength(0);
            }
        }

        public int Cols
        {
            get
            {
                return this.container.GetLength(1);
            }
        }

        public T this[int row, int col]
        {
            get
            {
                this.ValidateIndexes(row, col);
                return this.container[row, col];
            }

            set
            {
                this.ValidateIndexes(row, col);
                this.container[row, col] = value;
            }
        }

        public static Matrix<T> operator +(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            ValidateMatricesSizes(firstMatrix, secondMatrix);

            Matrix<T> resultMatrix = new Matrix<T>(firstMatrix.Rows, firstMatrix.Cols);

            for (int row = 0; row < firstMatrix.Rows; row++)
            {
                for (int col = 0; col < firstMatrix.Cols; col++)
                {
                    resultMatrix[row, col] = (dynamic)firstMatrix[row, col] + secondMatrix[row, col];
                }
            }

            return resultMatrix;
        }

        public static Matrix<T> operator -(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            ValidateMatricesSizes(firstMatrix, secondMatrix);

            Matrix<T> resultMatrix = new Matrix<T>(firstMatrix.Rows, firstMatrix.Cols);

            for (int row = 0; row < firstMatrix.Rows; row++)
            {
                for (int col = 0; col < firstMatrix.Cols; col++)
                {
                    resultMatrix[row, col] = (dynamic)firstMatrix[row, col] - secondMatrix[row, col];
                }
            }

            return resultMatrix;
        }

        public static Matrix<T> operator *(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            ValidateMatricesSizes(firstMatrix, secondMatrix);

            Matrix<T> resultMatrix = new Matrix<T>(firstMatrix.Rows, firstMatrix.Cols);

            for (int row = 0; row < firstMatrix.Rows; row++)
            {
                for (int col = 0; col < firstMatrix.Cols; col++)
                {
                    resultMatrix[row, col] = (dynamic)firstMatrix[row, col] * secondMatrix[row, col];
                }
            }

            return resultMatrix;
        }

        public static bool operator true(Matrix<T> matrix)
        {
            return CheckForNonZeroElements(matrix);
        }

        public static bool operator false(Matrix<T> matrix)
        {
            return CheckForNonZeroElements(matrix);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            int longestElementLength = this.GetBiggestElement().ToString().Length;

            for (int row = 0; row < this.Rows; row++)
            {
                for (int col = 0; col < this.Cols; col++)
                {
                    string currentElement = this.container[row, col].ToString().PadLeft(longestElementLength, ' ');
                    result.Append(currentElement + " ");
                }

                result.AppendLine();
            }

            return result.ToString().TrimEnd();
        }

        private static void ValidateMatricesSizes(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if (firstMatrix.Rows != secondMatrix.Rows || firstMatrix.Cols != secondMatrix.Cols)
            {
                throw new ArgumentException("Matrices must have equal number of rows and cols!");
            }
        }

        private static bool CheckForNonZeroElements(Matrix<T> matrix)
        {
            for (int row = 0; row < matrix.Rows; row++)
            {
                for (int col = 0; col < matrix.Cols; col++)
                {
                    if (matrix[row, col] == (dynamic)0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private void ValidateIndexes(int row, int col)
        {
            if (row < 0 || row >= this.container.GetLength(0) || col < 0 || col >= this.container.GetLength(1))
            {
                throw new IndexOutOfRangeException("Invalid index!");
            }
        }

        private T GetBiggestElement()
        {
            T biggestElement = this.container[0, 0];

            for (int row = 0; row < this.Rows; row++)
            {
                for (int col = 0; col < this.Cols; col++)
                {
                    if (biggestElement.CompareTo(this.container[row, col]) < 0)
                    {
                        biggestElement = this.container[row, col];
                    }
                }
            }

            return biggestElement;
        }
    }
}