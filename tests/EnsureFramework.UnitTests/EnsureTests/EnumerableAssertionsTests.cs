using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace EnsureFramework.UnitTests.EnsureTests
{
    public class EnumerableAssertionsTests
    {
        [Fact]
        public void IsNotEmpty_Generic()
        {
            int[] arg = [1, 2, 3];
            Ensure.Arg(arg).IsNotEmpty();
        }

        [Fact]
        public void IsNotEmpty_NonGeneric()
        {
            IEnumerable arg = new[] { 1, 2, 3 };
            Ensure.Arg(arg).IsNotEmpty();
        }

        [Fact]
        public void IsNotEmpty_Generic_Empty()
        {
            var arg = Array.Empty<int>();
            Assert.Throws<ArgumentException>(() => Ensure.Arg(arg).IsNotEmpty());
        }

        [Fact]
        public void IsNotEmpty_NonGeneric_Empty()
        {
            IEnumerable arg = Array.Empty<int>();
            Assert.Throws<ArgumentException>(() => Ensure.Arg(arg).IsNotEmpty());
        }


        [Fact]
        public void Any_Generic()
        {
            int[] arg = [1, 2, 3];
            Ensure.Arg(arg).Any(i => i == 2);
        }

        [Fact]
        public void Any_NonGeneric()
        {
            IEnumerable arg = new[] { 1, 2, 3 };
            Ensure.Arg(arg).Any(i => Equals(i, 2));
        }

        [Fact]
        public void Any_Generic_Empty()
        {
            var arg = Array.Empty<int>();
            Assert.Throws<ArgumentException>(() => Ensure.Arg(arg).Any(i => i == 2));
        }

        [Fact]
        public void Any_NonGeneric_Empty()
        {
            IEnumerable arg = Array.Empty<int>();
            Assert.Throws<ArgumentException>(() => Ensure.Arg(arg).Any(i => Equals(i, 2)));
        }


        [Fact]
        public void Contains_Generic()
        {
            int[] arg = [1, 2, 3];
            Ensure.Arg(arg).Contains(2);
        }

        [Fact]
        public void Contains_NonGeneric()
        {
            IEnumerable arg = new[] { 1, 2, 3 };
            Ensure.Arg(arg).Contains(2);
        }

        [Fact]
        public void Contains_Generic_Empty()
        {
            var arg = Array.Empty<int>();
            Assert.Throws<ArgumentException>(() => Ensure.Arg(arg).Contains(2));
        }

        [Fact]
        public void Contains_NonGeneric_Empty()
        {
            IEnumerable arg = Array.Empty<int>();
            Assert.Throws<ArgumentException>(() => Ensure.Arg(arg).Contains(2));
        }


        [Fact]
        public void All_Generic()
        {
            int[] arg = [2, 2, 2];
            Ensure.Arg(arg).All(i => i == 2);
        }

        [Fact]
        public void All_NonGeneric()
        {
            IEnumerable arg = new[] { 2, 2, 2 };
            Ensure.Arg(arg).All(i => Equals(i, 2));
        }

        [Fact]
        public void All_Generic_Empty()
        {
            var arg = Array.Empty<int>();
            Ensure.Arg(arg).All(i => i == 2);
        }

        [Fact]
        public void All_NonGeneric_Empty()
        {
            IEnumerable arg = Array.Empty<int>();
            Ensure.Arg(arg).All(i => Equals(i, 2));
        }

        [Fact]
        public void All_Generic_NotAll()
        {
            int[] arg = [2, 2, 3];
            Assert.Throws<ArgumentException>(() => Ensure.Arg(arg).All(i => i == 2));
        }

        [Fact]
        public void All_NonGeneric_NotAll()
        {
            IEnumerable arg = new[] { 2, 2, 3 };
            Assert.Throws<ArgumentException>(() => Ensure.Arg(arg).All(i => Equals(i, 2)));
        }
    }
}