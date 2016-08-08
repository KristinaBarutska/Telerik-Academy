namespace Cosmetics.Tests.Engine.Tests
{
    using System;
    using System.Reflection;

    using NUnit.Framework;
    using Cosmetics.Engine;
    using Moq;
    using Contracts;
    using System.Collections.Generic;
    using Cosmetics.Common;
    using Products;
    using Mocks;
    using Cosmetics.Products;

    [TestFixture]
    public class CosmeticsEngineTests
    {
        [Test]
        public void Start_CreateCategoryCommand_ShouldAddNewCategoryToTheListOfCategories()
        {
            var factory = new Mock<ICosmeticsFactory>();
            var shoppingCart = new Mock<IShoppingCart>();
            var commandParser = new Mock<ICommandParser>();

            commandParser.Setup(p => p.ReadCommands()).Returns(new List<ICommand> { Command.Parse("CreateCategory ForMale") });

            var engine = new CosmeticsEngine(factory.Object, shoppingCart.Object, commandParser.Object);

            engine.Start();

            var categoriesField = typeof(CosmeticsEngine)
                .GetField("categories", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(engine) as IDictionary<string, ICategory>;

            Assert.AreEqual(1, categoriesField.Count);
        }

        [Test]
        public void Start_AddToCategoryCommand_ShouldAddTheProductToTheCategory()
        {
            var factory = new Mock<ICosmeticsFactory>();
            var shoppingCart = new Mock<IShoppingCart>();
            var commandParser = new Mock<ICommandParser>();
            var addCommand = Command.Parse("AddToCategory ForMale White+");
            var toothpaste = new Toothpaste("White+", "Colgate", 15.50m, GenderType.Men, new List<string> { "fluor", "bqla", "golqma" });

            commandParser.Setup(p => p.ReadCommands()).Returns(new List<ICommand> { addCommand });

            var engine = new MockedCosmeticsEngine(factory.Object, shoppingCart.Object, commandParser.Object);

            engine.Categories.Add("ForMale", new Category("ForMale"));
            engine.Products.Add("White+", toothpaste);
            engine.Start();

            var categoryForMale = engine.Categories["ForMale"];
            var categoryProducts = typeof(Category)
                .GetField("products", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(categoryForMale) as IList<IProduct>;

            Assert.AreEqual(1, categoryProducts.Count);
        }

        [Test]
        public void Start_RemoveFromCategory_ShouldRemoveTheProductFromTheCategory()
        {
            var factory = new Mock<ICosmeticsFactory>();
            var shoppingCart = new Mock<IShoppingCart>();
            var commandParser = new Mock<ICommandParser>();
            var toothpaste = new Toothpaste("White+", "Colgate", 15.50m, GenderType.Men, new List<string> { "fluor", "bqla", "golqma" });
            var removeCommand = Command.Parse("RemoveFromCategory ForMale White+");

            commandParser.Setup(p => p.ReadCommands()).Returns(new List<ICommand> { removeCommand });

            var engine = new MockedCosmeticsEngine(factory.Object, shoppingCart.Object, commandParser.Object);

            engine.Categories.Add("ForMale", new Category("ForMale"));
            engine.Products.Add("White+", toothpaste);
            engine.Categories["ForMale"].AddProduct(toothpaste);
            engine.Start();

            var categoryProducts = typeof(Category)
                .GetField("products", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(engine.Categories["ForMale"]) as IList<IProduct>;

            Assert.AreEqual(0, categoryProducts.Count);
        }

        [Test]
        public void Start_ShowCategoryCommand_ShouldCallCategoryPrintMethod()
        {
            var factory = new Mock<ICosmeticsFactory>();
            var shoppingCart = new Mock<IShoppingCart>();
            var commandParser = new Mock<ICommandParser>();
            var category = new Mock<ICategory>();
            var showCategoryCommand = Command.Parse("ShowCategory ForMale");

            commandParser.Setup(p => p.ReadCommands()).Returns(new List<ICommand> { showCategoryCommand });

            var engine = new MockedCosmeticsEngine(factory.Object, shoppingCart.Object, commandParser.Object);

            engine.Categories.Add("ForMale", category.Object);
            engine.Start();
            category.Verify(c => c.Print(), Times.Once);
        }

        [Test]
        public void Start_CreateShampoo_ShouldAddCreatedShampooToTheListOfProducts()
        {
            var factory = new Mock<ICosmeticsFactory>();
            var shoppingCart = new Mock<IShoppingCart>();
            var commandParser = new Mock<ICommandParser>();
            var createShampooCommand = Command.Parse("CreateShampoo Cool Nivea 0.50 men 500 everyday");

            factory
                .Setup(f => f.CreateShampoo(
                    It.IsAny<string>(), It.IsAny<string>(), It.IsAny<decimal>(), It.IsAny<GenderType>(), It.IsAny<uint>(), It.IsAny<UsageType>()
                ))
                .Returns((string a, string b, decimal c, GenderType d, uint e, UsageType f) =>
                {
                    return new Shampoo(a, b, c, d, e, f);
                });
            commandParser.Setup(p => p.ReadCommands()).Returns(new List<ICommand> { createShampooCommand });

            var engine = new MockedCosmeticsEngine(factory.Object, shoppingCart.Object, commandParser.Object);
            engine.Start();

            Assert.AreEqual(1, engine.Products.Count);
        }

        [Test]
        public void Start_CreateToothpaste_ShouldAddCreatedToothpasteToTheListOfProducts()
        {
            var factory = new Mock<ICosmeticsFactory>();
            var shoppingCart = new Mock<IShoppingCart>();
            var commandParser = new Mock<ICommandParser>();
            var createToothpaste = Command.Parse("CreateToothpaste White+ Colgate 15.50 men fluor,bqla,golqma");

            factory
                .Setup(f => f.CreateToothpaste(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<decimal>(), It.IsAny<GenderType>(), It.IsAny<IList<string>>()))
                .Returns((string a, string b, decimal c, GenderType d, IList<string> e) => new Toothpaste(a, b, c, d, e));
            commandParser.Setup(p => p.ReadCommands()).Returns(new List<ICommand> { createToothpaste });

            var engine = new MockedCosmeticsEngine(factory.Object, shoppingCart.Object, commandParser.Object);
            engine.Start();

            Assert.AreEqual(1, engine.Products.Count);
        }

        [Test]
        public void Start_AddToShoppingCart_ShouldAddTheProductToTheShoppingCart()
        {
            var factory = new Mock<ICosmeticsFactory>();
            var shoppingCart = new Mock<IShoppingCart>();
            var commandParser = new Mock<ICommandParser>();
            var addToCartCommand = Command.Parse("AddToShoppingCart White+");
            var shoppingCartList = new List<IProduct>();
            var product = new Mock<IToothpaste>();

            product.SetupGet(p => p.Name).Returns("White+");
            commandParser.Setup(p => p.ReadCommands()).Returns(new List<ICommand> { addToCartCommand });
            shoppingCart.Setup(s => s.AddProduct(It.IsAny<IProduct>())).Callback<IProduct>(p => shoppingCartList.Add(p));

            var engine = new MockedCosmeticsEngine(factory.Object, shoppingCart.Object, commandParser.Object);
            engine.Products.Add("White+", product.Object);
            engine.Start();

            Assert.AreEqual(1, shoppingCartList.Count);
            shoppingCart.Verify(c => c.AddProduct(It.IsAny<IProduct>()), Times.Once());
        }

        [Test]
        public void Start_RemoveFromShoppingCart_ShouldRemoveTheProductFromTheShoppingCart()
        {
            var factory = new Mock<ICosmeticsFactory>();
            var shoppingCart = new Mock<IShoppingCart>();
            var commandParser = new Mock<ICommandParser>();
            var removeFromCartCommand = Command.Parse("RemoveFromShoppingCart White+");
            var product = new Mock<IToothpaste>();
            product.SetupGet(p => p.Name).Returns("White+");

            var shoppingCartList = new List<IProduct> { product.Object };

            commandParser.Setup(p => p.ReadCommands()).Returns(new List<ICommand> { removeFromCartCommand });
            shoppingCart.Setup(c => c.RemoveProduct(It.IsAny<IProduct>())).Callback<IProduct>(p => shoppingCartList.Remove(p));
            shoppingCart.Setup(c => c.ContainsProduct(It.IsAny<IProduct>())).Returns(true);

            var engine = new MockedCosmeticsEngine(factory.Object, shoppingCart.Object, commandParser.Object);

            engine.Products.Add("White+", product.Object);
            engine.Start();

            Assert.AreEqual(0, shoppingCartList.Count);
            shoppingCart.Verify(c => c.RemoveProduct(It.IsAny<IProduct>()), Times.Once());
        }
    }
}