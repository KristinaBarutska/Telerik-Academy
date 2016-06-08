namespace Cosmetics.Products
{
    using System.Text;

    using Common;
    using Contracts;

    public class Shampoo : Product, IShampoo
    {
        public Shampoo(string brand, GenderType gender, string name, decimal price, uint milliliters, UsageType usage)
            : base(brand, gender, name, price * milliliters)
        {
            this.Milliliters = milliliters;
            this.Usage = usage;
        }

        public uint Milliliters
        {
            get; private set;
        }

        public UsageType Usage
        {
            get; private set;
        }

        public override string Print()
        {
            var result = new StringBuilder(base.Print());
            string usage = this.Usage == UsageType.EveryDay ? "EveryDay" : "Medical";

            result.AppendLine(string.Format("  * Quantity: {0} ml", this.Milliliters));
            result.AppendLine(string.Format("  * Usage: {0}", usage));

            return result.ToString().Trim();
        }
    }
}