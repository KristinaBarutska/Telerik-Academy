namespace Shapes
{
    public abstract class Shape
    {
        public Shape(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width
        {
            get;
            private set;
        }

        public double Height
        {
            get;
            private set;
        }

        public abstract double CalculateSurface();

        public override string ToString()
        {
            return string.Format("Width: {0} Height: {1}", this.Width, this.Height);
        }
    }
}