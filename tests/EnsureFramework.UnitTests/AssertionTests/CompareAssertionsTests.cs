using System;

using EnsureFramework.Assertions;

using Xunit;

namespace EnsureFramework.UnitTests.AssertionTests
{
    public class CompareAssertionsTests
    {
        [Fact]
        public void IsGreaterThanOrEqualToTest()
        {
            Assert.True(CompareAssertions.IsGreaterThanOrEqualTo(3, 2).Success);
            Assert.True(CompareAssertions.IsGreaterThanOrEqualTo(3, 3).Success);
            Assert.False(CompareAssertions.IsGreaterThanOrEqualTo(3, 4).Success);
        }

        [Fact]
        public void IsLessThanOrEqualToTest()
        {
            Assert.True(CompareAssertions.IsLessThanOrEqualTo(3, 4).Success);
            Assert.True(CompareAssertions.IsLessThanOrEqualTo(3, 3).Success);
            Assert.False(CompareAssertions.IsLessThanOrEqualTo(3, 2).Success);
        }

        [Fact]
        public void IsLessThanTest()
        {
            Assert.True(CompareAssertions.IsLessThan(3, 4).Success);
            Assert.False(CompareAssertions.IsLessThan(3, 3).Success);
        }

        [Fact]
        public void IsGreaterThanTest()
        {
            Assert.True(CompareAssertions.IsGreaterThan(3, 2).Success);
            Assert.False(CompareAssertions.IsGreaterThan(3, 3).Success);
        }

        [Fact]
        public void IsEqualToTest()
        {
            Assert.True(CompareAssertions.IsEqualTo(3, 3).Success);
            Assert.False(CompareAssertions.IsEqualTo(3, 2).Success);
        }

        [Fact]
        public void IsWithinRangeTest()
        {
            Assert.True(CompareAssertions.IsWithinRange(3, 2, 4).Success);
            Assert.True(CompareAssertions.IsWithinRange(3, -3, 100).Success);
            Assert.False(CompareAssertions.IsWithinRange(3, 4, 4).Success);
            Assert.False(CompareAssertions.IsWithinRange(3, 3, 4).Success);
            Assert.False(CompareAssertions.IsWithinRange(3, 2, 3).Success);
        }

        [Fact]
        public void IsWithinAndIncludingRangeTest()
        {
            Assert.True(CompareAssertions.IsWithinAndIncludingRange(3, 2, 4).Success);
            Assert.True(CompareAssertions.IsWithinAndIncludingRange(3, -3, 100).Success);

            Assert.True(CompareAssertions.IsWithinAndIncludingRange(3, 3, 4).Success);
            Assert.True(CompareAssertions.IsWithinAndIncludingRange(3, 2, 3).Success);

            Assert.False(CompareAssertions.IsWithinAndIncludingRange(3, 4, 4).Success);
        }
    }
}