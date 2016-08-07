namespace ArmyOfCreatures.Tests
{
    using System;
    using System.Reflection;

    using Moq;
    using NUnit.Framework;
    using Extended.Specialties;
    using Logic.Battles;

    [TestFixture]
    public class DoubleDamageTests
    {
        [TestCase(-1)]
        [TestCase(11)]
        public void Constructor_InvalidRounds_ShouldThrowArgumentNullException(int rounds)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new DoubleDamage(rounds));
        }

        [Test]
        public void COnstructor_ValidRounds_ShouldSetThisRoundsToThePassedValue()
        {
            var specialty = new DoubleDamage(5);
            int roundsField = (int)typeof(DoubleDamage)
                .GetField("rounds", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(specialty);

            Assert.AreEqual(5, roundsField);
        }

        [Test]
        public void ChangeDamageWhenAttacking_NullAttacker_ShouldThrowArgumentNullException()
        {
            var specialty = new DoubleDamage(5);
            var defender = new Mock<ICreaturesInBattle>();

            Assert.Throws<ArgumentNullException>(() => specialty.ChangeDamageWhenAttacking(null, defender.Object, 10));
        }
        [Test]
        public void ChangeDamageWhenAttacking_NullDefender_ShouldThrowArgumentNullException()
        {
            var specialty = new DoubleDamage(5);
            var attacker = new Mock<ICreaturesInBattle>();

            Assert.Throws<ArgumentNullException>(() => specialty.ChangeDamageWhenAttacking(attacker.Object, null, 10));
        }

        [Test]
        public void ChangeDamageWhenAttacking_LessThanOrEqual0Rounds_ShouldReturnCurrentDamage()
        {
            var specialty = new DoubleDamage(5);
            var attacker = new Mock<ICreaturesInBattle>();
            var defender = new Mock<ICreaturesInBattle>();

            typeof(DoubleDamage)
                .GetField("rounds", BindingFlags.NonPublic | BindingFlags.Instance)
                .SetValue(specialty, 0);

            decimal result = specialty.ChangeDamageWhenAttacking(attacker.Object, defender.Object, 10);

            Assert.AreEqual(10, result);
        }

        [Test]
        public void ChangeDamageWhenAttacking_ValidPArameters_ShouldReturnCurrentDamageDoubled()
        {
            var specialty = new DoubleDamage(5);
            var attacker = new Mock<ICreaturesInBattle>();
            var defender = new Mock<ICreaturesInBattle>();
            decimal result = specialty.ChangeDamageWhenAttacking(attacker.Object, defender.Object, 10);

            Assert.AreEqual(20, result);
        }

        [Test]
        public void ToString_ShouldReturnStringWithTypeAndRounds()
        {
            DoubleDamage doubleDamage = new DoubleDamage(2);
            string expected = $"{doubleDamage.GetType().Name}({2})";

            Assert.AreEqual(expected, doubleDamage.ToString());
        }
    }
}