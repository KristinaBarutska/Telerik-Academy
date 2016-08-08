namespace Cosmetics.Tests.Products
{
    using System;

    using Moq;
    using NUnit.Framework;
    using Mocks;
    using Contracts;

    [TestFixture]
    public class CategoryTests
    {
        [Test]
        public void AddProduct_ShouldAddTheProductToTheProductsList()
        {
            var category = new MockedCategory("Category");
            var product = new Mock<IProduct>();

            category.AddProduct(product.Object);
            Assert.AreEqual(1, category.Products.Count);
        }

        [Test]
        public void RemoveProduct_ShouldRemoveTheProductFromTheProductsLists()
        {
            var category = new MockedCategory("Category");
            var product = new Mock<IProduct>();

            category.AddProduct(product.Object);
            category.RemoveProduct(product.Object);

            Assert.AreEqual(0, category.Products.Count);
        }
    }
}