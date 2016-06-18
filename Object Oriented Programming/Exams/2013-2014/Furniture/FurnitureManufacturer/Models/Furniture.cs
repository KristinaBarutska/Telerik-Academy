namespace FurnitureManufacturer.Models
{
    using System;
    using System.Text;

    using FurnitureManufacturer.Common;
    using FurnitureManufacturer.Interfaces;

    public class Furniture : IFurniture
    {
        private const int MinModelLength = 3;
        private const string ModelLengthErrorMessage = "Model length cannot be less than 3 characters!";

        private string model;
        private string material;
        private decimal price;
        private decimal height;

        protected Furniture(string model, string material, decimal price, decimal height)
        {
            this.Model = model;
            this.Material = material;
            this.Price = price;
            this.Height = height;
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            private set
            {
                string propertyName = this.GetType().Name + " model";

                Validator.ValidateIfStringIsNullOrEmpty(value, propertyName);
                this.ValidateModelLength(value);
                this.model = value;
            }
        }

        public string Material
        {
            get
            {
                return this.material;
            }

            private set
            {
                string propertyName = this.GetType().Name + " material";

                Validator.ValidateIfStringIsNullOrEmpty(value, propertyName);
                this.material = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                string propertyName = this.GetType().Name + " price";

                Validator.ValidateIfDecimalValueIsPositive(value, propertyName);
                this.price = value;
            }
        }

        public decimal Height
        {
            get
            {
                return this.height;
            }

            protected set
            {
                string propertyName = this.GetType().Name + " height";

                Validator.ValidateIfDecimalValueIsPositive(value, propertyName);
                this.height = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            string material = char.ToUpper(this.Material[0]) + this.Material.Substring(1);

            result.Append(string.Format("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}",
                this.GetType().Name, this.Model, material, this.Price, this.Height));

            return result.ToString();
        }

        private void ValidateModelLength(string model)
        {
            if (model.Length < Furniture.MinModelLength)
            {
                throw new ArgumentException(Furniture.ModelLengthErrorMessage);
            }
        }
    }
}