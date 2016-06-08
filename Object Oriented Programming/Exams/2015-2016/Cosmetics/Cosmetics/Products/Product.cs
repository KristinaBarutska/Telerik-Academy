namespace Cosmetics.Products
{
    using System;
    using System.Text;

    using Contracts;
    using Common;

    public abstract class Product : IProduct
    {
        private const int MinProductNameLength = 3;
        private const int MaxProductNameLength = 10;
        private const int MinBrandNameLength = 2;
        private const int MaxBrandNameLength = 10;
        private const string ProductName = "Product name";
        private const string ProductBrand = "Product brand";
        private const string InvalidPriceMessage = "Price must bepositive number!";

        private string brand;
        private string name;
        private decimal price;

        public Product(string brand, GenderType gender, string name, decimal price)
        {
            this.Brand = brand;
            this.Name = name;
            this.Price = price;
        }

        public string Brand
        {
            get
            {
                return this.brand;
            }

            private set
            {
                Validator.CheckIfStringLengthIsValid(value, MaxBrandNameLength, MinBrandNameLength,
                    string.Format(GlobalErrorMessages.InvalidStringLength, ProductBrand, MinBrandNameLength, MaxBrandNameLength));
                Validator.CheckIfStringIsNullOrEmpty(value, string.Format(GlobalErrorMessages.StringCannotBeNullOrEmpty, ProductBrand));
                this.brand = value;
            }
        }

        public GenderType Gender
        {
            get; private set;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                Validator.CheckIfStringLengthIsValid(value, MaxProductNameLength, MinProductNameLength,
                    string.Format(GlobalErrorMessages.InvalidStringLength, ProductName, MinProductNameLength, MaxProductNameLength));
                Validator.CheckIfStringIsNullOrEmpty(value, string.Format(GlobalErrorMessages.StringCannotBeNullOrEmpty, ProductName));
                this.name = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(InvalidPriceMessage);
                }
                else
                {
                    this.price = value;
                }
            }
        }

        public virtual string Print()
        {
            var result = new StringBuilder();
            string gender = string.Empty;

            switch (this.Gender)
            {
                case GenderType.Men: gender = "Men"; break;
                case GenderType.Women: gender = "Women"; break;
                case GenderType.Unisex: gender = "Unisex"; break;
            }

            result.AppendLine(string.Format("- {0} - {1}:", this.Brand, this.Name));
            result.AppendLine(string.Format("  * Price: ${0}", this.Price));
            result.AppendLine(string.Format("  * For gender: {0}", gender));

            return result.ToString();
        }
    }
}