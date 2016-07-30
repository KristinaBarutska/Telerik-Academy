namespace ArmyOfCreatures.Tests
{
    using System;

    using ArmyOfCreatures.Logic;
    using NUnit.Framework;

    [TestFixture]
    public class CreaturesFactoryTests
    {
        [TestCase("Angel")]
        [TestCase("Archangel")]
        [TestCase("ArchDevil")]
        [TestCase("Behemoth")]
        [TestCase("Devil")]
        public void CreateCreature_PassValidName_ShouldReturnValidCreature(string name)
        {
            var factory = new CreaturesFactory();

            var creature = factory.CreateCreature(name);

            Assert.AreEqual(name, creature.GetType().Name);
        }

        [Test]
        public void CreateCreature_PassInvalidName_ShouldThrowArgumentException()
        {
            var factory = new CreaturesFactory();
            string name = "dsadas";

            Assert.Throws<ArgumentException>(() => factory.CreateCreature(name));
        }
    }
}