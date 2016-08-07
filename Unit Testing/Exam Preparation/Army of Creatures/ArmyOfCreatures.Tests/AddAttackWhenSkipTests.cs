namespace ArmyOfCreatures.Tests
{
    using System;
    using System.Reflection;

    using Moq;
    using NUnit.Framework;
    using Extended.Specialties;
    using Logic.Battles;

    [TestFixture]
    public class AddAttackWhenSkipTests
    {
        [TestCase(0)]
        [TestCase(11)]
        public void Constructor_InvalidAttackToAdd_ShouldThrowArgumentOutOfRangeException(int attackToAdd)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new AddAttackWhenSkip(attackToAdd));
        }

        [Test]
        public void Constructor_ValidAttackToAdd_ShouldSetAttackToAddToThePassedValue()
        {
            var specialty = new AddAttackWhenSkip(5);
            var attackToAddField = (int)typeof(AddAttackWhenSkip)
                .GetField("attackToAdd", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(specialty);

            Assert.AreEqual(5, attackToAddField);
        }

        [Test]
        public void ApplyOnSkip_NullCreature_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new AddAttackWhenSkip(5).ApplyOnSkip(null));
        }

        [Test]
        public void ApplyOnSKip_ValidCreature_CreaturePermanentAttackShouldBeIncreasedByAttackToAdd()
        {
            var specialty = new AddAttackWhenSkip(5);
            var creature = new Mock<ICreaturesInBattle>();
            int permanentAttack = 10;

            creature.SetupGet(c => c.PermanentAttack).Returns(permanentAttack);
            creature.SetupSet(c => c.PermanentAttack = It.IsAny<int>()).Callback<int>(v => permanentAttack = v);
            specialty.ApplyOnSkip(creature.Object);

            Assert.AreEqual(15, permanentAttack);
        }

        [Test]
        public void ToString_ShouldReturnStringWithTypeAndAttackToAdd()
        {
            AddAttackWhenSkip addAttackWhenSkip = new AddAttackWhenSkip(5);
            string expected = $"{addAttackWhenSkip.GetType().Name}({5})";

            Assert.AreEqual(expected, addAttackWhenSkip.ToString());
        }
    }
}