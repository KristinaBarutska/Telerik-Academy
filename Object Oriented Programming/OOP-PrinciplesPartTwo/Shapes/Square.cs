namespace Shapes
{
    public class Square : Shape
    {
        public Square(double sideSize)
        {
            this.Width = sideSize;
            this.Height = sideSize;
        }

        public override double CalculateSurface()
        {
            double surface = this.Width * this.Height;
            return surface;
        }
    }
}
