namespace Cosmetics.Products
{
    using System.Collections.Generic;
    using System.Linq;

    using Common;
    using Contracts;

    public class ShoppingCart : IShoppingCart
    {
        private const string ProductString = "Product";

        private IList<IProduct> products;

        public ShoppingCart()
        {
            this.products = new List<IProduct>();
        }

        public void AddProduct(IProduct product)
        {
            Validator.CheckIfNull(product, string.Format(GlobalErrorMessages.ObjectCannotBeNull, ProductString));
            this.products.Add(product);
        }

        public bool ContainsProduct(IProduct product)
        {
            Validator.CheckIfNull(product, string.Format(GlobalErrorMessages.ObjectCannotBeNull, ProductString));
            return this.products.Contains(product);
        }

        public void RemoveProduct(IProduct product)
        {
            Validator.CheckIfNull(product, string.Format(GlobalErrorMessages.ObjectCannotBeNull, ProductString));
            this.products.Remove(product);
        }

        public decimal TotalPrice()
        {
            return this.products.Sum(p => p.Price);
        }
    }
}