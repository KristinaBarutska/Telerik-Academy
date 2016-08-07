namespace ArmyOfCreatures.Tests
{
    using System;
    using System.Reflection;

    using NUnit.Framework;
    using Logic.Specialties;
    using Moq;
    using Logic.Battles;

    [TestFixture]
    public class DoubleDefenseWhenDefendingTests
    {
        [TestCase(0)]
        [TestCase(-1)]
        public void Constructor_InvalidRounds_ShouldThrowArgumentOutOfRangeException(int rounds)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new DoubleDefenseWhenDefending(rounds));
        }

        [Test]
        public void Constructor_ValidRounds_ShouldSetThisRoundsToThePassedValue()
        {
            var specialty = new DoubleDefenseWhenDefending(10);
            var rounds = (int)typeof(DoubleDefenseWhenDefending)
                .GetField("rounds", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(specialty);

            Assert.AreEqual(10, rounds);
        }

        [Test]
        public void ApplyWhenDefending_NullDefender_ShouldThrowArgumentNullException()
        {
            var specialty = new DoubleDefenseWhenDefending(10);
            var attacker = new Mock<ICreaturesInBattle>();

            Assert.Throws<ArgumentNullException>(() => specialty.ApplyWhenDefending(null, attacker.Object));
        }

        [Test]
        public void ApplyWhenDefending_NullAttacker_ShouldThrowArgumentNullException()
        {
            var specialty = new DoubleDefenseWhenDefending(10);
            var defender = new Mock<ICreaturesInBattle>();

            Assert.Throws<ArgumentNullException>(() => specialty.ApplyWhenDefending(defender.Object, null));
        }

        [Test]
        public void ApplyWhenDefending_ZeroOrLessRounds_ShouldNotModifyDefendersCurrentDefense()
        {
            var specialty = new DoubleDefenseWhenDefending(10);
            var defender = new Mock<ICreaturesInBattle>();
            int currentDefense = 10;

            defender.SetupGet(d => d.CurrentDefense).Returns(currentDefense);
            defender.SetupSet(d => d.CurrentDefense = It.IsAny<int>()).Callback<int>(v => currentDefense = v);

            var attacker = new Mock<ICreaturesInBattle>();

            typeof(DoubleDefenseWhenDefending)
                .GetField("rounds", BindingFlags.NonPublic | BindingFlags.Instance)
                .SetValue(specialty, -1);
            specialty.ApplyWhenDefending(defender.Object, attacker.Object);
            Assert.AreEqual(10, currentDefense);
        }

        [Test]
        public void ApplyWhenDefending_ValidDefenderAndAttacker_DefenderCurrentDefenseShouldBeDoubled()
        {
            var specialty = new DoubleDefenseWhenDefending(10);
            var defender = new Mock<ICreaturesInBattle>();
            var attacker = new Mock<ICreaturesInBattle>();
            int currentDefense = 10;

            defender.SetupGet(d => d.CurrentDefense).Returns(currentDefense);
            defender.SetupSet(d => d.CurrentDefense = It.IsAny<int>()).Callback<int>(v => currentDefense = v);
            specialty.ApplyWhenDefending(defender.Object, attacker.Object);

            Assert.AreEqual(20, currentDefense);
        }

        [Test]
        public void ApplyWhenDefending_WhenTheMethodIsExecutedProperlyThisRoundsShouldBeDecreasedByOne()
        {
            var specialty = new DoubleDefenseWhenDefending(10);
            var defender = new Mock<ICreaturesInBattle>();
            var attacker = new Mock<ICreaturesInBattle>();
            int currentDefense = 10;

            defender.SetupGet(d => d.CurrentDefense).Returns(currentDefense);
            defender.SetupSet(d => d.CurrentDefense = It.IsAny<int>()).Callback<int>(v => currentDefense = v);
            specialty.ApplyWhenDefending(defender.Object, attacker.Object);

            int rounds = (int)typeof(DoubleDefenseWhenDefending)
                .GetField("rounds", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(specialty);

            Assert.AreEqual(9, rounds);
        }

        [Test]
        public void ToString_ShouldReturnStringWithTypeAndRounds()
        {
            var doubleDefenseWhenDefending = new DoubleDefenseWhenDefending(1);
            string expected = $"{doubleDefenseWhenDefending.GetType().Name}({1})";
            string actual = doubleDefenseWhenDefending.ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}