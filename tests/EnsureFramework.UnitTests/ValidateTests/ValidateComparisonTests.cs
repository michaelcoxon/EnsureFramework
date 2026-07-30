namespace EnsureFramework.UnitTests.ValidateTests
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Xunit;

    public class ValidateComparisonTests
    {
        [Fact]
        public void ValidateThat_IsGreaterThanOrEqualTo_Equal()
        {
            var subject = 1;
            var result = Validate.That(subject).IsGreaterThanOrEqualTo(1);
            Assert.False(result.IsError);
        }

        [Fact]
        public void ValidateThat_IsGreaterThanOrEqualTo_GreaterThan()
        {
            var subject = 1;
            var result = Validate.That(subject).IsGreaterThanOrEqualTo(0);
            Assert.False(result.IsError);
        }

        [Fact]
        public void ValidateThat_IsGreaterThanOrEqualTo_LessThan_Error()
        {
            var subject = 1;
            var result = Validate.That(subject).IsGreaterThanOrEqualTo(2);
            Assert.True(result.IsError);
        }

        [Fact]
        public void ValidateThat_IsLessThanOrEqualTo_Equal()
        {
            var subject = 1;
            var result = Validate.That(subject).IsLessThanOrEqualTo(1);
            Assert.False(result.IsError);
        }

        [Fact]
        public void ValidateThat_IsLessThanOrEqualTo_LessThan()
        {
            var subject = 1;
            var result = Validate.That(subject).IsLessThanOrEqualTo(2);
            Assert.False(result.IsError);
        }

        [Fact]
        public void ValidateThat_IsLessThanOrEqualTo_GreaterThan_Error()
        {
            var subject = 1;
            var result = Validate.That(subject).IsLessThanOrEqualTo(0);
            Assert.True(result.IsError);
        }

        [Fact]
        public void ValidateThat_IsLessThan_LessThan()
        {
            var subject = 1;
            var result = Validate.That(subject).IsLessThan(2);
            Assert.False(result.IsError);
        }

        [Fact]
        public void ValidateThat_IsLessThan_GreaterThan_Error()
        {
            var subject = 1;
            var result = Validate.That(subject).IsLessThan(0);
            Assert.True(result.IsError);
        }

        [Fact]
        public void ValidateThat_IsLessThan_Equal_Error()
        {
            var subject = 1;
            var result = Validate.That(subject).IsLessThan(1);
            Assert.True(result.IsError);
        }

        [Fact]
        public void ValidateThat_IsGreaterThan_LessThan_Error()
        {
            var subject = 1;
            var result = Validate.That(subject).IsGreaterThan(2);
            Assert.True(result.IsError);
        }

        [Fact]
        public void ValidateThat_IsGreaterThan_GreaterThan()
        {
            var subject = 1;
            var result = Validate.That(subject).IsGreaterThan(0);
            Assert.False(result.IsError);
        }

        [Fact]
        public void ValidateThat_IsGreaterThan_Equal_Error()
        {
            var subject = 1;
            var result = Validate.That(subject).IsGreaterThan(1);
            Assert.True(result.IsError);
        }

        [Fact]
        public void ValidateThat_IsEqualTo_Equal()
        {
            var subject = 1;
            var result = Validate.That(subject).IsEqualTo(1);
            Assert.False(result.IsError);
        }

        [Fact]
        public void ValidateThat_IsEqualTo_NotEqual_Error()
        {
            var subject = 1;
            var result = Validate.That(subject).IsEqualTo(0);
            Assert.True(result.IsError);
        }

        [Fact]
        public void ValidateThat_IsWithinRange_LessThan_Error()
        {
            var subject = 1;
            var result = Validate.That(subject).IsWithinRange(2, 4);
            Assert.True(result.IsError);
        }

        [Fact]
        public void ValidateThat_IsWithinRange_GreaterThan_Error()
        {
            var subject = 5;
            var result = Validate.That(subject).IsWithinRange(2, 4);
            Assert.True(result.IsError);
        }

        [Fact]
        public void ValidateThat_IsWithinRange_SameAsLowerBound_Error()
        {
            var subject = 2;
            var result = Validate.That(subject).IsWithinRange(2, 4);
            Assert.True(result.IsError);
        }

        [Fact]
        public void ValidateThat_IsWithinRange_SameAsUpperBound_Error()
        {
            var subject = 4;
            var result = Validate.That(subject).IsWithinRange(2, 4);
            Assert.True(result.IsError);
        }

        [Fact]
        public void ValidateThat_IsWithinRange_Inside()
        {
            var subject = 3;
            var result = Validate.That(subject).IsWithinRange(2, 4);
            Assert.False(result.IsError);
        }

        [Fact]
        public void ValidateThat_IsWithinAndIncludingRange_LessThan_Error()
        {
            var subject = 1;
            var result = Validate.That(subject).IsWithinAndIncludingRange(2, 4);
            Assert.True(result.IsError);
        }

        [Fact]
        public void ValidateThat_IsWithinAndIncludingRange_GreaterThan_Error()
        {
            var subject = 5;
            var result = Validate.That(subject).IsWithinAndIncludingRange(2, 4);
            Assert.True(result.IsError);
        }

        [Fact]
        public void ValidateThat_IsWithinAndIncludingRange_SameAsLowerBound_Error()
        {
            var subject = 2;
            var result = Validate.That(subject).IsWithinAndIncludingRange(2, 4);
            Assert.False(result.IsError);
        }

        [Fact]
        public void ValidateThat_IsWithinAndIncludingRange_SameAsUpperBound_Error()
        {
            var subject = 4;
            var result = Validate.That(subject).IsWithinAndIncludingRange(2, 4);
            Assert.False(result.IsError);
        }

        [Fact]
        public void ValidateThat_IsWithinAndIncludingRange_Inside()
        {
            var subject = 3;
            var result = Validate.That(subject).IsWithinAndIncludingRange(2, 4);
            Assert.False(result.IsError);
        }
    }
}
