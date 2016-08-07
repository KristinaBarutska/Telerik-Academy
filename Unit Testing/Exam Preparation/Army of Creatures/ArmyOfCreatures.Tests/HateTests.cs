namespace ArmyOfCreatures.Tests
{
    using System;
    using System.Reflection;

    using NUnit.Framework;
    using Moq;
    using Logic.Specialties;
    using Logic.Creatures;
    using Logic.Battles;
    using Extended.Creatures;

    [TestFixture]
    public class HateTests
    {
        [Test]
        public void Constructor_NullCreatureToHate_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new Hate(null));
        }

        [Test]
        public void Constructor_ValidCreatureToHate_ShouldSetCreatureToHateToThePassedValue()
        {
            var specialty = new Hate(typeof(Angel));
            var creatureToHate = (Type)typeof(Hate)
                .GetField("creatureTypeToHate", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(specialty);

            Assert.AreEqual(typeof(Angel), creatureToHate);
        }

        [Test]
        public void ChangeDamageWhenAttacking_NullAttacker_ShouldThrowArgumentNullEception()
        {
            var specialty = new Hate(typeof(Angel));
            var defender = new Mock<ICreaturesInBattle>();

            Assert.Throws<ArgumentNullException>(() => specialty.ChangeDamageWhenAttacking(null, defender.Object, 1));
        }

        [Test]
        public void ChangeDamageWhenAttacking_NullDefender_ShouldThrowArgumentNullException()
        {
            var specialty = new Hate(typeof(Angel));
            var attacker = new Mock<ICreaturesInBattle>();

            Assert.Throws<ArgumentNullException>(() => specialty.ChangeDamageWhenAttacking(attacker.Object, null, 1));
        }

        [Test]
        public void ChangeDamageWhenAttacking_ValidParameters_DefenderAndCreatureToHateWithSameType_ReturnDamageMultiplied1point5()
        {
            var specialty = new Hate(typeof(Angel));
            var attacker = new Mock<ICreaturesInBattle>();
            var defender = new Mock<ICreaturesInBattle>();

            defender.SetupGet(d => d.Creature).Returns(new Angel());
            decimal newDamage = specialty.ChangeDamageWhenAttacking(attacker.Object, defender.Object, 10);

            Assert.AreEqual(15, newDamage);
        }

        [Test]
        public void ChangeDamageWhenAttacking_ValidParameters_DefenderAndCreatureToHateWithDifferentTypes_ReturnCurrentDamage()
        {
            var specialty = new Hate(typeof(Angel));
            var attacker = new Mock<ICreaturesInBattle>();
            var defender = new Mock<ICreaturesInBattle>();

            defender.SetupGet(d => d.Creature).Returns(new Goblin());
            var damage = specialty.ChangeDamageWhenAttacking(attacker.Object, defender.Object, 10);

            Assert.AreEqual(10, damage);
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