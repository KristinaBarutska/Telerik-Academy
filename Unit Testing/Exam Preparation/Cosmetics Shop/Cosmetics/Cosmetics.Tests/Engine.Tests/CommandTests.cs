namespace Cosmetics.Tests.Engine
{
    using System;

    using NUnit.Framework;
    using Cosmetics.Engine;

    [TestFixture]
    public class CommandTests
    {
        [Test]
        public void Parse_ValidString_ShouldReturnNewCommand()
        {
            var command = Command.Parse("ShowCategory ForMale");
            Assert.IsTrue(command.Name == "ShowCategory" && command.Parameters.Count == 1);
        }

        [Test]
        public void Parse_NullCommandString_ShouldThrowNullReferenseException()
        {
            Assert.Throws<NullReferenceException>(() => Command.Parse(null));
        }

        [Test]
        public void Parse_NullOrEmptyStringForName_ShouldThrowExceptionWithMessageThatContainsTheStringName()
        {
            try
            {
                Command.Parse("       ForMale");
            }
            catch (ArgumentNullException e)
            {
                Assert.IsTrue(e.Message.Contains("Name"));
            }
            catch
            {
                Assert.Fail();
            }
        }

        [Test]
        public void Parse_NullOrEmptyStringForParameters_ShouldThrowExceptionWithMessageThatContainsTheStringList()
        {
            try
            {
                Command.Parse("ShowCategory          ");
            }
            catch (ArgumentNullException e)
            {
                Assert.IsTrue(e.Message.Contains("List"));
            }
            catch
            {
                Assert.Fail();
            }
        }
    }
}