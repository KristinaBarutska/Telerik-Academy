namespace Cosmetics.Products
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;

    using Common;
    using Contracts;

    public class Category : ICategory
    {
        private const int MinCategoryNameLength = 2;
        private const int MaxCategoryNameLength = 15;
        private const string CategoryName = "Category name";
        private const string NullProductMessage = "Product cannot be null!";
        private const string ProductNotFoundMessage = "Product {0} does not exist in category {1}!";

        private string name;
        private IList<IProduct> products;

        public Category(string name)
        {
            this.Name = name;
            this.products = new List<IProduct>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                Validator.CheckIfStringLengthIsValid(value, MaxCategoryNameLength, MinCategoryNameLength,
                    string.Format(GlobalErrorMessages.InvalidStringLength, CategoryName, MinCategoryNameLength, MaxCategoryNameLength));
                Validator.CheckIfStringIsNullOrEmpty(value, string.Format(GlobalErrorMessages.StringCannotBeNullOrEmpty, CategoryName));
                this.name = value;
            }
        }

        public void AddCosmetics(IProduct cosmetics)
        {
            Validator.CheckIfNull(cosmetics, NullProductMessage);
            this.products.Add(cosmetics);
        }

        public string Print()
        {
            var result = new StringBuilder();
            string productsString = this.products.Count == 1 ? "product" : "products";

            this.products = this.products
                .OrderBy(p => p.Brand)
                .ThenByDescending(p => p.Price)
                .ToList();
            result.AppendLine(string.Format("{0} category - {1} {2} in total", this.Name, this.products.Count, productsString));

            foreach (var product in this.products)
            {
                result.AppendLine(product.Print());
            }

            return result.ToString().Trim();
        }

        public void RemoveCosmetics(IProduct cosmetics)
        {
            if (!this.products.Remove(cosmetics))
            {
                throw new InvalidOperationException(string.Format(ProductNotFoundMessage, cosmetics.Name, this.Name));
            }
        }
    }
}