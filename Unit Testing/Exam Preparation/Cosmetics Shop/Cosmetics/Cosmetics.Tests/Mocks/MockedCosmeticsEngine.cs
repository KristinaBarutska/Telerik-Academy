namespace Cosmetics.Tests.Mocks
{
    using Cosmetics.Contracts;
    using Cosmetics.Engine;
    using System.Collections.Generic;

    internal class MockedCosmeticsEngine : CosmeticsEngine
    {
        public MockedCosmeticsEngine(ICosmeticsFactory factory, IShoppingCart shoppingCart, ICommandParser commandParser)
            : base(factory, shoppingCart, commandParser)
        {
        }

        public IDictionary<string, ICategory> Categories
        {
            get
            {
                return base.categories;
            }
        }

        public IDictionary<string, IProduct> Products
        {
            get
            {
                return base.products;
            }
        }
    }
}