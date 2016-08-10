namespace IntergalacticTravel.Tests
{
    using System;

    using Moq;
    using NUnit.Framework;
    using Exceptions;

    [TestFixture]
    public class UnitsFactoryTests
    {
        [Test]
        public void GetUnit_ValidProcyonCommand_ShouldReturnNewProcyon()
        {
            var factory = new UnitsFactory();
            var procyon = factory.GetUnit("create unit Procyon Gosho 1") as Procyon;

            Assert.IsNotNull(procyon);
        }

        [Test]
        public void GetUnit_ValidLuytenCommand_ShouldReturnNewLuyten()
        {
            var factory = new UnitsFactory();
            var procyon = factory.GetUnit("create unit Luyten Pesho 2") as Luyten;

            Assert.IsNotNull(procyon);
        }

        [Test]
        public void GetUnit_ValidLacailleCommand_ShouldReturnNewLacaille()
        {
            var factory = new UnitsFactory();
            var procyon = factory.GetUnit("create unit Lacaille Tosho 3") as Lacaille;

            Assert.IsNotNull(procyon);
        }

        [TestCase(null)]
        [TestCase("create                ")]
        [TestCase("")]
        public void GetUnit_InvalidCommand_ShouldThrowInvalidUnitCreationCommandException(string command)
        {
            var factory = new UnitsFactory();
            Assert.Throws<InvalidUnitCreationCommandException>(() => factory.GetUnit(command));
        }
    }
}
