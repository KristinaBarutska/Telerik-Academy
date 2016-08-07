namespace ArmyOfCreatures.Tests
{
    using System;
    using System.Reflection;

    using NUnit.Framework;
    using Moq;
    using Extended.Specialties;
    using Logic.Battles;

    [TestFixture]
    public class DoubleAttackWhenAttackingTests
    {
        [Test]
        public void Constructor_InvalidRounds_ShouldThrowArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new DoubleAttackWhenAttacking(-100));
        }

        [Test]
        public void Constructor_ValidRounds_ShouldSetThisRoundsToThePassedValue()
        {
            var specialty = new DoubleAttackWhenAttacking(5);
            var roundsField = (int)typeof(DoubleAttackWhenAttacking)
                .GetField("rounds", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(specialty);

            Assert.AreEqual(5, roundsField);
        }

        [Test]
        public void ApplyWhenAttacking_NullAttacker_ShouldThrowArgumentNullException()
        {
            var specialty = new DoubleAttackWhenAttacking(5);
            var defender = new Mock<ICreaturesInBattle>();

            Assert.Throws<ArgumentNullException>(() => specialty.ApplyWhenAttacking(null, defender.Object));
        }

        [Test]
        public void ApplyWhenAttacking_NullDefender_ShouldThrowArgumentNullException()
        {
            var specialty = new DoubleAttackWhenAttacking(5);
            var attacker = new Mock<ICreaturesInBattle>();

            Assert.Throws<ArgumentNullException>(() => specialty.ApplyWhenAttacking(attacker.Object, null));
        }

        [Test]
        public void ApplyWhenAttacking_WhenRoundsAreLessThan0JustReturnAndDoesNotModifyDefender()
        {
            var specialty = new DoubleAttackWhenAttacking(5);
            var attacker = new Mock<ICreaturesInBattle>();
            var defender = new Mock<ICreaturesInBattle>();
            int attackerCurrentAttack = 10;

            attacker.SetupGet(a => a.CurrentAttack).Returns(attackerCurrentAttack);
            attacker.SetupSet(a => a.CurrentAttack = It.IsAny<int>()).Callback<int>(v => attackerCurrentAttack = v);

            typeof(DoubleAttackWhenAttacking)
                .GetField("rounds", BindingFlags.NonPublic | BindingFlags.Instance)
                .SetValue(specialty, -1);

            Assert.AreEqual(10, attackerCurrentAttack);
        }


        [Test]
        public void ApplyWhenAttacking_ValidParameters_AttackersCurretnAttackShouldBeDoubled()
        {
            var specialty = new DoubleAttackWhenAttacking(5);
            var attacker = new Mock<ICreaturesInBattle>();
            var defender = new Mock<ICreaturesInBattle>();
            int attackerCurrentAttack = 10;

            attacker.SetupGet(a => a.CurrentAttack).Returns(attackerCurrentAttack);
            attacker.SetupSet(a => a.CurrentAttack = It.IsAny<int>()).Callback<int>(v => attackerCurrentAttack = v);
            specialty.ApplyWhenAttacking(attacker.Object, defender.Object);

            Assert.AreEqual(20, attackerCurrentAttack);
        }

        [Test]
        public void ToString_ShouldReturnStringWithTypeAndRounds()
        {
            var doubleAttackWhenAttacking = new DoubleAttackWhenAttacking(1);
            string expected = $"{doubleAttackWhenAttacking.GetType().Name}({1})";
            string actual = doubleAttackWhenAttacking.ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}