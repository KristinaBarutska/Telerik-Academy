namespace ArmyOfCreatures.Tests
{
    using System;
    using System.Reflection;
    using System.Collections.Generic;

    using Moq;
    using NUnit.Framework;
    using Logic.Battles;
    using Logic;
    using Logic.Creatures;
    using Mocks;
    
    [TestFixture]
    public class BattleManagerTests
    {
        [Test]
        public void Constructor_ShouldSetAllPrivateFields()
        {
            var logger = new Mock<ILogger>();
            var factory = new Mock<ICreaturesFactory>();
            var manager = new BattleManager(factory.Object, logger.Object);
            
            var firstArmy = typeof(BattleManager)
                .GetField("firstArmyCreatures", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(manager);
            var secondArmy = typeof(BattleManager)
                .GetField("secondArmyCreatures", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(manager);
            var creaturesFactory = typeof(BattleManager)
                .GetField("creaturesFactory", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(manager);
            var managerLogger = typeof(BattleManager)
                .GetField("logger", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(manager);

            Assert.IsTrue(firstArmy != null && secondArmy != null && creaturesFactory != null && managerLogger != null);
        }

        [Test]
        public void AddCreatures_NullIdentifier_ShouldThrowArgumentNulException()
        {
            var logger = new Mock<ILogger>();
            var factory = new Mock<ICreaturesFactory>();
            var manager = new BattleManager(factory.Object, logger.Object);

            Assert.Throws<ArgumentNullException>(() => manager.AddCreatures(null, 1));
        }

        [Test]
        public void AddCreatures_ValidIdentifierWithArmyNumber1_ShouldAddCreatureInFirstArmyCreatures()
        {
            var logger = new Mock<ILogger>();
            var factory = new Mock<ICreaturesFactory>();

            factory.Setup(f => f.CreateCreature(It.IsAny<string>())).Returns(new Angel());

            var manager = new BattleManager(factory.Object, logger.Object);
            var identifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");

            manager.AddCreatures(identifier, 1);

            var firstArmy = typeof(BattleManager)
                .GetField("firstArmyCreatures", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(manager) as ICollection<ICreaturesInBattle>;

            Assert.AreEqual(1, firstArmy.Count);
        }

        [Test]
        public void AddCreatures_ValidIdentifier_LoggerWriteLineShouldBeCalledExactlyOnce()
        {
            var logger = new Mock<ILogger>();
            var factory = new Mock<ICreaturesFactory>();

            factory.Setup(f => f.CreateCreature(It.IsAny<string>())).Returns(new Angel());

            var manager = new BattleManager(factory.Object, logger.Object);
            var identifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");

            manager.AddCreatures(identifier, 1);
            logger.Verify(l => l.WriteLine(It.IsAny<string>()), Times.Once());
        }

        [Test]
        public void Attack_NullAttackerIdentifier_ShouldThrowArgumentNullException()
        {
            var logger = new Mock<ILogger>();
            var factory = new Mock<ICreaturesFactory>();
            var manager = new BattleManager(factory.Object, logger.Object);
            var defender = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");

            Assert.Throws<ArgumentNullException>(() => manager.Attack(null, defender));
        }

        [Test]
        public void Attack_NullDefenderIdentifier_ShouldThrowArgumentNullException()
        {
            var logger = new Mock<ILogger>();
            var factory = new Mock<ICreaturesFactory>();

            factory.Setup(f => f.CreateCreature(It.IsAny<string>())).Returns(new Angel());

            var manager = new BattleManager(factory.Object, logger.Object);
            var attacker = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");

            manager.AddCreatures(attacker, 1);
            Assert.Throws<ArgumentNullException>(() => manager.Attack(attacker, null));
        }

        [Test]
        public void Attack_ValidIdentifiers_ShouldCallLoggerWriteLineExactly6Times()
        {
            var logger = new Mock<ILogger>();
            var factory = new Mock<ICreaturesFactory>();

            factory.Setup(f => f.CreateCreature(It.IsAny<string>())).Returns(new Angel());

            var manager = new BattleManager(factory.Object, logger.Object);
            var attacker = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");
            var defender = CreatureIdentifier.CreatureIdentifierFromString("Angel(2)");

            manager.AddCreatures(attacker, 1);
            manager.AddCreatures(defender, 1);
            manager.Attack(attacker, defender);

            logger.Verify(l => l.WriteLine(It.IsAny<string>()), Times.Exactly(6));
        }

        [Test]
        public void Skip_NullIdentifier_ShouldThrowArgumentNullException()
        {
            var logger = new Mock<ILogger>();
            var factory = new Mock<ICreaturesFactory>();
            var manager = new BattleManager(factory.Object, logger.Object);

            Assert.Throws<ArgumentNullException>(() => manager.Skip(null));
        }

        [Test]
        public void Skip_ValidIdentifier_ShouldCallLoggerWriteLineExactlyThrice()
        {
            var logger = new Mock<ILogger>();
            var factory = new Mock<ICreaturesFactory>();

            factory.Setup(f => f.CreateCreature(It.IsAny<string>())).Returns(new Angel());

            var manager = new BattleManager(factory.Object, logger.Object);
            var identifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");

            manager.AddCreatures(identifier, 1);
            manager.Skip(identifier);
            logger.Verify(l => l.WriteLine(It.IsAny<string>()), Times.Exactly(3));
        }

        // Protected methods
        [Test]
        public void AddCreaturesByIdentifier_NullCreatureIdentifier_ShouldThrowArgumentNullException()
        {
            var logger = new Mock<ILogger>();
            var factory = new Mock<ICreaturesFactory>();
            var creaturesInBattle = new Mock<ICreaturesInBattle>();
            var manager = new MockedBattleManager(factory.Object, logger.Object);

            Assert.Throws<ArgumentNullException>(() => manager.AddCreaturesByIdentifier_Exposed(null, creaturesInBattle.Object));
        }

        [Test]
        public void AddCreaturesByIdentifier_NullCreaturesInBattle_ShouldThrowArgumentNullException()
        {
            var logger = new Mock<ILogger>();
            var factory = new Mock<ICreaturesFactory>();
            var identifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");
            var manager = new MockedBattleManager(factory.Object, logger.Object);

            Assert.Throws<ArgumentNullException>(() => manager.AddCreaturesByIdentifier_Exposed(identifier, null));
        }

        [Test]
        public void AddCreaturesByIdentifier_ValidParameters_IdentifierWith1ArmyNumber_ShouldAddCreatureToFirstArmy()
        {
            var logger = new Mock<ILogger>();
            var factory = new Mock<ICreaturesFactory>();
            var creaturesInBattle = new Mock<ICreaturesInBattle>();
            var identifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");
            var manager = new MockedBattleManager(factory.Object, logger.Object);

            manager.AddCreaturesByIdentifier_Exposed(identifier, creaturesInBattle.Object);

            var firstArmy = typeof(BattleManager)
                .GetField("firstArmyCreatures", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(manager) as ICollection<ICreaturesInBattle>;

            Assert.AreEqual(1, firstArmy.Count);
        }

        [Test]
        public void AddCreaturesByIdentifier_ValidParameters_IdentifierWith2ArmyNumber_ShouldAddCreatureToSecondArmy()
        {
            var logger = new Mock<ILogger>();
            var factory = new Mock<ICreaturesFactory>();
            var creaturesInBattle = new Mock<ICreaturesInBattle>();
            var identifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(2)");
            var manager = new MockedBattleManager(factory.Object, logger.Object);

            manager.AddCreaturesByIdentifier_Exposed(identifier, creaturesInBattle.Object);

            var secondArmy = typeof(BattleManager)
                .GetField("secondArmyCreatures", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(manager) as ICollection<ICreaturesInBattle>;

            Assert.AreEqual(1, secondArmy.Count);
        }

        [Test]
        public void AddCreaturesByIdentifier_IdentifierWithInvalidArmyNumber_ShouldThrowArgumentException()
        {
            var logger = new Mock<ILogger>();
            var factory = new Mock<ICreaturesFactory>();
            var creaturesInBattle = new Mock<ICreaturesInBattle>();
            var identifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(5)");
            var manager = new MockedBattleManager(factory.Object, logger.Object);

            Assert.Throws<ArgumentException>(() => manager.AddCreaturesByIdentifier_Exposed(identifier, creaturesInBattle.Object));
        }

        [Test]
        public void GetByIdentifier_NullIdentifier_ShouldThrowArgumentNullException()
        {
            var logger = new Mock<ILogger>();
            var factory = new Mock<ICreaturesFactory>();
            var manager = new MockedBattleManager(factory.Object, logger.Object);

            Assert.Throws<ArgumentNullException>(() => manager.GetByIdentifier_Exposed(null));
        }

        [Test]
        public void GetByIndetifier_IdentifierWithArmyNumber1_ShouldReturnFoundCreatureFromFirstArmy()
        {
            var logger = new Mock<ILogger>();
            var factory = new Mock<ICreaturesFactory>();

            factory.Setup(f => f.CreateCreature(It.IsAny<string>())).Returns(new Angel());

            var manager = new MockedBattleManager(factory.Object, logger.Object);
            var identifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");

            manager.AddCreatures(identifier, 1);

            var expected = typeof(CreaturesInBattle);
            var actual = manager.GetByIdentifier_Exposed(identifier).GetType();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetByIndetifier_IdentifierWithArmyNumber2_ShouldReturnFoundCreatureFromSecondArmy()
        {
            var logger = new Mock<ILogger>();
            var factory = new Mock<ICreaturesFactory>();

            factory.Setup(f => f.CreateCreature(It.IsAny<string>())).Returns(new Angel());

            var manager = new MockedBattleManager(factory.Object, logger.Object);
            var identifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(2)");

            manager.AddCreatures(identifier, 1);

            var expected = typeof(CreaturesInBattle);
            var actual = manager.GetByIdentifier_Exposed(identifier).GetType();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetByIndetifier_IdentifierWithInvalidArmyNumber_ShouldThrowArgumentException()
        {
            var logger = new Mock<ILogger>();
            var factory = new Mock<ICreaturesFactory>();

            factory.Setup(f => f.CreateCreature(It.IsAny<string>())).Returns(new Angel());

            var manager = new MockedBattleManager(factory.Object, logger.Object);
            var identifierToSearch = CreatureIdentifier.CreatureIdentifierFromString("Angel(7)");
            
            Assert.Throws<ArgumentException>(() => manager.GetByIdentifier_Exposed(identifierToSearch));
        }
    }
}