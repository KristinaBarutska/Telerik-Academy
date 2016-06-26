namespace Cosmetics.Products
{
    using System.Collections.Generic;
    using System.Linq;

    using Cosmetics.Contracts;
    using Cosmetics.Common;


    internal class ShoppingCart : IShoppingCart
    {
        private const string Product = "Product";

        private ICollection<IProduct> products;

        internal ShoppingCart()
        {
            this.products = new List<IProduct>();
        }

        public void AddProduct(IProduct product)
        {
            Validator.CheckIfNull(product, string.Format(GlobalErrorMessages.ObjectCannotBeNull, Product));
            this.products.Add(product);
        }

        public bool ContainsProduct(IProduct product)
        {
            Validator.CheckIfNull(product, string.Format(GlobalErrorMessages.ObjectCannotBeNull, Product));
            return this.products.Contains(product);
        }

        public void RemoveProduct(IProduct product)
        {
            this.products.Remove(product);
        }

        public decimal TotalPrice()
        {
            return this.products.Sum(p => p.Price);
        }
    }
}