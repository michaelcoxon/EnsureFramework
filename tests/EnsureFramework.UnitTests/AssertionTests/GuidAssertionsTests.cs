namespace EnsureFramework.UnitTests.AssertionTests
{
    using System;

    using EnsureFramework.Assertions;

    using Xunit;

    public class GuidAssertionsTests
    {
        [Fact]
        public void IsValidGuidTest()
        {
            Assert.True(GuidAssertions.IsValidGuid(Guid.NewGuid()).Success);
        }

        [Fact]
        public void IsValidGuidFailTest()
        {
            Assert.False(GuidAssertions.IsValidGuid(Guid.Empty).Success);
        }
    }
}
