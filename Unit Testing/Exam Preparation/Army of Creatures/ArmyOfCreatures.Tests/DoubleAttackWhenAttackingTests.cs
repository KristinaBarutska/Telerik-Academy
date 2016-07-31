namespace ArmyOfCreatures.Tests
{
    using System;

    using NUnit.Framework;
    using Extended.Specialties;
    using Logic.Battles;
    using Moq;

    [TestFixture]
    public class DoubleAttackWhenAttackingTests
    {
        [Test]
        public void Constructor_InvalidRounds_ShouldThrowArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new DoubleAttackWhenAttacking(0));
        }

        [Test]
        public void ApplyWhenAttacking_NullAttacker_ShouldThrowArgumentNullException()
        {
            DoubleAttackWhenAttacking specialty = new DoubleAttackWhenAttacking(3);
            Mock<ICreaturesInBattle> mockedDefender = new Mock<ICreaturesInBattle>();

            Assert.Throws<ArgumentNullException>(() => specialty.ApplyWhenAttacking(null, mockedDefender.Object));
        }

        [Test]
        public void ApplyWhenAttacking_NullDefender_ShouldThrowArgumentNullException()
        {
            DoubleAttackWhenAttacking specialty = new DoubleAttackWhenAttacking(3);
            Mock<ICreaturesInBattle> mockedAttacker = new Mock<ICreaturesInBattle>();

            Assert.Throws<ArgumentNullException>(() => specialty.ApplyWhenAttacking(null, mockedAttacker.Object));
        }

        [Test]
        public void ApplyWhenAttacking_ValidParameters_ShouldDoubleTheAttackersCurrentAttack()
        {
            DoubleAttackWhenAttacking specialty = new DoubleAttackWhenAttacking(3);
            Mock<ICreaturesInBattle> mockedDefender = new Mock<ICreaturesInBattle>();
            Mock<ICreaturesInBattle> mockedAttacker = new Mock<ICreaturesInBattle>();
            int attackerCurrentAttack = 10;

            mockedAttacker.SetupGet(a => a.CurrentAttack).Returns(attackerCurrentAttack);
            mockedAttacker.SetupSet(a => a.CurrentAttack = It.IsAny<int>()).Callback<int>(v => attackerCurrentAttack = v);

            specialty.ApplyWhenAttacking(mockedAttacker.Object, mockedDefender.Object);
            Assert.AreEqual(20, attackerCurrentAttack);
        }

        [Test]
        public void ToString_ShouldReturnStringWithTypeAndRounds()
        {
            DoubleAttackWhenAttacking doubleAttackWhenAttacking = new DoubleAttackWhenAttacking(1);
            string expected = $"{doubleAttackWhenAttacking.GetType().Name}({1})";
            string actual = doubleAttackWhenAttacking.ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}