namespace ArmyOfCreatures.Tests
{
    using System;

    using NUnit.Framework;
    using Logic.Specialties;
    using Logic.Battles;
    using Moq;
    [TestFixture]
    public class DoubleDefenseWhenDefendingTests
    {
        [Test]
        public void Constructor_InvalidRounds_ShouldThrowArgumentOutOfRangeException()
        {
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => new DoubleDefenseWhenDefending(0));
        }

        [Test]
        public void ApplyWhenDefending_NullDefender_ShouldThrowArgumentNullException()
        {
            var doubleDefenseWhenDefending = new DoubleDefenseWhenDefending(1);

            Assert.Throws(typeof(ArgumentNullException), () => doubleDefenseWhenDefending.ApplyWhenDefending(null, null));
        }

        [Test]
        public void ApplyWhenDefending_NullAttacker_ShouldThrowArgumentNullException()
        {
            var doubleDefenseWhenDefending = new DoubleDefenseWhenDefending(1);
            var mockedDefender = new Mock<ICreaturesInBattle>().Object;

            Assert.Throws(typeof(ArgumentNullException), () => doubleDefenseWhenDefending.ApplyWhenDefending(mockedDefender, null));
        }

        [Test]
        public void ApplyWhenDefending_ValidAttackerAndDefender_ShouldDoubleDefendersCurrentDefense()
        {
            var doubleDefenseWhenDefending = new DoubleDefenseWhenDefending(1);
            var mockedAttacker = new Mock<ICreaturesInBattle>().Object;
            var mockedDefender = new Mock<ICreaturesInBattle>();
            int mockedDefenderCurrentDefense = 2;

            mockedDefender.SetupGet(d => d.CurrentDefense).Returns(mockedDefenderCurrentDefense);
            mockedDefender.SetupSet(d => d.CurrentDefense = It.IsAny<int>())
                .Callback<int>(v => mockedDefenderCurrentDefense = v);

            doubleDefenseWhenDefending.ApplyWhenDefending(mockedDefender.Object, mockedAttacker);
            Assert.AreEqual(4, mockedDefenderCurrentDefense);
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