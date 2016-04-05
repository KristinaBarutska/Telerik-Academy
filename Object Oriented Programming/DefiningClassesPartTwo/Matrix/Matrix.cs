namespace Matrix
{
    using System;

    public class Matrix<T>
    {
        private int width;
        private int height;
        private T[,] matrix;

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
                ValidateSize(value, "width");
                this.width = value;
            }
        }

        public int Height
        {
            get
            {
                return this.width;
            }
            private set
            {
                ValidateSize(value, "height");
                this.width = value;
            }
        }

        public static Matrix<T> operator +(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            ValidateMatrixSize(firstMatrix, secondMatrix);

            var newMatrix = new Matrix<T>(firstMatrix.width, secondMatrix.height);
            var width = firstMatrix.width;
            var height = secondMatrix.height;

            for (int row = 0; row < width; row++)
            {
                for (int col = 0; col < height; col++)
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
            ValidateMatrixSize(firstMatrix, secondMatrix);

            var newMatrix = new Matrix<T>(firstMatrix.width, secondMatrix.height);
            var width = firstMatrix.width;
            var height = secondMatrix.height;

            for (int row = 0; row < width; row++)
            {
                for (int col = 0; col < height; col++)
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
            ValidateMatrixSize(firstMatrix, secondMatrix);

            var newMatrix = new Matrix<T>(firstMatrix.width, secondMatrix.height);
            var width = firstMatrix.width;
            var height = secondMatrix.height;

            for (int row = 0; row < width; row++)
            {
                for (int col = 0; col < height; col++)
                {
                    dynamic firstMatrixValue = firstMatrix[row, col];
                    dynamic secondMatrixValue = secondMatrix[row, col];

                    newMatrix[row, col] = firstMatrixValue * secondMatrixValue;
                }
            }

            return newMatrix;
        }

        public static bool operator true(Matrix<T> matrix)
        {
            bool isNotZero = false;

            for (int row = 0; row < matrix.Height; row++)
            {
                for (int col = 0; col < matrix.Width; col++)
                {
                    dynamic currentCell = matrix[row, col];

                    if (currentCell != 0)
                    {
                        isNotZero = true;
                    }
                    else
                    {
                        isNotZero = false;
                        break;
                    }
                }
            }

            return isNotZero;
        }

        public static bool operator false(Matrix<T> matrix)
        {
            bool isZero = false;

            for (int row = 0; row < matrix.Height; row++)
            {
                for (int col = 0; col < matrix.Width; col++)
                {
                    dynamic currentCell = matrix[row, col];

                    if (currentCell == 0)
                    {
                        isZero = true;
                    }
                    else
                    {
                        isZero = false;
                        break;
                    }
                }
            }

            return isZero;
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

        private static void ValidateSize(int parameter, string nameOfParameter)
        {
            if (parameter < 0)
            {
                throw new ArgumentException("The value of " + nameOfParameter + " cannot be less than 0.");
            }
        }

        private static void ValidateMatrixSize(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if (firstMatrix.width != secondMatrix.width && firstMatrix.height != secondMatrix.height)
            {
                throw new ArgumentException("The matrices are not equal.");
            }
        }
    }
}