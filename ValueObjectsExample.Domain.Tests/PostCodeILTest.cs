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
            Assert.True(postCode == 1234567);
            Assert.True(1234567.Equals(postCode));
        }

        [Fact]
        public void ValidPostCodeILWhenEquelToNullShouldBeFalse()
        {
            PostCodeIL postCode = 1234567;
            Assert.False(postCode.Equals(null));
        }

        [Fact]
        public void TwoEquelPostCodesHashcodesShouldBeEquel()
        {
            PostCodeIL postCode1 = 1234567;
            PostCodeIL postCode2 = 1234567;
            Assert.Equal(postCode1.GetHashCode(), postCode2.GetHashCode());
        }

        [Fact]
        public void TwoEquelPostCodesEquelShoudReturnTrue()
        {
            PostCodeIL postCode1 = 1234567;
            PostCodeIL postCode2 = 1234567;
            Assert.True(postCode1.Equals(postCode2));
        }

        [Fact]
        public void TwoNotEquelPostCodesEquelShoudReturnFalse()
        {
            PostCodeIL postCode1 = 1234567;
            PostCodeIL postCode2 = 1234566;
            Assert.False(postCode1.Equals(postCode2));
        }

        [Fact]
        public void PostCodeWithValidValueWhenComparingToNullShouldReturnNotEquel()
        {
            PostCodeIL postCode1 = 1234567;
            PostCodeIL postCode2 = null;
            Assert.True(postCode1 != postCode2);
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
            PostCodeIL postCodeIL_right = right;
            Assert.True(left != postCodeIL_right);
        }
    }
}
