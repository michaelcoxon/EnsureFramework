namespace EnsureFramework.UnitTests.AssertionTests
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    using EnsureFramework.Assertions;

    using Xunit;

    public class TypeAssertionsTests
    {
        [Fact]
        public void IsExactType_Default()
        {
            Assert.True(TypeAssertions.IsExactType(typeof(List<string>), typeof(List<string>)).Success);
        }

        [Fact]
        public void IsExactType_Enumerable_Fail()
        {
            Assert.False(TypeAssertions.IsExactType(typeof(List<string>), typeof(IEnumerable)).Success);
        }

        [Fact]
        public void IsExactType_Default_Fail()
        {
            Assert.False(TypeAssertions.IsExactType(typeof(List<string>), typeof(List<int>)).Success);
        }

        [Fact]
        public void IsAssignableFrom_Default()
        {
            Assert.True(TypeAssertions.IsAssignableFrom(typeof(IEnumerable), typeof(List<string>)).Success);
        }

        [Fact]
        public void IsAssignableFrom_Default_Fail()
        {
            Assert.False(TypeAssertions.IsAssignableFrom(typeof(IEnumerable), typeof(IDisposable)).Success);
        }

        [Fact]
        public void IsAssignableFrom_ReversedGraph_Fail()
        {
            Assert.False(TypeAssertions.IsAssignableFrom(typeof(List<string>), typeof(IEnumerable)).Success);
        }
    }
}
