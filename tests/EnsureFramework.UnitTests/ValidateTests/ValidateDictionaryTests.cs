namespace EnsureFramework.UnitTests.ValidateTests
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    using Xunit;

    public class ValidateDictionaryTests
    {
        [Fact]
        public void ValidateThat_HasKey_Default()
        {
            var subject = new Dictionary<string, string>
            {
                ["key"] = "value"
            };
            var result = Validate.That(subject).HasKey("key");
            Assert.False(result.IsError);
        }

        [Fact]
        public void ValidateThat_HasKey_Fail()
        {
            var subject = new Dictionary<string, string>
            {
                ["key"] = "value"
            };
            var result = Validate.That(subject).HasKey("key2");
            Assert.True(result.IsError);
        }
    }
}
