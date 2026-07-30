namespace EnsureFramework.UnitTests.ValidateTests
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Xunit;

    public class ValidateNumberTests
    {
        [Fact]
        public void ValidateThat_IsNegative_Default()
        {
            var subject = -1;
            var result = Validate.That(subject).IsNegative();
            Assert.False(result.IsError);
        }

        [Fact]
        public void ValidateThat_IsNegative_Zero_Fail()
        {
            var subject = 0;
            var result = Validate.That(subject).IsNegative();
            Assert.True(result.IsError);
        }

        [Fact]
        public void ValidateThat_IsNegative_Positive_Fail()
        {
            var subject = 1;
            var result = Validate.That(subject).IsNegative();
            Assert.True(result.IsError);
        }

        [Fact]
        public void ValidateThat_IsZero_Negative_Fail()
        {
            var subject = -1;
            var result = Validate.That(subject).IsZero();
            Assert.True(result.IsError);
        }

        [Fact]
        public void ValidateThat_IsZero_Default()
        {
            var subject = 0;
            var result = Validate.That(subject).IsZero();
            Assert.False(result.IsError);
        }

        [Fact]
        public void ValidateThat_IsZero_Positive_Fail()
        {
            var subject = 1;
            var result = Validate.That(subject).IsZero();
            Assert.True(result.IsError);
        }
    }
}
