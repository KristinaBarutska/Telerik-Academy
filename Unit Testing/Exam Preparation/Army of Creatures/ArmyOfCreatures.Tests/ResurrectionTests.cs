namespace ArmyOfCreatures.Tests
{
    using System;
    using System.Reflection;

    using NUnit.Framework;
    using Moq;
    using Logic.Specialties;
    using Logic.Battles;
    using Logic.Creatures;

    [TestFixture]
    public class ResurrectionTests
    {
        [Test]
        public void ApplyAfterDefending_NullDefender_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new Resurrection().ApplyAfterDefending(null));
        }

        [Test]
        public void ApplyAfterDefending_ValidDefender_ShouldSetTotalHitPointsToTheCreatureHeathPoints()
        {
            var creature = new Angel();
            var creaturesInBattle = new CreaturesInBattle(creature, 1);
            var specialty = new Resurrection();

            creaturesInBattle.TotalHitPoints = 10;
            specialty.ApplyAfterDefending(creaturesInBattle);
            Assert.AreEqual(creature.HealthPoints, creaturesInBattle.TotalHitPoints);
        }
    }
}