namespace EnsureFramework.UnitTests.ValidateTests
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Xunit;

    public class ValidateObjectTests
    {
        [Fact]
        public void ValidateThat_IsNotNull_Default()
        {
            var subject = "asdf";
            var result = Validate.That(subject).IsNotNull();
            Assert.False(result.IsError);
        }

        [Fact]
        public void ValidateThat_IsNotNull_Fail()
        {
            var subject = (string?)null;
            var result = Validate.That(subject).IsNotNull();
            Assert.True(result.IsError);
        }

        [Fact]
        public void ValidateThat_IsNull_Fail()
        {
            var subject = "asdf";
            var result = Validate.That(subject).IsNull();
            Assert.True(result.IsError);
        }

        [Fact]
        public void ValidateThat_IsNull_Default()
        {
            var subject = (string?)null;
            var result = Validate.That(subject).IsNull();
            Assert.False(result.IsError);
        }
    }
}
