namespace Cosmetics.Products
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Cosmetics.Contracts;
    using Cosmetics.Common;

    internal class Category : ICategory
    {
        private const string CategoryName = "Category name";
        private const string Cosmetics = "Cosmetics";
        private const string CosmeticsNotFound = "Product {0} does not exist in category {1}!";
        private const int MinCategoryNameLength = 2;
        private const int MaxCategoryNameLength = 15;

        private string name;
        private ICollection<IProduct> cosmetics;

        internal Category(string name)
        {
            this.Name = name;
            this.cosmetics = new List<IProduct>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                Validator.CheckIfStringIsNullOrEmpty(value,
                    string.Format(GlobalErrorMessages.StringCannotBeNullOrEmpty, CategoryName));
                Validator.CheckIfStringLengthIsValid(value, MaxCategoryNameLength, MinCategoryNameLength,
                    string.Format(GlobalErrorMessages.InvalidStringLength, CategoryName, MinCategoryNameLength, MaxCategoryNameLength));
                this.name = value;
            }
        }

        public void AddCosmetics(IProduct cosmetics)
        {
            Validator.CheckIfNull(cosmetics, string.Format(GlobalErrorMessages.ObjectCannotBeNull, Cosmetics));
            this.cosmetics.Add(cosmetics);
        }

        public string Print()
        {
            this.cosmetics = this.cosmetics
                .OrderBy(p => p.Name)
                .ThenByDescending(p => p.Price)
                .ToList();

            var result = new StringBuilder();
            string productsCountString = this.cosmetics.Count == 1 ? "product" : "products";

            result.Append(string.Format("{0} category – {1} {2} in total",
                this.Name, this.cosmetics.Count, productsCountString));

            foreach (var product in cosmetics)
            {
                result.Append(product.Print());
            }

            return result.ToString().Trim();
        }

        public void RemoveCosmetics(IProduct cosmetics)
        {
            bool hasCosmetics = this.cosmetics.Remove(cosmetics);

            if (!hasCosmetics)
            {
                throw new ArgumentException(string.Format(CosmeticsNotFound, cosmetics.Name, this.Name));
            }
        }
    }
}