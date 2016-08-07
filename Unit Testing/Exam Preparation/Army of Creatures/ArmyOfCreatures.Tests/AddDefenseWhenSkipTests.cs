namespace ArmyOfCreatures.Tests
{
    using System;
    using System.Reflection;

    using NUnit.Framework;
    using Logic.Specialties;
    using Logic.Battles;
    using Logic.Creatures;

    [TestFixture]
    public class AddDefenseWhenSkipTests
    {
        [TestCase(0)]
        [TestCase(21)]
        public void Constructor_InvalidDefenseToAdd_ShouldThrowArgumentOutOfRangeException(int defenseToAdd)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new AddDefenseWhenSkip(defenseToAdd));
        }

        [Test]
        public void Constructor_ValidDefenseToAdd_ShouldSetDefenseToAddToThePassedValue()
        {
            var specialty = new AddDefenseWhenSkip(5);
            var defenseToAdd = (int)typeof(AddDefenseWhenSkip)
                .GetField("defenseToAdd", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(specialty);

            Assert.AreEqual(5, defenseToAdd);
        }

        [Test]
        public void ApplyOnSkip_NullSkipCreature_ShouldThrowArgumentNullException()
        {
            var specialty = new AddDefenseWhenSkip(5);
            Assert.Throws<ArgumentNullException>(() => specialty.ApplyOnSkip(null));
        }

        [Test]
        public void ApplyOnSkip_ValidSkipCreature_ShouldAddDefenseToAddToSkipCreaturesPermanentDefense()
        {
            var specialty = new AddDefenseWhenSkip(5);
            var angel = new Angel();
            var skipCreature = new CreaturesInBattle(angel, 1);
            var permanentDefenseBeforeAdd = skipCreature.PermanentDefense;

            specialty.ApplyOnSkip(skipCreature);
            Assert.AreEqual(permanentDefenseBeforeAdd + 5, skipCreature.PermanentDefense);
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