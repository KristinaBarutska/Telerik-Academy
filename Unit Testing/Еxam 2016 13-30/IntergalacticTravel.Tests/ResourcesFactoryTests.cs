namespace IntergalacticTravel.Tests
{
    using System;

    using NUnit.Framework;
    using Moq;

    [TestFixture]
    public class ResourcesFactoryTests
    {
        [TestCase("create resources gold(20) silver(30) bronze(40)")]
        [TestCase("create resources gold(20) bronze(40) silver(30)")]
        [TestCase("create resources silver(30) bronze(40) gold(20)")]
        [TestCase("create resources silver(30) gold(20) bronze(40)")]
        [TestCase("create resources bronze(40) gold(20) silver(30)")]
        [TestCase("create resources bronze(40) silver(30) gold(20)")]
        public void GetResources_ValidCommandNoMatterWhatIsTheOrderOfParams_ShouldReturnNewResource(string command)
        {
            var factory = new ResourcesFactory();
            var resource = factory.GetResources(command);

            Assert.IsTrue(
                (resource.BronzeCoins >= 20 && resource.BronzeCoins <= 40) &&
                (resource.SilverCoins >= 20 && resource.SilverCoins <= 40) &&
                (resource.GoldCoins >= 20 && resource.GoldCoins <= 40));
        }

        [TestCase("create resources x y z")]
        [TestCase("tansta resources a b")]
        [TestCase("")]
        [TestCase(null)]
        [TestCase("absolutelyRandomStringThatMustNotBeAValidCommand")]
        public void GetResources_InvalidFormatCommand_ShouldThrowInvalidOperationExceptionWithTheWordCommandInTheMessage(string command)
        {
            var factory = new ResourcesFactory();

            try
            {
                factory.GetResources(command);
            }
            catch (InvalidOperationException e)
            {
                Assert.IsTrue(e.Message.Contains("command"));
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestCase("create resources silver(10) gold(97853252356623523532) bronze(20)")]
        [TestCase("create resources silver(555555555555555555555555555555555) gold(97853252356623523532999999999) bronze(20)")]
        [TestCase("create resources silver(10) gold(20) bronze(4444444444444444444444444444444444444)")]
        public void GetResources_ValidFormatCommandButOutOfRangeParameters_ShouldThrowOverflowException(string command)
        {
            var factory = new ResourcesFactory();
            Assert.Throws<OverflowException>(() => factory.GetResources(command));
        }
    }
}