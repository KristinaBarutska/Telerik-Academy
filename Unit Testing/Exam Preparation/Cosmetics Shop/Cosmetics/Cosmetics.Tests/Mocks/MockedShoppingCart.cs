namespace Cosmetics.Tests.Mocks
{
    using Contracts;
    using Cosmetics.Products;
    using System.Collections.Generic;

    internal class MockedShoppingCart : ShoppingCart
    {
        public IList<IProduct> Products
        {
            get
            {
                return base.products;
            }
        }
    }
}