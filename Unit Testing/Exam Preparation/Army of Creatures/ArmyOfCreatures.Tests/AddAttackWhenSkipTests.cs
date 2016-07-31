namespace ArmyOfCreatures.Tests
{
    using System;

    using NUnit.Framework;
    using Extended.Specialties;
    using Logic.Battles;
    using Moq;

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
        public void ApplyOnSkip_NullCreature_ShouldThrowArgumentNullException()
        {
            AddAttackWhenSkip addAttackWhenSkip = new AddAttackWhenSkip(5);

            Assert.Throws<ArgumentNullException>(() => addAttackWhenSkip.ApplyOnSkip(null));
        }

        [Test]
        public void ApplyOnSkip_ValidCreature_ShouldAddAttackToAddToCreaturePermanentAttack()
        {
            AddAttackWhenSkip addAttackWhenSkip = new AddAttackWhenSkip(5);
            Mock<ICreaturesInBattle> mockedCreature = new Mock<ICreaturesInBattle>();
            int permanentAttack = 10;

            mockedCreature.SetupGet(c => c.PermanentAttack).Returns(permanentAttack);
            mockedCreature.SetupSet(c => c.PermanentAttack = It.IsAny<int>()).Callback<int>(v => permanentAttack = v);

            addAttackWhenSkip.ApplyOnSkip(mockedCreature.Object);
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