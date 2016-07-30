namespace ArmyOfCreatures.Tests
{
    using System;

    using NUnit.Framework;
    using Logic.Battles;

    [TestFixture]
    public class CreatureIdentifierTests
    {
        [Test]
        public void CreatureIdentifierFromString_NullValueToParse_ShouldThrowArgumentNullException()
        {
            Assert.Throws(typeof(ArgumentNullException), () => CreatureIdentifier.CreatureIdentifierFromString(null));
        }

        [Test]
        public void CreatureIdentifierFromString_ValidValueToParse_ShouldReturnNewCreatureIdentifier()
        {
            Assert.IsTrue(CreatureIdentifier.CreatureIdentifierFromString("Goblin(1)").GetType().Name == "CreatureIdentifier");
        }

        [Test]
        public void ToString_ShouldReturnStringWithCreatureTypeAndArmyNumber()
        {
            var identifier = CreatureIdentifier.CreatureIdentifierFromString("Goblin(1)");

            Assert.AreEqual("Goblin(1)", identifier.ToString());
        }
    }
}