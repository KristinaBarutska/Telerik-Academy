namespace Cosmetics.Products
{
    using System;
    using System.Text;

    using Cosmetics.Common;
    using Cosmetics.Contracts;

    internal class Shampoo : Product, IShampoo
    {
        private const string NotPositiveMilliters = "Milliliters should be have a positive value!";
        private const string ShampooUsage = "Shampoo usage";
        private uint milliliters;
        private UsageType usage;

        internal Shampoo(string brand, GenderType gender, string name, decimal price, uint milliliters, UsageType usage)
            : base(brand, gender, name, price)
        {
            this.Price = price * milliliters;
            this.Milliliters = milliliters;
            this.Usage = usage;
        }

        public uint Milliliters
        {
            get
            {
                return this.milliliters;
            }

            private set
            {
                if (this.milliliters <= 0)
                {
                    throw new ArgumentException(NotPositiveMilliters);
                }

                this.milliliters = value;
            }
        }

        public UsageType Usage
        {
            get
            {
                return this.usage;
            }

            private set
            {
                Validator.CheckIfNull(value, string.Format(GlobalErrorMessages.ObjectCannotBeNull, ShampooUsage));
                this.usage = value;
            }
        }

        public override string Print()
        {
            var result = new StringBuilder(base.Print());

            result.AppendLine(string.Format("  * Quantity: {0} ml", this.Milliliters));
            result.AppendLine(string.Format("  * Usage: EveryDay/Medical", this.Usage));

            return result.ToString();
        }
    }
}
