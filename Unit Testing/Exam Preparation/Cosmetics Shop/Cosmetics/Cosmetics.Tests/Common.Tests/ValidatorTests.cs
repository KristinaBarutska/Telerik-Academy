namespace Cosmetics.Tests.Common.Tests
{
    using System;

    using NUnit.Framework;
    using Cosmetics.Common;

    [TestFixture]
    public class ValidatorTests
    {
        [Test]
        public void CheckIfNull_NullObject_ShouldThrowNullReferenseException()
        {
            Assert.Throws<NullReferenceException>(() => Validator.CheckIfNull(null));
        }

        [Test]
        public void CheckIfNull_ValidObject_ShouldNotThrowAnyExceptions()
        {
            Assert.DoesNotThrow(() => Validator.CheckIfNull(new object()));
        }

        [TestCase("")]
        [TestCase(null)]
        public void CheckIfStringIsNullOrEmpty_NullOrEmptyString_ShouldThrowNullReferenceException(string param)
        {
            Assert.Throws<NullReferenceException>(() => Validator.CheckIfStringIsNullOrEmpty(param));
        }

        [Test]
        public void CheckIfStringIsNullOrEmpty_NotNullOrEmptyString_ShouldNotThrow()
        {
            Assert.DoesNotThrow(() => Validator.CheckIfStringIsNullOrEmpty("Gabriel"));
        }

        [TestCase("abc", 5, 10)]
        [TestCase("abcabcabcabc", 5, 10)]
        public void CheckIfStringLengthIsValid_InvalidText_ShouldThrowIndexOutOfRangeException(string text, int min, int max)
        {
            Assert.Throws<IndexOutOfRangeException>(() => Validator.CheckIfStringLengthIsValid(text, max, min));
        }

        [Test]
        public void CheckIfStringLengthIsValid_ValidText_ShouldNotThrowAnyExceptions()
        {
            Assert.DoesNotThrow(() => Validator.CheckIfStringLengthIsValid("Gabriel", 10, 2));
        }
    }
}