namespace Cosmetics.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.IO;

    using Moq;
    using NUnit.Framework;
    using Mocks;
    using Contracts;
    using Products;
    using Common;

    [TestFixture]
    public class CosmeticsEngineTests
    {
        private Mock<ICosmeticsFactory> mockedFactory = new Mock<ICosmeticsFactory>();
        private Mock<IShoppingCart> mockedShoppingCart = new Mock<IShoppingCart>();
        private IList<IProduct> shoppingCartProducts;

        [OneTimeSetUp]
        public void SetupMockedObjects()
        {
            this.shoppingCartProducts = new List<IProduct>();

            mockedFactory.Setup(f => f.CreateCategory(It.IsAny<string>())).Returns<string>(name => new Category(name));
            mockedFactory
                .Setup(f => f.CreateToothpaste(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<decimal>(), It.IsAny<GenderType>(), It.IsAny<IList<string>>()))
                .Returns((string name, string brand, decimal price, GenderType gender, IList<string> ingredients) =>
                {
                    return new Toothpaste(name, brand, price, gender, ingredients);
                });
            mockedFactory
                .Setup(f => f.CreateShampoo(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<decimal>(), It.IsAny<GenderType>(), It.IsAny<uint>(), It.IsAny<UsageType>()))
                .Returns((string name, string brand, decimal price, GenderType gender, uint milliliters, UsageType usage) =>
                {
                    return new Shampoo(name, brand, price, gender, milliliters, usage);
                });

            mockedShoppingCart
                .Setup(s => s.AddProduct(It.IsAny<IProduct>()))
                .Callback<IProduct>(p => this.shoppingCartProducts.Add(p));
            mockedShoppingCart
                .Setup(s => s.RemoveProduct(It.IsAny<IProduct>()))
                .Callback<IProduct>(p => this.shoppingCartProducts.Remove(p));
        }

        [Test]
        public void Start_InvalidCommandFormat_ShouldThrowArgumentNullException()
        {
            MockedCosmeticsEngine engine = new MockedCosmeticsEngine(mockedFactory.Object, mockedShoppingCart.Object);

            Console.SetIn(new StringReader("          "));
            Assert.Throws<ArgumentNullException>(() => engine.Start());
        }

        [Test]
        public void Start_CreateCategory_ShouldAddTheCategoryToTheCategoryList()
        {
            MockedCosmeticsEngine engine = new MockedCosmeticsEngine(mockedFactory.Object, mockedShoppingCart.Object);

            Console.SetIn(new StringReader("CreateCategory ForMale"));
            engine.Start();
            Assert.AreEqual(1, engine.Categories.Count);
        }

        [Test]
        public void Start_AddToCategory_ShouldAddItemToTheCategory()
        {
            MockedCosmeticsEngine engine = new MockedCosmeticsEngine(mockedFactory.Object, mockedShoppingCart.Object);

            Console.SetIn(new StringReader("CreateCategory ForMale" + Environment.NewLine +
                "CreateToothpaste White+ Colgate 15.50 men fluor,bqla,golqma" +
                Environment.NewLine + "AddToCategory ForMale White+"));
            engine.Start();

            string printedCategory = engine.Categories["ForMale"].Print();

            Assert.IsTrue(printedCategory.IndexOf("White+") != -1);
        }

        [Test]
        public void Start_RemoveFromCategory_ShouldRemoveTheItemFromTheCategory()
        {
            MockedCosmeticsEngine engine = new MockedCosmeticsEngine(mockedFactory.Object, mockedShoppingCart.Object);

            Console.SetIn(new StringReader("CreateCategory ForMale" + Environment.NewLine +
                "CreateToothpaste White+ Colgate 15.50 men fluor,bqla,golqma" +
                Environment.NewLine + "AddToCategory ForMale White+" + Environment.NewLine + "RemoveFromCategory ForMale White+"));

            engine.Start();

            string printedCategory = engine.Categories["ForMale"].Print();
            Assert.IsTrue(printedCategory.IndexOf("White+") == -1);
        }

        [Test]
        public void Start_ShowCategory_ShouldCallCategoryPrintMethod()
        {
            MockedCosmeticsEngine engine = new MockedCosmeticsEngine(mockedFactory.Object, mockedShoppingCart.Object);
            StringBuilder output = new StringBuilder();

            Console.SetIn(new StringReader("CreateCategory ForMale" + Environment.NewLine + "ShowCategory ForMale"));
            Console.SetOut(new StringWriter(output));

            engine.Start();
            Assert.IsTrue(output.ToString().IndexOf("ForMale category") != -1);
        }

        [Test]
        public void Start_CreateShampoo_ShouldAddCreatedShampooToTheListOfProducts()
        {
            MockedCosmeticsEngine engine = new MockedCosmeticsEngine(mockedFactory.Object, mockedShoppingCart.Object);

            Console.SetIn(new StringReader("CreateShampoo Cool Nivea 0.50 men 500 everyday"));
            engine.Start();

            Assert.AreEqual(1, engine.Products.Count);
        }

        [Test]
        public void Start_CreateShampoo_ShouldAddCreatedToothpasteToTheListOfProducts()
        {
            MockedCosmeticsEngine engine = new MockedCosmeticsEngine(mockedFactory.Object, mockedShoppingCart.Object);

            Console.SetIn(new StringReader("CreateToothpaste White+ Colgate 15.50 men fluor,bqla,golqma"));
            engine.Start();

            Assert.AreEqual(1, engine.Products.Count);
        }

        [Test]
        public void Start_AddToShoppingCart_ShouldAddTheSelectedProductToTheShoppingCart()
        {
            MockedCosmeticsEngine engine = new MockedCosmeticsEngine(mockedFactory.Object, mockedShoppingCart.Object);

            Console.SetIn(new StringReader("CreateToothpaste White+ Colgate 15.50 men fluor,bqla,golqma" +
                Environment.NewLine + "AddToShoppingCart White+"));
            engine.Start();

            Assert.AreEqual(1, this.shoppingCartProducts.Count);
        }

        [Test]
        public void Start_RemoveFromShoppingCart_ShouldRemoveSelectedProductFromTheShoppingCart()
        {
            MockedCosmeticsEngine engine = new MockedCosmeticsEngine(mockedFactory.Object, mockedShoppingCart.Object);
            
            Console.SetIn(new StringReader("CreateToothpaste White+ Colgate 15.50 men fluor,bqla,golqma" +
                Environment.NewLine + "AddToShoppingCart White+" + Environment.NewLine + "RemoveFromShoppingCart White+"));
            engine.Start();

            Assert.AreEqual(0, this.shoppingCartProducts.Count);
        }
    }
}