namespace ArmyOfCreatures.Tests
{
    using System;

    using Extended.Creatures;
    using Logic;
    using Logic.Battles;
    using Logic.Creatures;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class BattleManagerTests
    {
        [Test]
        public void AddCreature_NullCreatureIdentifier_ShouldThrowArgumentNullException()
        {
            var mockedFactory = new Mock<ICreaturesFactory>();
            var mockedLogger = new Mock<ILogger>();
            var battleManager = new BattleManager(mockedFactory.Object, mockedLogger.Object);

            Assert.Throws(typeof(ArgumentNullException), () => battleManager.AddCreatures(null, 1));
        }

        [Test]
        public void AddCreature_ValidIdentifier_ShouldCallCreateCreature()
        {
            var mockedFactory = new Mock<ICreaturesFactory>();

            mockedFactory.Setup(f => f.CreateCreature(It.IsAny<string>())).Returns(new Angel());

            var mockedLogger = new Mock<ILogger>();
            var battleManager = new BattleManager(mockedFactory.Object, mockedLogger.Object);
            var identifier = CreatureIdentifier.CreatureIdentifierFromString("AncientBehemoth(1)");

            battleManager.AddCreatures(identifier, 1);
            mockedFactory.Verify(f => f.CreateCreature(It.IsAny<string>()), Times.Exactly(1));
        }

        [Test]
        public void AddCreature_ValidIdentifier_LoggerWritelineShouldBeCalled()
        {
            var mockedFactory = new Mock<ICreaturesFactory>();

            mockedFactory.Setup(f => f.CreateCreature(It.IsAny<string>())).Returns(new Angel());

            var mockedLogger = new Mock<ILogger>();

            mockedLogger.Setup(l => l.WriteLine(It.IsAny<string>())).Verifiable();

            var battleManager = new BattleManager(mockedFactory.Object, mockedLogger.Object);
            var identifier = CreatureIdentifier.CreatureIdentifierFromString("AncientBehemoth(1)");

            battleManager.AddCreatures(identifier, 1);
            mockedLogger.Verify(l => l.WriteLine(It.IsAny<string>()), Times.Exactly(1));
        }

        [Test]
        public void Attack_NullAttackerIdentifier_ShouldThrowArgumentNullException()
        {
            var mockedFactory = new Mock<ICreaturesFactory>();
            var mockedLogger = new Mock<ILogger>();
            var battleManager = new BattleManager(mockedFactory.Object, mockedLogger.Object);

            Assert.Throws(typeof(ArgumentNullException), () => battleManager.Attack(null, null));
        }

        [Test]
        public void Attack_NullDefenderIdentifier_ShouldThrowArgumentNullException()
        {
            var mockedFactory = new Mock<ICreaturesFactory>();

            mockedFactory.Setup(f => f.CreateCreature(It.IsAny<string>())).Returns(new Goblin());

            var mockedLogger = new Mock<ILogger>();
            var battleManager = new BattleManager(mockedFactory.Object, mockedLogger.Object);
            var attackerIdentifier = CreatureIdentifier.CreatureIdentifierFromString("Goblin(1)");

            battleManager.AddCreatures(attackerIdentifier, 1);
            Assert.Throws(typeof(ArgumentNullException), () => battleManager.Attack(attackerIdentifier, null));
        }

        [Test]
        public void Attack_ValidIdentifiers_ShouldCallLoggerWriteLineTwoTimesForAddingCreatureAndFourTimesForCreaturesInfo()
        {
            var mockedFactory = new Mock<ICreaturesFactory>();
            var mockedLogger = new Mock<ILogger>();

            mockedFactory.Setup(f => f.CreateCreature(It.IsAny<string>())).Returns(new Goblin());
            mockedLogger.Setup(l => l.WriteLine(It.IsAny<string>())).Verifiable();

            var battleManager = new BattleManager(mockedFactory.Object, mockedLogger.Object);
            var attackerIdentifier = CreatureIdentifier.CreatureIdentifierFromString("Goblin(1)");
            var defenderIdentifier = CreatureIdentifier.CreatureIdentifierFromString("Goblin(2)");

            battleManager.AddCreatures(attackerIdentifier, 1);
            battleManager.AddCreatures(defenderIdentifier, 1);
            battleManager.Attack(attackerIdentifier, defenderIdentifier);
            mockedLogger.Verify(l => l.WriteLine(It.IsAny<string>()), Times.Exactly(6));
        }

        [Test]
        public void Skip_NullIdentifier_ShouldThrowArgumentNullException()
        {
            var mockedFactory = new Mock<ICreaturesFactory>();
            var mockedLogger = new Mock<ILogger>();
            var battleManager = new BattleManager(mockedFactory.Object, mockedLogger.Object);

            Assert.Throws(typeof(ArgumentNullException), () => battleManager.Skip(null));
        }

        [Test]
        public void ValidIdentifier_ShouldCallLoggerWriteLineOnceForAddingCreatureAndTwiceToLogCreatureInfo()
        {
            var mockedFactory = new Mock<ICreaturesFactory>();
            var mockedLogger = new Mock<ILogger>();

            mockedFactory.Setup(f => f.CreateCreature(It.IsAny<string>())).Returns(new Goblin());
            mockedLogger.Setup(l => l.WriteLine(It.IsAny<string>())).Verifiable();

            var battleManager = new BattleManager(mockedFactory.Object, mockedLogger.Object);
            var identifier = CreatureIdentifier.CreatureIdentifierFromString("Goblin(1)");

            battleManager.AddCreatures(identifier, 1);
            battleManager.Skip(identifier);
            mockedLogger.Verify(l => l.WriteLine(It.IsAny<string>()), Times.Exactly(3));
        }
    }
}
