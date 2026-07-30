namespace EnsureFramework.UnitTests.AssertionTests
{
    using System;
    using System.Collections;

    using EnsureFramework.Assertions;

    using Xunit;

    public class EnumerableAssertionsTests
    {
        [Fact]
        public void IsNotEmpty_Generic()
        {
            Assert.True(EnumerableAssertions.IsNotEmpty([1, 2, 3]).Success);
        }

        [Fact]
        public void IsNotEmpty_NonGeneric()
        {
            IEnumerable arg = new[] { 1, 2, 3 };
            Assert.True(EnumerableAssertions.IsNotEmpty(arg).Success);
        }

        [Fact]
        public void IsNotEmpty_Generic_Empty()
        {
            Assert.False(EnumerableAssertions.IsNotEmpty(Array.Empty<int>()).Success);
        }

        [Fact]
        public void IsNotEmpty_NonGeneric_Empty()
        {
            IEnumerable arg = Array.Empty<int>();
            Assert.False(EnumerableAssertions.IsNotEmpty(arg).Success);
        }

        [Fact]
        public void Any_Generic()
        {
            Assert.True(EnumerableAssertions.Any([1, 2, 3], i => i == 2).Success);
        }

        [Fact]
        public void Any_NonGeneric()
        {
            IEnumerable arg = new[] { 1, 2, 3 };
            Assert.True(EnumerableAssertions.Any(arg, i => Equals(i, 2)).Success);
        }

        [Fact]
        public void Any_Generic_Empty()
        {
            Assert.False(EnumerableAssertions.Any(Array.Empty<int>(), i => i == 2).Success);
        }

        [Fact]
        public void Any_NonGeneric_Empty()
        {
            IEnumerable arg = Array.Empty<int>();
            Assert.False(EnumerableAssertions.Any(arg, i => Equals(i, 2)).Success);
        }

        [Fact]
        public void Contains_Generic()
        {
            int[] arg = [1, 2, 3];
            Assert.True(EnumerableAssertions.Contains(arg, 2).Success);
        }

        [Fact]
        public void Contains_NonGeneric()
        {
            IEnumerable arg = new[] { 1, 2, 3 };
            Assert.True(EnumerableAssertions.Contains(arg, 2).Success);
        }

        [Fact]
        public void Contains_Generic_Empty()
        {
            var arg = Array.Empty<int>();
            Assert.False(EnumerableAssertions.Contains(arg, 2).Success);
        }

        [Fact]
        public void Contains_NonGeneric_Empty()
        {
            IEnumerable arg = Array.Empty<int>();
            Assert.False(EnumerableAssertions.Contains(arg, 2).Success);
        }

        [Fact]
        public void All_Generic()
        {
            int[] arg = [2, 2, 2];
            Assert.True(EnumerableAssertions.All(arg, i => i == 2).Success);
        }

        [Fact]
        public void All_NonGeneric()
        {
            IEnumerable arg = new[] { 2, 2, 2 };
            Assert.True(EnumerableAssertions.All(arg, i => Equals(i, 2)).Success);
        }

        [Fact]
        public void All_Generic_Empty()
        {
            var arg = Array.Empty<int>();
            Assert.True(EnumerableAssertions.All(arg, i => i == 2).Success);
        }

        [Fact]
        public void All_NonGeneric_Empty()
        {
            IEnumerable arg = Array.Empty<int>();
            Assert.True(EnumerableAssertions.All(arg, i => Equals(i, 2)).Success);
        }

        [Fact]
        public void All_Generic_NotAll()
        {
            int[] arg = [2, 2, 3];
            Assert.False(EnumerableAssertions.All(arg, i => i == 2).Success);
        }

        [Fact]
        public void All_NonGeneric_NotAll()
        {
            IEnumerable arg = new[] { 2, 2, 3 };
            Assert.False(EnumerableAssertions.All(arg, i => Equals(i, 2)).Success);
        }
    }
}