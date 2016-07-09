namespace FurnitureManufacturer.Models
{
    using System.Text;

    using Common;
    using FurnitureManufacturer.Interfaces;
    
    internal class Chair : Furniture, IChair
    {
        private const string ChairNumberOfLegs = "{0} number of legs";
        private const string LegsFormatString = "Legs: {0}";

        private int numberOfLegs;

        internal Chair(decimal height, string material, string model, decimal price, int numberOfLegs)
            : base(height, material, model, price)
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
                Validator.ValidateIfDecimalIsPositive(value, string.Format(ChairNumberOfLegs, this.GetType().Name));
                this.numberOfLegs = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder(base.ToString());

            result.Append(string.Format(LegsFormatString, this.NumberOfLegs));
            return result.ToString();
        }
    }
}