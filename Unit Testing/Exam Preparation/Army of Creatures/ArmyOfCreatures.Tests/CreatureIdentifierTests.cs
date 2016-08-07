namespace ArmyOfCreatures.Tests
{
    using System;
    using System.Reflection;

    using NUnit.Framework;
    using Logic.Battles;
    using Moq;
    using Moq.Protected;

    [TestFixture]
    public class CreatureIdentifierTests
    {
        [Test]
        public void CreatureIdentifierFromString_NullString_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => CreatureIdentifier.CreatureIdentifierFromString(null));
        }

        [Test]
        public void CreatureIdentifierFromString_ValidString_ShouldReturnNewIdentifier()
        {
            var identifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");
            Assert.IsTrue(identifier.CreatureType == "Angel" && identifier.ArmyNumber == 1);
        }

        [Test]
        public void ToString_ShouldReturnStringWithCreatureTypeAndArmyNumber()
        {
            var identifier = CreatureIdentifier.CreatureIdentifierFromString("Goblin(1)");
            Assert.AreEqual("Goblin(1)", identifier.ToString());
        }
    }
}