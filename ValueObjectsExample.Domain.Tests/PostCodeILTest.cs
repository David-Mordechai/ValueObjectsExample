using System;
using ValueObjectsExample.Domain.ValueObjects;
using Xunit;

namespace ValueObjectsExample.Domain.Tests
{
    public class PostCodeILTest
    {
        [Fact]
        public void PostCodeILTypeShouldExceptIntValue()
        {
            PostCodeIL postCode = 1234567;
            Assert.Equal(1234567, (int)postCode);
        }

        [Theory]
        [InlineData(-123456)]
        public void PostCodeILShouldPositiveNumber(int code)
        {
            Assert.Throws<Exception>(() => (PostCodeIL)code);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(123)]
        [InlineData(123456)]
        [InlineData(12345678)]
        [InlineData(-123456)]
        public void PostCodeILShouldThrowExceptionIfPostCodeNot7DigitLong(int code)
        {
            Assert.Throws<Exception>(() => (PostCodeIL)code);
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData(1234567, 1234567)]
        public void SameTwoPostCodes_EquelEquel_ShouldBeTrue(int? left, int? right)
        {
            PostCodeIL postCodeIL_left = left;
            PostCodeIL postCodeIL_right = right;
            Assert.True(postCodeIL_left == postCodeIL_right);
        }

        [Theory]
        [InlineData(1234566, 1234567)]
        public void DifferentTwoPostCodes_NotEquel_ShouldBeTrue(int? left, int? right)
        {
            PostCodeIL postCodeIL_left = left;
            PostCodeIL postCodeIL_right = right;
            Assert.True(postCodeIL_left != postCodeIL_right);
        }
    }
}
