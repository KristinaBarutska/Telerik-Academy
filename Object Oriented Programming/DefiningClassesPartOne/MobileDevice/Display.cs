namespace MobileDevice
{
    public class Display
    {
        private double size;
        private int numberOfColors;

        public Display(double size, int numberOfColors = 0)
        {
            this.size = size;
            this.numberOfColors = numberOfColors;
        }

        public double Size
        {
            get
            {
                return this.size;
            }

            set
            {
                ValueValidator.ValidateNumber(value, "Display Size");
                this.size = value;
            }
        }

        public int NumberOfColors
        {
            get
            {
                return this.numberOfColors;
            }

            set
            {
                ValueValidator.ValidateNumber(value, "Number of colors");
                this.numberOfColors = value;
            }
        }

        public override string ToString()
        {
            if (this.numberOfColors != 0)
            {
                return $"Display : Size {this.size}, Number of colors : {this.numberOfColors}";
            }
            else
            {
                return $"Display : Size {this.size}";
            }
        }
    }
}