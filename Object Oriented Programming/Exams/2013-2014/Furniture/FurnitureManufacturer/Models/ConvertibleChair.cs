namespace FurnitureManufacturer.Models
{
    using System.Text;

    using FurnitureManufacturer.Interfaces;

    internal class ConvertibleChair : Chair, IFurniture, IChair, IConvertibleChair
    {
        private const decimal ConvertedStateHeight = 0.1m;

        private readonly decimal NormalHeight;

        public ConvertibleChair(string model, string material, decimal price, decimal height, int numberOfLegs)
            : base(model, material, price, height, numberOfLegs)
        {
            this.NormalHeight = height;
        }

        public bool IsConverted { get; private set; }

        public void Convert()
        {
            if (!this.IsConverted)
            {
                this.IsConverted = true;
                this.Height = ConvertibleChair.ConvertedStateHeight;
            }
            else
            {
                this.IsConverted = false;
                this.Height = this.NormalHeight;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder(base.ToString());

            result.Append(string.Format(", State: {0}", this.IsConverted ? "Converted" : "Normal"));

            return result.ToString().Trim();
        }
    }
}