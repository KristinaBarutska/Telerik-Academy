namespace Cosmetics.Tests
{
    using System;

    using NUnit.Framework;
    using Moq;
    using Engine;
    using Common;
    using Contracts;
    using System.Collections.Generic;
    [TestFixture]
    public class CosmeticsFactoryTests
    {
        [TestCase("")]
        [TestCase(null)]
        public void CreateShampoo_NullOrEmptyName_ShouldThrowNullReferenseException(string name)
        {
            CosmeticsFactory factory = new CosmeticsFactory();
            Assert.Throws<NullReferenceException>(() => factory.CreateShampoo(name, "dsa", 1, GenderType.Men, 3, UsageType.EveryDay));
        }

        [TestCase("a")]
        [TestCase("aaaaaaaaaaaa")]
        public void CreateShampoo_InvalidNameLength_ShouldThrowIndexOutOfRangeException(string name)
        {
            CosmeticsFactory factory = new CosmeticsFactory();
            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateShampoo(name, "dsa", 1, GenderType.Men, 3, UsageType.EveryDay));
        }

        [TestCase("")]
        [TestCase(null)]
        public void CreateShampoo_NullOrEmpty_ShouldThrowNullReferenseException(string brand)
        {
            CosmeticsFactory factory = new CosmeticsFactory();
            Assert.Throws<NullReferenceException>(() => factory.CreateShampoo("dsa", brand, 1, GenderType.Men, 3, UsageType.EveryDay));
        }

        [TestCase("a")]
        [TestCase("aaaaaaaaaaaa")]
        public void CreateShampoo_InvalidBrandLength_ShouldThrowIndexOutOfRangeException(string brand)
        {
            CosmeticsFactory factory = new CosmeticsFactory();
            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateShampoo("dsa", brand, 1, GenderType.Men, 3, UsageType.EveryDay));
        }

        [Test]
        public void CreateShampoo_ValidParameters_ShouldReturnNewShampoo()
        {
            CosmeticsFactory factory = new CosmeticsFactory();
            IShampoo shampoo = factory.CreateShampoo("dsad", "dsad", 13, GenderType.Men, 100, UsageType.EveryDay);

            Assert.AreEqual("Shampoo", shampoo.GetType().Name);
        }

        [Test]
        public void CreateCategory_ValidParameters_ShouldReturnNewCategory()
        {
            CosmeticsFactory factory = new CosmeticsFactory();
            ICategory category = factory.CreateCategory("dasdas");

            Assert.AreEqual("Category", category.GetType().Name);
        }

        [TestCase("")]
        [TestCase(null)]
        public void CreateToothpaste_NullOrEmptyName_ShouldThrowNullReferenseException(string name)
        {
            CosmeticsFactory factory = new CosmeticsFactory();
            Assert.Throws<NullReferenceException>(() => factory.CreateToothpaste(name, "dsad", 1, GenderType.Men, new List<string>()));
        }

        [TestCase("a")]
        [TestCase("aaaaaaaaaaaa")]
        public void CreateToothpaste_InvalidNameLength_ShouldThrowIndexOutOfRangeException(string name)
        {
            CosmeticsFactory factory = new CosmeticsFactory();
            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateToothpaste(name, "dsad", 1, GenderType.Men, new List<string>()));
        }

        [TestCase("")]
        [TestCase(null)]
        public void CreateToothpaste_NullOrEmptyBrand_ShouldThrowNullReferenseException(string brand)
        {
            CosmeticsFactory factory = new CosmeticsFactory();
            Assert.Throws<NullReferenceException>(() => factory.CreateToothpaste("dsadsa", brand, 1, GenderType.Men, new List<string>()));
        }

        [TestCase("a")]
        [TestCase("aaaaaaaaaaaa")]
        public void CreateToothpaste_InvalidBrandLength_ShouldThrowIndexOutOfRangeException(string brand)
        {
            CosmeticsFactory factory = new CosmeticsFactory();
            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateToothpaste("dsadsa", brand, 1, GenderType.Men, new List<string>()));
        }

        [Test]
        public void CreateShoppingCart_ShouldReturnNewShoppingCart()
        {
            CosmeticsFactory factory = new CosmeticsFactory();
            Assert.AreEqual("ShoppingCart", factory.CreateShoppingCart().GetType().Name);
        }
    }
}