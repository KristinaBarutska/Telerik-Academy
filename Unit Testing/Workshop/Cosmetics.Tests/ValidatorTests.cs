namespace Cosmetics.Tests
{
    using System;

    using NUnit.Framework;
    using Common;

    [TestFixture]
    public class ValidatorTests
    {
        [Test]
        public void CheckIfNull_NullObject_ShouldThrowNullReferenseException()
        {
            Assert.Throws<NullReferenceException>(() => Validator.CheckIfNull(null));
        }

        [Test]
        public void CheckIfNull_NotNullObject_ShouldNotThrow()
        {
            Assert.DoesNotThrow(() => Validator.CheckIfNull(new object()));
        }

        [TestCase(null)]
        [TestCase("")]
        public void CheckIfStringIsNullOrEmpty_NullOrEmptyText_ShouldThrowNullReferenseException(string text)
        {
            Assert.Throws<NullReferenceException>(() => Validator.CheckIfStringIsNullOrEmpty(text));
        }

        [Test]
        public void CheckIfStringIsNullOrEmpty_NotNullOrEmptyString_ShouldNotThrow()
        {
            Assert.DoesNotThrow(() => Validator.CheckIfStringIsNullOrEmpty("text"));
        }

        [TestCase("a")]
        [TestCase("aaaaaaaaaaa")]
        public void CheckIfStringLengthIsValid_InvalidTextLength_ShouldThrowIndexOutOfRangeException(string text)
        {
            Assert.Throws<IndexOutOfRangeException>(() => Validator.CheckIfStringLengthIsValid(text, 10, 2));
        }

        [Test]
        public void CheckIfStringLengthIsValid_ValidTextLength_ShouldNotThrow()
        {
            Assert.DoesNotThrow(() => Validator.CheckIfStringLengthIsValid("abcd", 10, 2));
        }
    }
}