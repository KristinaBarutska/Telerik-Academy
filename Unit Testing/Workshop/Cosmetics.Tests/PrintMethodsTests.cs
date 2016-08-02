namespace Cosmetics.Tests
{
    using System;
    using System.Collections.Generic;

    using NUnit.Framework;
    using Products;
    using Common;

    [TestFixture]
    public class PrintMethodsTests
    {
        private readonly string NewLine = Environment.NewLine;

        [Test]
        public void ShampooPrint_ShouldReturnStringWithTheShampooDetailsInTheRequiredFormat()
        {
            Shampoo shampoo = new Shampoo("shampoo", "shampoo", 10, GenderType.Men, 100, UsageType.EveryDay);
            string expected = $"- shampoo - shampoo:{NewLine}  * Price: $1000{NewLine}  * For gender: Men{NewLine}  * Quantity: 100 ml\r\n  * Usage: EveryDay";
            string actual = shampoo.Print();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToothpastePrint_ShouldReturnStringWithTheToothpasteDetailsInTheRequiredFormat()
        {
            Toothpaste toothpaste = new Toothpaste("toothpaste", "toothpaste", 10, GenderType.Men, new List<string>() { "first", "second" });
            string expected = $"- toothpaste - toothpaste:{NewLine}  * Price: $10{NewLine}  * For gender: Men{NewLine}  * Ingredients: first, second";
            string actual = toothpaste.Print();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CategoryPrint_ShouldReturnStringWithTheCategoryDetailsInTheRequiredFormat()
        {
            Category category = new Category("Category");
            string expected = "Category category - 0 products in total";
            string actual = category.Print();

            Assert.AreEqual(expected, actual);
        }
    }
}