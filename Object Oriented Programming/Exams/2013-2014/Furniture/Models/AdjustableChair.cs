namespace FurnitureManufacturer.Models
{
    using Common;
    using FurnitureManufacturer.Interfaces;

    internal class AdjustableChair : Chair, IAdjustableChair
    {
        private const string AdjustableChairNewHeight = "Adjustable chair new height";

        internal AdjustableChair(decimal height, string material, string model, decimal price, int numberOfLegs)
            : base(height, material, model, price, numberOfLegs)
        {
        }

        public void SetHeight(decimal height)
        {
            Validator.ValidateIfDecimalIsPositive(height, AdjustableChairNewHeight);
            this.Height = height;
        }
    }
}
