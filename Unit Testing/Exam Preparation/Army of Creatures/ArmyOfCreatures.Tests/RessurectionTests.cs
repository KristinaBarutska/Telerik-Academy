namespace ArmyOfCreatures.Tests
{
    using System;

    using NUnit.Framework;
    using Moq;
    using Logic.Specialties;
    using Logic.Battles;
    using Logic.Creatures;

    [TestFixture]
    public class RessurectionTests
    {
        [Test]
        public void ApplyAfterDefending_NullDefender_ShouldThrowArgumentNullException()
        {
            var ressurection = new Resurrection();

            Assert.Throws<ArgumentNullException>(() => ressurection.ApplyAfterDefending(null));
        }

        [Test]
        public void ApplyAfterDefending_DefenderWithPositiveTotalHitPoints_ShouldSetHitPointsToCreatureHealthPoints()
        {
            var ressurection = new Resurrection();
            var mockedDefender = new Mock<ICreaturesInBattle>();
            var creature = new Angel();
            int totalHealthPoints = 10;

            mockedDefender.SetupGet(d => d.Creature).Returns(creature);
            mockedDefender.SetupGet(d => d.Count).Returns(1);
            mockedDefender.SetupGet(d => d.TotalHitPoints).Returns(totalHealthPoints);
            mockedDefender.SetupSet(d => d.TotalHitPoints = It.IsAny<int>()).Callback<int>(v => totalHealthPoints = v);

            ressurection.ApplyAfterDefending(mockedDefender.Object);
            
            int expected = 200;
            int actual = totalHealthPoints;

            Assert.AreEqual(expected, actual);
        }
    }
}