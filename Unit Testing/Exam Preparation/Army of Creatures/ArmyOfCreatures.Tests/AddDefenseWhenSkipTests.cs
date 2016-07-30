namespace ArmyOfCreatures.Tests
{
    using System;

    using NUnit.Framework;
    using Logic.Specialties;
    using Logic.Battles;
    using Logic.Creatures;

    [TestFixture]
    public class AddDefenseWhenSkipTests
    {
        [TestCase(-100)]
        [TestCase(100)]
        public void Constructor_InvalidDefenseToAdd_ShouldThrowArgumentOutOfRangeException(int defenseToAdd)
        {
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => new AddDefenseWhenSkip(defenseToAdd));
        }

        [Test]
        public void ApplyOnSkip_NullCreature_ShouldThrowArgumentNullException()
        {
            var addDefenseWhenSkip = new AddDefenseWhenSkip(10);

            Assert.Throws(typeof(ArgumentNullException), () => addDefenseWhenSkip.ApplyOnSkip(null));
        }

        [Test]
        public void ApplyOnSkip_ValidCreature_ShouldAddDefenseToAddToCreaturesPermanentDefense()
        {
            var addDefenseWhenSkip = new AddDefenseWhenSkip(10);
            var creature = new Angel();
            var creatureInBattle = new CreaturesInBattle(creature, 1);

            int expected = creatureInBattle.PermanentDefense + 10;
            addDefenseWhenSkip.ApplyOnSkip(creatureInBattle);
            int actual = creatureInBattle.PermanentDefense;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToString_ShouldReturnStringWithTypeAndDefenseToAdd()
        {
            var addDefenseWhenSkip = new AddDefenseWhenSkip(10);
            string expected = $"{addDefenseWhenSkip.GetType().Name}({10})";
            string actual = addDefenseWhenSkip.ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}