namespace FurnitureManufacturer.Models
{
    using FurnitureManufacturer.Common;
    using FurnitureManufacturer.Interfaces;

    internal class AdjustableChair : Chair, IFurniture, IChair, IAdjustableChair
    {
        public AdjustableChair(string model, string material, decimal price, decimal height, int numberOfLegs)
            : base(model, material, price, height, numberOfLegs)
        {
        }

        public void SetHeight(decimal height)
        {
            Validator.ValidateIfDecimalValueIsPositive(height, "Adjusted height");
            this.Height = height;
        }
    }
}