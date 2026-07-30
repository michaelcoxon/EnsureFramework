namespace EnsureFramework.UnitTests.ValidateTests
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    using Xunit;

    public class ValidateGuidTests
    {
        [Fact]
        public void ValidateThat_IsValidGuid_Default()
        {
            var subject = Guid.NewGuid();
            var result = Validate.That(subject).IsValidGuid();
            Assert.False(result.IsError);
        }

        [Fact]
        public void ValidateThat_IsValidGuid_Empty_Fail()
        {
            var subject = Guid.Empty;
            var result = Validate.That(subject).IsValidGuid();
            Assert.True(result.IsError);
        }

        [Fact]
        public void ValidateThat_IsValidGuid_Nullable_Default()
        {
            var subject = (Guid?)Guid.NewGuid();
            var result = Validate.That(subject).IsValidGuid();
            Assert.False(result.IsError);
        }

        [Fact]
        public void ValidateThat_IsValidGuid_Nullable_Fail()
        {
            var subject = (Guid?)null;
            var result = Validate.That(subject).IsValidGuid();
            Assert.True(result.IsError);
        }
    }
}
