namespace ArmyOfCreatures.Tests
{
    using System;

    using NUnit.Framework;
    using Logic;

    public class CreaturesFactoryTests
    {
        [TestCase("Angel")]
        [TestCase("Archangel")]
        [TestCase("ArchDevil")]
        [TestCase("Behemoth")]
        [TestCase("Devil")]
        public void CreateCreature_ValidName_ShouldReturnNewCreature(string name)
        {
            var factory = new CreaturesFactory();
            Assert.DoesNotThrow(() => factory.CreateCreature(name));
        }

        [Test]
        public void CreateCreature_InvalidName_ShouldThrowArgumentException()
        {
            var factory = new CreaturesFactory();
            Assert.Throws<ArgumentException>(() => factory.CreateCreature("Evlogi"));
        }
    }
}