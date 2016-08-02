namespace Cosmetics.Tests
{
    using System;

    using NUnit.Framework;
    using Engine;

    [TestFixture]
    public class CommandTests
    {
        [Test]
        public void Parse_ValidCommandString_ShouldReturnNewCommand()
        {
            Assert.DoesNotThrow(() => Command.Parse("CreateCategory ForMale"));
        }

        [Test]
        public void Parse_ValidCommandString_ShouldSetNameAndParameters()
        {
            Command command = Command.Parse("CreateCategory ForMale");
            Assert.IsTrue(command.Name == "CreateCategory" && command.Parameters.Count == 1);
        }

        [Test]
        public void Parse_NullOrEmptyStringForName_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => Command.Parse("  ForMale"));
        }

        [Test]
        public void Parse_NullOrEmptyStringForParameters_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => Command.Parse("ForMale     "));
        }
    }
}