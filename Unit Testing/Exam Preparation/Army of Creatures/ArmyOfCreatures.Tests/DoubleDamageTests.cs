namespace ArmyOfCreatures.Tests
{
    using System;

    using NUnit.Framework;
    using Extended.Specialties;
    using Logic.Battles;
    using Moq;

    [TestFixture]
    public class DoubleDamageTests
    {
        [TestCase(0)]
        [TestCase(11)]
        public void Constructor_InvalidRounds_ShouldThrowArgumentNullException(int rounds)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new DoubleDamage(rounds));
        }

        [Test]
        public void ChangeDamageWhenAttacking_NullAttacker_ShouldThrowArgumentNullException()
        {
            DoubleDamage doubleDamage = new DoubleDamage(2);
            Mock<ICreaturesInBattle> mockedDefender = new Mock<ICreaturesInBattle>();

            Assert.Throws<ArgumentNullException>(() => doubleDamage.ChangeDamageWhenAttacking(null, mockedDefender.Object, 3));
        }

        [Test]
        public void ChangeDamageWhenAttacking_NullDefender_ShouldThrowArgumentNullException()
        {
            DoubleDamage doubleDamage = new DoubleDamage(2);
            Mock<ICreaturesInBattle> mockedAttacker = new Mock<ICreaturesInBattle>();

            Assert.Throws<ArgumentNullException>(() => doubleDamage.ChangeDamageWhenAttacking(mockedAttacker.Object, null, 3));
        }

        [Test]
        public void ChangeDamageWhenAttacking_ValidParameters_ShouldReturnCurrentDamageDoubled()
        {
            DoubleDamage doubleDamage = new DoubleDamage(2);
            Mock<ICreaturesInBattle> mockedAttacker = new Mock<ICreaturesInBattle>();
            Mock<ICreaturesInBattle> mockedDefender = new Mock<ICreaturesInBattle>();
            int currentDamage = 5;

            Assert.AreEqual(10, doubleDamage.ChangeDamageWhenAttacking(mockedAttacker.Object, mockedDefender.Object, currentDamage));
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