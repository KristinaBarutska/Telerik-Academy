namespace FurnitureManufacturer.Models
{
    using System.Text;

    using Common;
    using FurnitureManufacturer.Interfaces;

    internal class Furniture : IFurniture
    {
        private const int ModelMinLength = 3;
        private const string FurnitureHeight = "{0} height";
        private const string FurnitureMaterial = "{0} material";
        private const string FurnitureModel = "{0} model";
        private const string FurniturePrice = "{0} price";
        private const string FurnitureInfoFormatString = "Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, ";

        private decimal height;
        private string material;
        private string model;
        private decimal price;

        internal Furniture(decimal height, string material, string model, decimal price)
        {
            this.Height = height;
            this.Material = material;
            this.Model = model;
            this.Price = price;
        }

        public decimal Height
        {
            get
            {
                return this.height;
            }

            protected set
            {
                Validator.ValidateIfDecimalIsPositive(value, string.Format(FurnitureHeight, this.GetType().Name));
                this.height = value;
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
                Validator.ValidateIfStringIsNotNullOrEmpty(value, string.Format(FurnitureMaterial, this.GetType().Name));
                this.material = value;
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            private set
            {
                Validator.ValidateIfStringIsNotNullOrEmpty(value, string.Format(FurnitureModel, this.GetType().Name));
                Validator.ValidateStringMinLength(value, ModelMinLength, string.Format(FurnitureModel, this.GetType().Name));
                this.model = value;
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
                Validator.ValidateIfDecimalIsPositive(value, string.Format(FurniturePrice, this.GetType().Name));
                this.price = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            int typeStartIndex = this.GetType().Name.LastIndexOf('.') + 1;
            string typeString = this.GetType().Name.Substring(typeStartIndex);

            result.Append(string.Format(FurnitureInfoFormatString, typeString, this.Model, this.Material, this.Price, this.Height));
            return result.ToString();
        }
    }
}