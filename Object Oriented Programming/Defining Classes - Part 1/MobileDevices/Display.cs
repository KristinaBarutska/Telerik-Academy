namespace MobileDevices
{
    using System;
    using System.Text;

    public class Display
    {
        private double size;
        private int numberOfColors;

        public Display(double size)
        {
            this.size = size;
        }

        public Display(double size, int numberOfColors)
            : this(size)
        {
            this.numberOfColors = numberOfColors;
        }

        public double Size
        {
            get
            {
                return this.size;
            }

            private set
            {
                ValueValidator.ValidateDoubleValue(value, "Display size");
                this.size = value;
            }
        }

        public int NumberOfColors
        {
            get
            {
                return this.numberOfColors;
            }

            private set
            {
                ValueValidator.ValidateIntegerValue(value, "Number of colors");
                this.numberOfColors = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            if (this.numberOfColors == 0)
            {
                result.AppendLine(string.Format("Display size: {0}", this.size));
            }
            else
            {
                result.AppendLine(string.Format("Display size: {0}{1}Number of colors: {2}", this.size, Environment.NewLine, this.numberOfColors));
            }

            return result.ToString();
        }
    }
}