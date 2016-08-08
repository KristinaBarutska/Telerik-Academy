namespace Cosmetics.Tests.Products
{
    using NUnit.Framework;
    using Moq;
    using Contracts;
    using Mocks;

    [TestFixture]
    public class ShoppingCartTests
    {
        [Test]
        public void AddProduct_ShouldAddTheProductToTheProductsList()
        {
            var cart = new MockedShoppingCart();
            var shampoo = new Mock<IShampoo>();

            cart.AddProduct(shampoo.Object);
            Assert.AreEqual(1, cart.Products.Count);
        }

        [Test]
        public void RemoveProduct_ShouldRemoveTheProductFromTheProductsList()
        {
            var cart = new MockedShoppingCart();
            var shampoo = new Mock<IShampoo>();

            cart.AddProduct(shampoo.Object);
            cart.RemoveProduct(shampoo.Object);

            Assert.AreEqual(0, cart.Products.Count);
        }

        [Test]
        public void ContainsProduct_ShouldReturnTrueForProductThatExistsInTheProductsList()
        {
            var cart = new MockedShoppingCart();
            var shampoo = new Mock<IShampoo>();

            cart.AddProduct(shampoo.Object);
            Assert.IsTrue(cart.ContainsProduct(shampoo.Object));
        }

        [Test]
        public void ContainsProduct_ShouldReturnFalseForProductThatExistsInTheProductsList()
        {
            var cart = new MockedShoppingCart();
            var shampoo = new Mock<IShampoo>();

            Assert.IsFalse(cart.ContainsProduct(shampoo.Object));
        }

        [Test]
        public void TotalPrice_ShouldReturnTheSumOfPricesOfAllProducts()
        {
            var firstProduct = new Mock<IProduct>();
            var secondProduct = new Mock<IProduct>();
            var cart = new MockedShoppingCart();

            firstProduct.Setup(p => p.Price).Returns(53m);
            secondProduct.Setup(p => p.Price).Returns(27m);
            cart.AddProduct(firstProduct.Object);
            cart.AddProduct(secondProduct.Object);

            Assert.AreEqual(80m, cart.TotalPrice());
        }
    }
}