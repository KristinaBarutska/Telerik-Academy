namespace ArmyOfCreatures.Tests
{
    using System;
    using System.Reflection;

    using Moq;
    using NUnit.Framework;
    using Logic;
    using Mocks;
    using Extended;
    using System.Collections.Generic;
    using Logic.Battles;
    using Logic.Creatures;

    [TestFixture]
    public class ExtendedBattleManagerTests
    {
        [Test]
        public void Constructor_ValidArguments_ShouldCallParentConstructorAndShouldSetThirdArmyToNewList()
        {
            var factory = new Mock<ICreaturesFactory>();
            var logger = new Mock<ILogger>();
            var manager = new MockedExtendedBattleManager(factory.Object, logger.Object);
            var thirdArmy = typeof(BattleManagerWithThreeArmies)
                .GetField("thirdArmyCreatures", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(manager) as ICollection<ICreaturesInBattle>;

            Assert.IsNotNull(thirdArmy);
        }

        [Test]
        public void AddCreaturesByIdentifier_ValidCreatureWithArmyNumber3_ShouldBeAddedToTheThirdArmy()
        {
            var factory = new Mock<ICreaturesFactory>();
            var logger = new Mock<ILogger>();
            var creatureInBattle = new Mock<ICreaturesInBattle>();
            var manager = new MockedExtendedBattleManager(factory.Object, logger.Object);
            var identifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(3)");

            manager.AddCreaturesByIdentifier_Exposed(identifier, creatureInBattle.Object);

            var thirdArmy = typeof(BattleManagerWithThreeArmies)
                .GetField("thirdArmyCreatures", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(manager) as ICollection<ICreaturesInBattle>;

            Assert.AreEqual(1, thirdArmy.Count);
        }

        [Test]
        public void GetByIdentifier_NullIdentifier_ShouldThrowArgumentNullException()
        {
            var factory = new Mock<ICreaturesFactory>();
            var logger = new Mock<ILogger>();
            var manager = new MockedExtendedBattleManager(factory.Object, logger.Object);

            Assert.Throws<ArgumentNullException>(() => manager.GetByIdentifier_Exposed(null));
        }

        [Test]
        public void GetByIdentifier_IdentifierWithArmyNumber3_ShouldReturnCreaturesInBattleFromThirdArmy()
        {
            var factory = new Mock<ICreaturesFactory>();
            var logger = new Mock<ILogger>();

            factory.Setup(f => f.CreateCreature(It.IsAny<string>())).Returns(new Angel());

            var manager = new MockedExtendedBattleManager(factory.Object, logger.Object);
            var identfier = CreatureIdentifier.CreatureIdentifierFromString("Angel(3)");

            manager.AddCreatures(identfier, 1);

            var result = manager.GetByIdentifier_Exposed(identfier);
            Assert.IsTrue(result.Creature.GetType().Name == "Angel");
        }
    }
}