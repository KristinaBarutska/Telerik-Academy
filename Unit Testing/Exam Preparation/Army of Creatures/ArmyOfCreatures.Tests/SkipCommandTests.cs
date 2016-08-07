namespace ArmyOfCreatures.Tests
{
    using System;

    using NUnit.Framework;
    using Moq;
    using Logic.Battles;
    using Console.Commands;

    [TestFixture]
    public class SkipCommandTests
    {
        [Test]
        public void ProcessCommand_NullBattleManager_ShouldThrowArgumentNullException()
        {
            SkipCommand skipCommand = new SkipCommand();

            Assert.Throws<ArgumentNullException>(() => skipCommand.ProcessCommand(null, "string"));
        }

        [Test]
        public void ProcessCommand_NullArguments_ShouldThrowArgumentNullException()
        {
            SkipCommand skipCommand = new SkipCommand();
            Mock<IBattleManager> mockedBattleManager = new Mock<IBattleManager>();

            Assert.Throws<ArgumentNullException>(() => skipCommand.ProcessCommand(mockedBattleManager.Object, null));
        }

        [Test]
        public void ProcessCommand_InvalidArgumentsLength_ShouldThrowArgumentException()
        {
            SkipCommand skipCommand = new SkipCommand();
            Mock<IBattleManager> mockedBattleManager = new Mock<IBattleManager>();

            Assert.Throws<ArgumentException>(() => skipCommand.ProcessCommand(mockedBattleManager.Object, new string[] { }));
        }

        [Test]
        public void ProcessCommand_ValidParameters_ShouldCallBattleManagersSkip()
        {
            SkipCommand skipCommand = new SkipCommand();
            Mock<IBattleManager> mockedBattleManager = new Mock<IBattleManager>();

            skipCommand.ProcessCommand(mockedBattleManager.Object, "Angel(1)");
            mockedBattleManager.Verify(b => b.Skip(It.IsAny<CreatureIdentifier>()), Times.Exactly(1));
        }
    }
}