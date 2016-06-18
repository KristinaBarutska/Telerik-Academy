namespace FurnitureManufacturer.Models
{
    using System.Text;

    using FurnitureManufacturer.Common;
    using FurnitureManufacturer.Interfaces;

    public class Chair : Furniture, IFurniture, IChair
    {
        private int numberOfLegs;

        public Chair(string model, string material, decimal price, decimal height, int numberOfLegs)
            : base(model, material, price, height)
        {
            this.NumberOfLegs = numberOfLegs;
        }

        public int NumberOfLegs
        {
            get
            {
                return this.numberOfLegs;
            }

            private set
            {
                string propertyName = "Number of legs";

                Validator.ValidateIfIntegerValuesIsPositive(value, propertyName);
                this.numberOfLegs = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder(base.ToString());

            result.Append(string.Format(", Legs: {0}", this.NumberOfLegs));

            return result.ToString();
        }
    }
}