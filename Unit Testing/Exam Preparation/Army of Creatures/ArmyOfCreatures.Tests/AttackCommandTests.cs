namespace ArmyOfCreatures.Tests
{
    using System;

    using NUnit.Framework;
    using Moq;
    using Logic.Battles;
    using Console.Commands;

    [TestFixture]
    public class AttackCommandTests
    {
        [Test]
        public void ProcessCommand_NullBattleManager_ShouldThrowArgumentNullException()
        {
            AttackCommand attackCommand = new AttackCommand();

            Assert.Throws<ArgumentNullException>(() => attackCommand.ProcessCommand(null, "string", "string"));
        }

        [Test]
        public void ProcessCommand_NullArguments_ShouldThrowArgumentNullException()
        {
            AttackCommand attackCommand = new AttackCommand();
            Mock<IBattleManager> mockedBattleManager = new Mock<IBattleManager>();

            Assert.Throws<ArgumentNullException>(() => attackCommand.ProcessCommand(mockedBattleManager.Object, null));
        }

        [Test]
        public void ProcessCommand_InvalidArgumentsLength_ShouldThrowArgumentException()
        {
            AttackCommand attackCommand = new AttackCommand();
            Mock<IBattleManager> mockedBattleManager = new Mock<IBattleManager>();

            Assert.Throws<ArgumentException>(() => attackCommand.ProcessCommand(mockedBattleManager.Object, "string"));
        }

        [Test]
        public void ProcessCommand_ValidParameters_ShouldCallBattleManagersAttack()
        {
            AttackCommand attackCommand = new AttackCommand();
            Mock<IBattleManager> mockedBattleManager = new Mock<IBattleManager>();

            attackCommand.ProcessCommand(mockedBattleManager.Object, "Angel(1)", "Goblin(2)");
            mockedBattleManager
                .Verify(b => b.Attack(It.IsAny<CreatureIdentifier>(), It.IsAny<CreatureIdentifier>()), Times.Exactly(1));
        }
    }
}