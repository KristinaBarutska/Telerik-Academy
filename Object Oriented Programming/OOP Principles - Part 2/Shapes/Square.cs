namespace Shapes
{
    public class Square : Shape
    {
        public Square(double side) 
            : base(side, side)
        {
        }

        public override double CalculateSurface()
        {
            double surface = this.Width * this.Height / 2;
            return surface;
        }
    }
}
