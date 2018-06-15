using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EnsureFramework.UnitTests.Assertions
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
        public void IsTypeOfParamTest()
        {
            var list = new List<string>();

            Ensure.Arg(list, nameof(list)).IsTypeOf(typeof(List<string>));
        }

        [Fact]
        public void IsTypeOfParamFailTest()
        {
            var list = new List<string>();

            Assert.Throws<ArgumentException>(() =>
            {
                Ensure.Arg(list, nameof(list)).IsTypeOf(typeof(IEnumerable<string>));
            });
        }

        [Fact]
        public void IsTypeOfGenericTest()
        {
            var list = new List<string>();

            Ensure.Arg(list, nameof(list)).IsTypeOf<List<string>>();
        }

        [Fact]
        public void IsTypeOfGenericFailTest()
        {
            var list = new List<string>();

            Assert.Throws<ArgumentException>(() =>
            {
                Ensure.Arg(list, nameof(list)).IsTypeOf<IEnumerable<string>>();
            });
        }


        [Fact]
        public void MatchesTest()
        {
            var list = new List<string> { "hello" };

            Ensure.Arg(list, nameof(list)).Matches(l => l.First() == "hello");
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
                Ensure.Arg(list, nameof(list)).Matches(l => l.First() == "hello");
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

        [Fact]
        public void WithPropertyTest()
        {
            var anything = new { foo = "bar" };

            Ensure.Arg(anything, nameof(anything))
                .WithProperty(o => o.foo)
                .IsNotNull()
                .IsEqualTo("bar");
        }

        [Fact]
        public void WithPropertyFailTest()
        {
            var anything = new { foo = (string)null };

            Assert.Throws<ArgumentNullException>(() =>
            {
                Ensure.Arg(anything, nameof(anything))
                    .WithProperty(o => o.foo)
                    .IsNotNull();
            });
        }
    }
}
