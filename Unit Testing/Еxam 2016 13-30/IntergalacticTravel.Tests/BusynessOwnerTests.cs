namespace IntergalacticTravel.Tests
{
    using System;

    using NUnit.Framework;
    using Moq;
    using Contracts;
    using System.Collections.Generic;

    [TestFixture]
    public class BusynessOwnerTests
    {
        [Test]
        public void CollectProfits_ShouldIncreaseTheOwnerResourcesByTheTotalAmountOfResourcesGeneratedFromTheTeleportStations()
        {
            var resources = new Mock<IResources>();
            var station = new Mock<ITeleportStation>();

            resources.SetupGet(r => r.BronzeCoins).Returns(10);
            resources.SetupGet(r => r.SilverCoins).Returns(10);
            resources.SetupGet(r => r.GoldCoins).Returns(10);
            station.Setup(s => s.PayProfits(It.IsAny<IBusinessOwner>())).Returns(resources.Object);

            var owner = new BusinessOwner(1, "Owner", new List<ITeleportStation> { station.Object });

            owner.CollectProfits();

            Assert.IsTrue(
                owner.Resources.BronzeCoins == 10 &&
                owner.Resources.SilverCoins == 10 &&
                owner.Resources.GoldCoins == 10);
        }
    }
}