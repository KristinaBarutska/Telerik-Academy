namespace IntergalacticTravel.Tests
{
    using System;

    using NUnit.Framework;
    using Moq;
    using Contracts;

    [TestFixture]
    public class UnitTests
    {
        [Test]
        public void Pay_NullResources_ShouldThrowNullReferenceException()
        {
            var unit = new Unit(1, "Unit");
            Assert.Throws<NullReferenceException>(() => unit.Pay(null));
        }

        [Test]
        public void Pay_ValidResources_ShouldDecreaseUnitsResourcesByTheGivenAmount()
        {
            var resourcesToPay = new Mock<IResources>();

            resourcesToPay.SetupGet(r => r.BronzeCoins).Returns(5);
            resourcesToPay.SetupGet(r => r.SilverCoins).Returns(5);
            resourcesToPay.SetupGet(r => r.GoldCoins).Returns(5);

            var unit = new Unit(1, "Unit");

            unit.Resources.BronzeCoins = 10;
            unit.Resources.SilverCoins = 10;
            unit.Resources.GoldCoins = 10;

            unit.Pay(resourcesToPay.Object);

            Assert.IsTrue(
                unit.Resources.BronzeCoins == 5 &&
                unit.Resources.SilverCoins == 5 &&
                unit.Resources.GoldCoins == 5);
        }

        [Test]
        public void Pay_ValidResources_ShouldReturnResourcesObjectWithTheCostsValues()
        {
            var resourcesToPay = new Mock<IResources>();

            resourcesToPay.SetupGet(r => r.BronzeCoins).Returns(5);
            resourcesToPay.SetupGet(r => r.SilverCoins).Returns(5);
            resourcesToPay.SetupGet(r => r.GoldCoins).Returns(5);

            var unit = new Unit(1, "Unit");

            unit.Resources.BronzeCoins = 10;
            unit.Resources.SilverCoins = 10;
            unit.Resources.GoldCoins = 10;

            var resourseResult = unit.Pay(resourcesToPay.Object);

            Assert.IsTrue(
                resourseResult.BronzeCoins == resourcesToPay.Object.BronzeCoins &&
                resourseResult.SilverCoins == resourcesToPay.Object.SilverCoins &&
                resourseResult.GoldCoins == resourcesToPay.Object.GoldCoins);
        }
    }
}