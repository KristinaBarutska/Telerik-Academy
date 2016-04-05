namespace Matrix
{
    using System;

    public class Matrix<T>
    {
        private T[,] matrix;
        private int width;
        private int height;

        public Matrix(int width, int height)
        {
            this.width = width;
            this.height = height;
            this.matrix = new T[width, height];
        }

        public int Width
        {
            get
            {
                return this.width;
            }

            private set
            {
                CheckValue(value);
                this.width = value;
            }
        }

        public int Height
        {
            get
            {
                return this.height;
            }

            private set
            {
                CheckValue(value);
                this.width = value;
            }
        }

        public string Size
        {
            get
            {
                return $"{this.width}x{this.height}";
            }
        }

        public T this[int row, int col]
        {
            get
            {
                return this.matrix[row, col];
            }

            set
            {
                this.matrix[row, col] = value;
            }
        }

        public static Matrix<T> operator +(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            CheckEquality(firstMatrix, secondMatrix);

            var newMatrix = new Matrix<T>(firstMatrix.Width, firstMatrix.Height);

            for (int row = 0; row < firstMatrix.Width; row++)
            {
                for (int col = 0; col < firstMatrix.Height; col++)
                {
                    dynamic firstMatrixValue = firstMatrix[row, col];
                    dynamic secondMatrixValue = secondMatrix[row, col];

                    newMatrix[row, col] = firstMatrixValue + secondMatrixValue;
                }
            }

            return newMatrix;
        }

        public static Matrix<T> operator -(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            CheckEquality(firstMatrix, secondMatrix);

            var newMatrix = new Matrix<T>(firstMatrix.Width, firstMatrix.Height);

            for (int row = 0; row < firstMatrix.Width; row++)
            {
                for (int col = 0; col < firstMatrix.Height; col++)
                {
                    dynamic firstMatrixValue = firstMatrix[row, col];
                    dynamic secondMatrixValue = secondMatrix[row, col];

                    newMatrix[row, col] = firstMatrixValue - secondMatrixValue;
                }
            }

            return newMatrix;
        }

        public static Matrix<T> operator *(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            CheckEquality(firstMatrix, secondMatrix);

            var newMatrix = new Matrix<T>(firstMatrix.Width, firstMatrix.Height);

            for (int row = 0; row < firstMatrix.Width; row++)
            {
                for (int col = 0; col < firstMatrix.Height; col++)
                {
                    dynamic firstMatrixValue = firstMatrix[row, col];
                    dynamic secondMatrixValue = secondMatrix[row, col];

                    newMatrix[row, col] = firstMatrixValue * secondMatrixValue;
                }
            }

            return newMatrix;
        }

        public override string ToString()
        {
            string matrixAsString = string.Empty;

            for (int row = 0; row < this.matrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.matrix.GetLength(1); col++)
                {
                    matrixAsString += $"{this.matrix[row, col],5}";
                }

                matrixAsString += "\n";
            }

            return matrixAsString;
        }

        private static void CheckValue(int value)
        {
            if (value <= 0)
            {
                throw new ArgumentException("The value cannot be equal to or less than 0.");
            }
        }

        private static void CheckEquality(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if (firstMatrix.Width != secondMatrix.Width || firstMatrix.Height != secondMatrix.Height)
            {
                throw new ArgumentException("The matrices are not equal.");
            }
        }
    }
}