namespace Point
{
    public struct Point
    {
        private static readonly Point Start = new Point(0, 0, 0);

        public Point(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public double X
        {
            get;
            private set;
        }

        public double Y
        {
            get;
            private set;
        }

        public double Z
        {
            get;
            private set;
        }

        public Point O
        {
            get
            {
                return Start;
            }
        }
        
        public override string ToString()
        {
            return string.Format("X: {0}, Y: {1}, Z: {2}", this.X, this.Y, this.Z);
        }
    }
}