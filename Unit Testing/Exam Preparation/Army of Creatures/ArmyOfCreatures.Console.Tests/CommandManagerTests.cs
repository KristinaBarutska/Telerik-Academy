namespace ArmyOfCreatures.Console.Tests
{
    using System;

    using NUnit.Framework;
    using Moq;
    using Commands;
    using Logic.Battles;

    [TestFixture]
    public class CommandManagerTests
    {
        [Test]
        public void ProcessCommand_NullCommandLine_ShouldThrowArgumentNullException()
        {
            CommandManager commandManager = new CommandManager();
            Mock<IBattleManager> mockedBattleManager = new Mock<IBattleManager>();

            Assert.Throws<ArgumentNullException>(() => commandManager.ProcessCommand(null, mockedBattleManager.Object));
        }
        [Test]
        public void ProcessCommand_InvalidCommandLine_ShouldThrowArgumentException()
        {
            CommandManager commandManager = new CommandManager();
            Mock<IBattleManager> mockedBattleManager = new Mock<IBattleManager>();

            Assert.Throws<ArgumentException>(() => commandManager.ProcessCommand("tralala", mockedBattleManager.Object));
        }
    }
}