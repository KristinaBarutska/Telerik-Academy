namespace Matrix
{
    using System;

    public class Version : Attribute
    {
        public Version(int major, int minor)
        {
            this.Major = major;
            this.Minor = minor;
        }

        public int Major
        {
            get;
            private set;
        }

        public int Minor
        {
            get;
            private set;
        }

        public override string ToString()
        {
            return string.Format("v{0}.{1}", this.Major, this.Minor);
        }
    }
}