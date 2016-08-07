namespace ArmyOfCreatures.Tests
{
    using System;
    using System.Reflection;

    using NUnit.Framework;
    using Moq;
    using Logic.Specialties;
    using Logic.Battles;

    [TestFixture]
    public class ReduceEnemyDefenseByPercentageTests
    {
        [TestCase(-1)]
        [TestCase(101)]
        public void Constructor_InvalidPercentage_ShouldThrowArgumentOutOfRangeException(int percentage)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new ReduceEnemyDefenseByPercentage(percentage));
        }

        [Test]
        public void Constructor_ValidPercentage_ShouldSetThisPercentageToThePassedValue()
        {
            var specialty = new ReduceEnemyDefenseByPercentage(20);
            var percentage = (decimal)typeof(ReduceEnemyDefenseByPercentage)
                .GetProperty("Percentage", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(specialty);

            Assert.AreEqual(20, percentage);
        }

        [Test]
        public void ApplyWhenAttacking_NullAttacker_ShouldThrowArgumentNulLException()
        {
            var specialty = new ReduceEnemyDefenseByPercentage(20);
            var defender = new Mock<ICreaturesInBattle>();

            Assert.Throws<ArgumentNullException>(() => specialty.ApplyWhenAttacking(null, defender.Object));
        }

        [Test]
        public void ApplyWhenAttacking_NullDefender_ShouldThrowArgumentNulLException()
        {
            var specialty = new ReduceEnemyDefenseByPercentage(20);
            var atatcker = new Mock<ICreaturesInBattle>();

            Assert.Throws<ArgumentNullException>(() => specialty.ApplyWhenAttacking(atatcker.Object, null));
        }

        [Test]
        public void ApplyWhenAttacking_ValidParameters_DefendersDefenseShouldBeReduced()
        {
            var specialty = new ReduceEnemyDefenseByPercentage(20);
            var atatcker = new Mock<ICreaturesInBattle>();
            var defender = new Mock<ICreaturesInBattle>();
            int baseDefense = 100;
            int currentDefense = baseDefense;

            defender.SetupGet(d => d.CurrentDefense).Returns(currentDefense);
            defender.SetupSet(d => d.CurrentDefense = It.IsAny<int>()).Callback<int>(v => currentDefense = v);
            specialty.ApplyWhenAttacking(atatcker.Object, defender.Object);

            Assert.IsTrue(currentDefense < baseDefense);
        }

        [Test]
        public void ToString_ShouldReturnStringWithTypeAndPercentage()
        {
            var reduceEnemyDefenseByPercentage = new ReduceEnemyDefenseByPercentage(50);
            string expected = $"{reduceEnemyDefenseByPercentage.GetType().Name}({50})";
            string actual = reduceEnemyDefenseByPercentage.ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}