namespace EnsureFramework.UnitTests
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using EnsureFramework;

    using Xunit;

    public class TypeAssertionsTests
    {
        [Fact]
        public void Is_Default()
        {
            var arg = typeof(List<string>);
            Ensure.Arg(arg).Is(typeof(List<string>));
        }

        [Fact]
        public void Is_Default_Fail()
        {
            var arg = typeof(List<string>);
            Assert.Throws<ArgumentException>(() => Ensure.Arg(arg).Is(typeof(IDisposable)));
        }

        [Fact]
        public void Is_Generic()
        {
            var arg = typeof(List<string>);
            Ensure.Arg(arg).Is<List<string>>();
        }

        [Fact]
        public void Is_Generic_Fail()
        {
            var arg = typeof(List<string>);
            Assert.Throws<ArgumentException>(() => Ensure.Arg(arg).Is<IDisposable>());
        }


        [Fact]
        public void IsAssignableFrom_Default()
        {
            var arg = typeof(IEnumerable);
            Ensure.Arg(arg).IsAssignableFrom(typeof(List<string>));
        }

        [Fact]
        public void IsAssignableFrom_Default_Fail()
        {
            var arg = typeof(IEnumerable);
            Assert.Throws<ArgumentException>(() => Ensure.Arg(arg).IsAssignableFrom(typeof(IDisposable)));
        }

        [Fact]
        public void IsAssignableFrom_Generic()
        {
            var arg = typeof(IEnumerable);
            Ensure.Arg(arg).IsAssignableFrom<List<string>>();
        }

        [Fact]
        public void IsAssignableFrom_Generic_Fail()
        {
            var arg = typeof(IEnumerable);
            Assert.Throws<ArgumentException>(() => Ensure.Arg(arg).IsAssignableFrom<IDisposable>());
        }


        [Fact]
        public void IsAssignableTo_Default()
        {
            var arg = typeof(List<string>);
            Ensure.Arg(arg).IsAssignableTo(typeof(IEnumerable));
        }

        [Fact]
        public void IsAssignableTo_Default_Fail()
        {
            var arg = typeof(List<string>);
            Assert.Throws<ArgumentException>(() => Ensure.Arg(arg).IsAssignableTo(typeof(IDisposable)));
        }

        [Fact]
        public void IsAssignableTo_Generic()
        {
            var arg = typeof(List<string>);
            Ensure.Arg(arg).IsAssignableTo<IEnumerable>();
        }

        [Fact]
        public void IsAssignableTo_Generic_Fail()
        {
            var arg = typeof(List<string>);
            Assert.Throws<ArgumentException>(() => Ensure.Arg(arg).IsAssignableTo<IDisposable>());
        }
    }
}
