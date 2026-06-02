using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace EnsureFramework.UnitTests
{
    public class ObjectAssertionsTests
    {
        [Fact]
        public void AssertTest()
        {
            var anything = new { foo = "bar" };

            Ensure.Arg(anything, nameof(anything)).Assert(true);
        }

        [Fact]
        public void AssertFailTest()
        {
            var anything = new { foo = "bar" };

            Assert.Throws<ArgumentException>(() =>
            {
                Ensure.Arg(anything, nameof(anything)).Assert(false);
            });
        }

        [Fact]
        public void IsExactTypeOfParamTest()
        {
            var list = new List<string>();

            Ensure.Arg(list, nameof(list)).IsExactTypeOf(typeof(List<string>));
        }

        [Fact]
        public void IsExactTypeOfParamFailTest()
        {
            var list = new List<string>();

            Assert.Throws<ArgumentException>(() =>
            {
                Ensure.Arg(list, nameof(list)).IsExactTypeOf(typeof(IEnumerable<string>));
            });
        }

        [Fact]
        public void IsInheritsTypeOfParamExactTest()
        {
            var list = new List<string>();
            Ensure.Arg(list, nameof(list)).IsInheritsTypeOf(typeof(List<string>));
        }

        [Fact]
        public void IsInheritsTypeOfParamBaseTest()
        {
            var list = new List<string>();
            Ensure.Arg(list, nameof(list)).IsInheritsTypeOf(typeof(IEnumerable<string>));
        }

        [Fact]
        public void MatchesTest()
        {
            var list = new List<string> { "hello" };

            Ensure.Arg(list).Matches(l => l.First() == "hello");
        }

        [Fact]
        public void MatchesFailTest()
        {
            var list = new List<string> { "hello" };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                Ensure.Arg(list, nameof(list)).Matches(l => l.First() == "Hello");
            });

            Assert.Null(exception.InnerException);
        }

        [Fact]
        public void MatchesFailWithInnerTest()
        {
            var list = new List<string>();

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                Ensure.Arg(list).Matches(l => l.First() == "hello");
            });

            Assert.IsType<InvalidOperationException>(exception.InnerException);
        }

        [Fact]
        public void IsOneOfTest()
        {
            var str = "hello";

            Ensure.Arg(str, nameof(str)).IsOneOf("foo", "bar", "hello");
        }

        [Fact]
        public void IsOneOfFailTest()
        {
            var str = "hello";

            Assert.Throws<ArgumentException>(() =>
            {
                Ensure.Arg(str, nameof(str)).IsOneOf("foo", "bar");
            });
        }
    }
}
