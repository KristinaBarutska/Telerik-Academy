namespace Matrix
{
    using System.Text;

    public class Matrix<T>
    {
        private T[,] container;

        public Matrix(int rows, int cols)
        {
            this.NumberOfRows = rows;
            this.NumberOfCols = cols;
            this.container = new T[rows, cols];
        }

        public int NumberOfRows
        {
            get;
            private set;
        }

        public int NumberOfCols
        {
            get;
            private set;
        }

        public T this[int row, int col]
        {
            get
            {
                return this.container[row, col];
            }

            set
            {
                this.container[row, col] = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            int largestValueLength = this.GetLargestValueLength();

            for (int row = 0; row < this.NumberOfRows; row++)
            {
                for (int col = 0; col < this.NumberOfCols; col++)
                {
                    result.Append(this.container[row, col].ToString().PadLeft(largestValueLength, ' ') + " ");
                }

                result.AppendLine();
            }

            return result.ToString().Trim();
        }

        private int GetLargestValueLength()
        {
            int largestValueLength = this.container[0, 0].ToString().Length;

            for (int row = 0; row < this.NumberOfRows; row++)
            {
                for (int col = 0; col < this.NumberOfCols; col++)
                {
                    int currentValueLength = this.container[row, col].ToString().Length;

                    if (currentValueLength > largestValueLength)
                    {
                        largestValueLength = currentValueLength;
                    }
                }
            }

            return largestValueLength;
        }
    }
}