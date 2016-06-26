namespace Cosmetics.Products
{
    using System;
    using System.Text;

    using Common;
    using Contracts;

    internal abstract class Product : IProduct
    {
        private const string ProductBrand = "Product brand";
        private const string ProductGender = "Product gender";
        private const string ProductName = "Product name";
        private const string PriceMustBePositiveNumber = "Product price must be positive number!";
        private const int MinBrandNameLength = 2;
        private const int MaxBrandNameLength = 10;
        private const int MinProductNameLength = 3;
        private const int MaxProductNameLength = 10;

        private string brand;
        private GenderType gender;
        private string name;
        private decimal price;

        internal Product(string brand, GenderType gender, string name, decimal price)
        {
            this.Brand = brand;
            this.Gender = gender;
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
            get
            {
                return this.gender;
            }

            private set
            {
                Validator.CheckIfNull(value, string.Format(GlobalErrorMessages.ObjectCannotBeNull, Gender));
                this.gender = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                Validator.CheckIfStringIsNullOrEmpty(value, string.Format(GlobalErrorMessages.StringCannotBeNullOrEmpty, ProductName));
                Validator.CheckIfStringLengthIsValid(value, MaxProductNameLength, MinProductNameLength,
                    string.Format(GlobalErrorMessages.InvalidStringLength, ProductName, MinProductNameLength, MaxProductNameLength));
                this.name = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(PriceMustBePositiveNumber);
                }

                this.price = value;
            }
        }

        public virtual string Print()
        {
            var result = new StringBuilder();

            result.AppendLine(string.Format("- {0} - {1}:", this.Brand, this.Name));
            result.AppendLine(string.Format("  * Price: ${0}", this.Price));
            result.AppendLine(string.Format("  * For gender: {0}", this.Gender));

            return result.ToString();
        }
    }
}