namespace FurnitureManufacturer.Models
{
    using System.Text;

    using FurnitureManufacturer.Common;
    using FurnitureManufacturer.Interfaces;

    internal class Table : Furniture, IFurniture, ITable
    {
        private decimal length;
        private decimal width;
        private decimal area;

        internal Table(string model, string material, decimal price, decimal height, decimal length, decimal width)
            : base(model, material, price, height)
        {
            this.Length = length;
            this.Width = width;
        }

        public decimal Length
        {
            get
            {
                return this.length;
            }

            private set
            {
                string propertyName = "Table length";

                Validator.ValidateIfDecimalValueIsPositive(value, propertyName);
                this.length = value;
            }
        }

        public decimal Width
        {
            get
            {
                return this.width;
            }

            private set
            {
                string propertyName = "Table width";

                Validator.ValidateIfDecimalValueIsPositive(value, propertyName);
                this.width = value;
            }
        }

        public decimal Area
        {
            get
            {
                return this.Width * this.Length;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder(base.ToString());

            result.AppendLine(string.Format(", Length: {0}, Width: {1}, Area: {2}", this.Length, this.Width, this.Area));

            return result.ToString().Trim();
        }
    }
}