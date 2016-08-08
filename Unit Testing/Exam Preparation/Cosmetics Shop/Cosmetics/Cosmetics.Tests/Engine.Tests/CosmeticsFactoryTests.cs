namespace Cosmetics.Tests.Engine.Tests
{
    using System;

    using NUnit.Framework;
    using Cosmetics.Engine;
    using Cosmetics.Common;
    using System.Collections.Generic;

    [TestFixture]
    public class CosmeticsFactoryTests
    {

        [TestCase("")]
        [TestCase(null)]
        public void CreateShampoo_InvalidName_ShouldThrowNullReferenseException(string name)
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                new CosmeticsFactory().CreateShampoo(name, "dsad", 12.12m, GenderType.Men, 1, UsageType.EveryDay);
            });
        }

        [TestCase("a")]
        [TestCase("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        public void CreateShampoo_InvalidNameLength_ShouldThrowIndexOutOfRangeException(string name)
        {
            Assert.Throws<IndexOutOfRangeException>((TestDelegate)(() =>
            {
                new CosmeticsFactory().CreateShampoo(name, "dsad", 12.12m, GenderType.Men, 1, UsageType.EveryDay);
            }));
        }

        [TestCase("")]
        [TestCase(null)]
        public void CreateShampoo_InvalidBrand_ShouldThrowNullReferenseException(string brand)
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                new CosmeticsFactory().CreateShampoo("dsadsa", brand, 12.12m, GenderType.Men, 1, UsageType.EveryDay);
            });
        }

        [TestCase("a")]
        [TestCase("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        public void CreateShampoo_InvalidBrandLength_ShouldThrowIndexOutOfRangeException(string brand)
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                new CosmeticsFactory().CreateShampoo("dsad", brand, 12.12m, GenderType.Men, 1, UsageType.EveryDay);
            });
        }

        [Test]
        public void CreateShampoo_ValidParameters_ShouldReturnNewShampoo()
        {
            var shampoo = new CosmeticsFactory().CreateShampoo("Shampoo", "Brand", 12.12m, GenderType.Men, 1, UsageType.EveryDay);
            Assert.AreEqual("Shampoo", shampoo.Name);
        }

        [TestCase("")]
        [TestCase(null)]
        public void CreateCategory_InvalidName_ShouldThrowNullReferenseException(string name)
        {
            Assert.Throws<NullReferenceException>(() => new CosmeticsFactory().CreateCategory(name));
        }

        [TestCase("a")]
        [TestCase("aaaaaaaaaaaaaaaaaaaa")]
        public void CreateCategory_InvalidNameLength_ShouldThrowIndexOutOfRangeException(string name)
        {
            Assert.Throws<IndexOutOfRangeException>(() => new CosmeticsFactory().CreateCategory(name));
        }

        [Test]
        public void CreateCategory_ValidName_ShouldReturnNewCategory()
        {
            var category = new CosmeticsFactory().CreateCategory("Category");
            Assert.AreEqual("Category", category.Name);
        }

        [TestCase("")]
        [TestCase(null)]
        public void CreateToothpaste_InvalidName_ShouldThrowNullReferenseException(string name)
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                new CosmeticsFactory().CreateToothpaste(name, "dsadsa", 15m, GenderType.Men, new List<string> { });
            });
        }

        [TestCase("a")]
        [TestCase("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        public void CreateToothpaste_InvalidNameLength_ShouldThrowIndexOutOfRange(string name)
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                new CosmeticsFactory().CreateToothpaste(name, "dsadsa", 15m, GenderType.Men, new List<string> { });
            });
        }

        [TestCase("")]
        [TestCase(null)]
        public void CreateToothpaste_InvalidBrand_ShouldThrowNullReferenseException(string brand)
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                new CosmeticsFactory().CreateToothpaste("dsadas", brand, 15m, GenderType.Men, new List<string> { });
            });
        }

        [TestCase("a")]
        [TestCase("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        public void CreateToothpaste_InvalidBrandLength_ShouldThrowIndexOutOfRange(string brand)
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                new CosmeticsFactory().CreateToothpaste("dsadas", brand, 15m, GenderType.Men, new List<string> { });
            });
        }

        [Test]
        public void CreateShoppingCart_ShouldReturnAlwaysNewShoppingCart()
        {
            Assert.IsNotNull(new CosmeticsFactory().CreateShoppingCart());
        }
    }
}