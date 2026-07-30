namespace EnsureFramework.UnitTests.AssertionTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using EnsureFramework.Assertions;

    using Xunit;

    public class ObjectAssertionsTests
    {
        [Fact]
        public void MatchesTest()
        {
            var list = new List<string> { "hello" };
            Assert.True(ObjectAssertions.Matches(list, l => l.First() == "hello", null, out var ex).Success);
            Assert.Null(ex);
        }

        [Fact]
        public void MatchesFailTest()
        {
            var list = new List<string> { "hello" };
            Assert.False(ObjectAssertions.Matches(list, l => l.First() == "Hello", null, out var ex).Success);
            Assert.Null(ex);
        }

        [Fact]
        public void MatchesFailWithInnerExceptionTest()
        {
            var list = new List<string>();
            Assert.False(ObjectAssertions.Matches(list, l => l.First() == "hello", null, out var ex).Success);
            Assert.NotNull(ex);
        }

        [Fact]
        public void IsOneOfTest()
        {
            var str = "hello";
            Assert.True(ObjectAssertions.IsOneOf(str, "foo", "bar", "hello").Success);
        }

        [Fact]
        public void IsOneOfFailTest()
        {
            var str = "hello";
            Assert.False(ObjectAssertions.IsOneOf(str, "foo", "bar").Success);
        }

        [Fact]
        public void IsOneOf_Comparer_CurrentCulture_Test()
        {
            var str = "hello";
            Assert.True(ObjectAssertions.IsOneOf(str, StringComparer.CurrentCulture, "foo", "bar", "hello").Success);
        }

        [Fact]
        public void IsOneOf_Comparer_CurrentCulture_FailTest()
        {
            var str = "hello";
            Assert.False(ObjectAssertions.IsOneOf(str, StringComparer.CurrentCulture, "Foo", "Bar", "Hello").Success);
        }

        [Fact]
        public void IsOneOf_Comparer_CurrentCultureIgnoreCase_Test()
        {
            var str = "hello";
            Assert.True(ObjectAssertions.IsOneOf(str, StringComparer.CurrentCultureIgnoreCase, "Foo", "Bar", "Hello").Success);
        }

        [Fact]
        public void IsNotNullTest()
        {
            Assert.True(ObjectAssertions.IsNotNull("foo").Success);
        }

        [Fact]
        public void IsNotNullFailTest()
        {
            Assert.False(ObjectAssertions.IsNotNull((object?)null).Success);
        }

        [Fact]
        public void IsNullTest()
        {
            Assert.True(ObjectAssertions.IsNull((object?)null).Success);
        }

        [Fact]
        public void IsNullFailTest()
        {
            Assert.False(ObjectAssertions.IsNull("foo").Success);
        }
    }
}
