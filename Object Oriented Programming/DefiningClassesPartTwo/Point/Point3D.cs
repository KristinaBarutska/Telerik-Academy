namespace Point
{
    public struct Point3D
    {
        private static readonly Point3D StartPoint = new Point3D(0, 0, 0);
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Point3D(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public override string ToString()
        {
            return $"X: {this.X}; Y: {this.Y}; Z: {this.Z}";
        }
    }
}