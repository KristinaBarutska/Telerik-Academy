using System;
using FurnitureManufacturer.Interfaces;
using System.Text;

namespace FurnitureManufacturer.Models
{
    internal class ConvertibleChair : Chair, IConvertibleChair
    {
        private const string ConvertedState = "Converted";
        private const string NormalState = "Normal";
        private const string StateFormatString = ", State: {0}";
        private const decimal HeightInConvertedMode = 0.1m;
        private readonly decimal NormalHeight;

        internal ConvertibleChair(decimal height, string material, string model, decimal price, int numberOfLegs)
            : base(height, material, model, price, numberOfLegs)
        {
            this.NormalHeight = height;
        }

        public bool IsConverted
        {
            get; private set;
        }

        public void Convert()
        {
            if (!this.IsConverted)
            {
                this.IsConverted = true;
                this.Height = HeightInConvertedMode;
            }
            else
            {
                this.IsConverted = false;
                this.Height = NormalHeight;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder(base.ToString().Trim());
            string chairState = this.IsConverted ? ConvertedState : NormalState;

            result.Append(string.Format(StateFormatString, chairState));
            return result.ToString();
        }
    }
}