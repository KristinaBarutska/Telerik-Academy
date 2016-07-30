namespace ArmyOfCreatures.Tests
{
    using System;

    using NUnit.Framework;
    using Moq;
    using Logic.Specialties;
    using Logic.Battles;

    [TestFixture]
    public class ReduceEnemyDefenseTests
    {
        [TestCase(-1)]
        [TestCase(101)]
        public void Constructor_PassInvalidPercentage_ShouldThrowArgumentOutOfRangeException(int percentage)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new ReduceEnemyDefenseByPercentage(percentage));
        }

        [Test]
        public void ApplyWhenAttacking_NullAttacker_ShouldThrowArgumentNullException()
        {
            var reduceEnemyDefenseByPercentage = new ReduceEnemyDefenseByPercentage(50);

            Assert.Throws<ArgumentNullException>(() => reduceEnemyDefenseByPercentage.ApplyWhenAttacking(null, null));
        }

        [Test]
        public void ApplyWhenAttacking_NullDefender_ShouldThrowArgumentNullException()
        {
            var reduceEnemyDefenseByPercentage = new ReduceEnemyDefenseByPercentage(50);
            var mockedAttacker = new Mock<ICreaturesInBattle>().Object;

            Assert.Throws<ArgumentNullException>(() => reduceEnemyDefenseByPercentage.ApplyWhenAttacking(mockedAttacker, null));
        }

        [Test]
        public void ApplyWhenAttacking_ValidDefenderAndAttacker_ShouldReduceDefenderCurrentDefense()
        {
            var reduceEnemyDefenseByPercentage = new ReduceEnemyDefenseByPercentage(50);
            var mockedAttacker = new Mock<ICreaturesInBattle>().Object;
            var mockedDefender = new Mock<ICreaturesInBattle>();
            int currentDefense = 100;

            mockedDefender.SetupGet(d => d.CurrentDefense).Returns(currentDefense);
            mockedDefender.SetupSet(d => d.CurrentDefense = It.IsAny<int>()).Callback<int>(v => currentDefense = v);

            reduceEnemyDefenseByPercentage.ApplyWhenAttacking(mockedAttacker, mockedDefender.Object);
            Assert.AreEqual(50, currentDefense);
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