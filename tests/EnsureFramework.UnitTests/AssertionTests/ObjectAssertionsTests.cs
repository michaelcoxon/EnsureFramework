namespace EnsureFramework.UnitTests.AssertionTests
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using EnsureFramework.Assertions;

    using Xunit;

    public class ObjectAssertionsTests
    {
        [Fact]
        public void IsNotNull_Success()
        {
            var subject = "asdf";
            var actual = ObjectAssertions.IsNotNull(subject);
            Assert.True(actual.Success);
        }

        [Fact]
        public void IsNull_Success()
        {
            var subject = (string?)null;
            var actual = ObjectAssertions.IsNull(subject);
            Assert.True(actual.Success);
        }

        [Fact]
        public void IsOneOf_null_Success()
        {
            var options = new [] { null, "value" };
            var subject = (string?)null;
            var actual = ObjectAssertions.IsOneOf(subject, options);
            Assert.True(actual.Success);
        }

        [Fact]
        public void IsOneOf_value_Success()
        {
            var options = new [] { null, "value" };
            var subject = "value";
            var actual = ObjectAssertions.IsOneOf(subject, options);
            Assert.True(actual.Success);
        }

        [Fact]
        public void IsOneOf_NullOrEmpty_Success()
        {
            var options = new[] { null, "" };
            var subject = string.Empty;
            var actual = ObjectAssertions.IsOneOf(subject, options);
            Assert.True(actual.Success);
        }
    }
}
