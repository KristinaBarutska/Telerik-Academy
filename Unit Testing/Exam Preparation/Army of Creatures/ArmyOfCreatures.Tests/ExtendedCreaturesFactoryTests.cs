namespace ArmyOfCreatures.Tests
{
    using NUnit.Framework;
    using Moq;
    using Extended;

    [TestFixture]
    public class ExtendedCreaturesFactoryTests
    {
        [TestCase("AncientBehemoth")]
        [TestCase("CyclopsKing")]
        [TestCase("Goblin")]
        [TestCase("Griffin")]
        [TestCase("WolfRaider")]
        public void CreateCreature_ValidName_ShouldReturnNewCreature(string name)
        {
            var factory = new ExtendedCreaturesFactory();
            Assert.AreEqual(name, factory.CreateCreature(name).GetType().Name);
        }
    }
}