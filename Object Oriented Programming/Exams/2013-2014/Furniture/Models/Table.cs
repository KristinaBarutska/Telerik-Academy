namespace FurnitureManufacturer.Models
{
    using System.Text;

    using Common;
    using FurnitureManufacturer.Interfaces;
    
    internal class Table : Furniture, ITable
    {
        private const string TableLength = "Table length";
        private const string TableWidth = "Table width";
        private const string TableFormatString = "Length: {0}, Width: {1}, Area: {2}";

        private decimal length;
        private decimal width;

        internal Table(decimal height, string material, string model, decimal price, decimal length, decimal width)
            : base(height, material, model, price)
        {
            this.Length = length;
            this.Width = width;
        }

        public decimal Area
        {
            get
            {
                return this.Length * this.Width;
            }
        }

        public decimal Length
        {
            get
            {
                return this.length;
            }

            private set
            {
                Validator.ValidateIfDecimalIsPositive(value, TableLength);
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
                Validator.ValidateIfDecimalIsPositive(value, TableWidth);
                this.width = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder(base.ToString());

            result.Append(string.Format(TableFormatString, this.Length, this.Width, this.Area));
            return result.ToString();
        }
    }
}