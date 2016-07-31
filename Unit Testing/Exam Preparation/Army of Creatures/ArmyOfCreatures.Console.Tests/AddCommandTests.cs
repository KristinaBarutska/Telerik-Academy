namespace ArmyOfCreatures.Console.Tests
{
    using System;

    using NUnit.Framework;
    using Moq;
    using Commands;
    using Logic.Battles;

    [TestFixture]
    public class AddCommandTests
    {
        [Test]
        public void ProcessCommand_NullBattleManager_ShouldThrowArgumentNullException()
        {
            AddCommand addCommand = new AddCommand();

            Assert.Throws<ArgumentNullException>(() => addCommand.ProcessCommand(null, "string"));
        }

        [Test]
        public void ProcessCommand_NullArguments_ShouldThrowArgumentNullException()
        {
            AddCommand addCommand = new AddCommand();
            Mock<IBattleManager> mockedBattleManager = new Mock<IBattleManager>();

            Assert.Throws<ArgumentNullException>(() => addCommand.ProcessCommand(mockedBattleManager.Object, null));
        }

        [Test]
        public void ProcessCommand_InvalidArgumentsLength_ShouldThrowArgumentException()
        {
            AddCommand addCommand = new AddCommand();
            Mock<IBattleManager> mockedBattleManager = new Mock<IBattleManager>();

            Assert.Throws<ArgumentException>(() => addCommand.ProcessCommand(mockedBattleManager.Object, "string"));
        }

        [Test]
        public void ProcessCommand_ValidParameters_ShouldCallBattleManagersAddCreatures()
        {
            AddCommand addCommand = new AddCommand();
            Mock<IBattleManager> mockedBattleManager = new Mock<IBattleManager>();

            addCommand.ProcessCommand(mockedBattleManager.Object, "1", "Angel(1)");
            mockedBattleManager.Verify(b => b.AddCreatures(It.IsAny<CreatureIdentifier>(), It.IsAny<int>()), Times.Exactly(1));
        }
    }
}
