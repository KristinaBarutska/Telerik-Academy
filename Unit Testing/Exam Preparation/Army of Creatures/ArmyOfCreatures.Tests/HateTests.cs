namespace ArmyOfCreatures.Tests
{
    using System;

    using NUnit.Framework;
    using Moq;
    using Logic.Specialties;
    using Logic.Creatures;
    using Logic.Battles;
    using Extended.Creatures;

    public class HateTests
    {
        [Test]
        public void Constructor_NullCretureTypeToHate_ShouldThrowNewArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new Hate(null));
        }

        [Test]
        public void ChangeDamageWhenAttacking_NullAttacker_ShouldThrowArgumentNullException()
        {
            var hate = new Hate(typeof(Angel));

            Assert.Throws<ArgumentNullException>(() => hate.ChangeDamageWhenAttacking(null, null, 0));
        }

        [Test]
        public void ChangeDamageWhenAttacking_NullDefender_ShouldThrowArgumentNullException()
        {
            var hate = new Hate(typeof(Angel));
            var mockedAttacker = new Mock<ICreaturesInBattle>();

            Assert.Throws<ArgumentNullException>(() => hate.ChangeDamageWhenAttacking(mockedAttacker.Object, null, 0));
        }

        [Test]
        public void ChangeDamageWhenAttacking_DefenderWithTheSameTypeOfCreatureToHate_ReturnDamageMultiplied()
        {
            var hate = new Hate(typeof(Angel));
            var mockedAttacker = new Mock<ICreaturesInBattle>();
            var mockedDefender = new Mock<ICreaturesInBattle>();
            decimal currentDamage = 10;

            mockedDefender.SetupGet(d => d.Creature).Returns(new Angel());

            decimal expected = 15;
            decimal actual = hate.ChangeDamageWhenAttacking(mockedAttacker.Object, mockedDefender.Object, currentDamage);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ChangeDamageWhenAttacking_DefenderWithDifferentTypeOfCreatureToHate_ReturnCurrentDamage()
        {
            var hate = new Hate(typeof(Angel));
            var mockedAttacker = new Mock<ICreaturesInBattle>();
            var mockedDefender = new Mock<ICreaturesInBattle>();
            decimal currentDamage = 10;

            mockedDefender.SetupGet(d => d.Creature).Returns(new Goblin());

            decimal expected = currentDamage;
            decimal actual = hate.ChangeDamageWhenAttacking(mockedAttacker.Object, mockedDefender.Object, currentDamage);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToString_ShouldReturnStringWithTypeAndCreatureToHateName()
        {
            var hate = new Hate(typeof(Angel));
            string expected = $"{hate.GetType().Name}({(typeof(Angel)).Name})";
            string actual = hate.ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}