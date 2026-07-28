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
    public class EnsureEnumerableTests
    {
        [Fact]
        public void IsNotEmpty_Generic_Default()
        {
            int[] arg = [1, 2, 3];
            Ensure.Arg(arg).IsNotEmpty();
        }

        [Fact]
        public void IsNotEmpty_NonGeneric_Default()
        {
            IEnumerable arg = new[] { 1, 2, 3 };
            Ensure.Arg(arg).IsNotEmpty();
        }

        [Fact]
        public void IsNotEmpty_Generic_Throws()
        {
            var arg = Array.Empty<int>();
            Assert.Throws<ArgumentException>(() => Ensure.Arg(arg).IsNotEmpty());
        }

        [Fact]
        public void IsNotEmpty_NonGeneric_Throws()
        {
            IEnumerable arg = Array.Empty<int>();
            Assert.Throws<ArgumentException>(() => Ensure.Arg(arg).IsNotEmpty());
        }

        [Fact]
        public void Any_Generic_Default()
        {
            int[] arg = [1, 2, 3];
            Ensure.Arg(arg).Any(i => i == 2);
        }

        [Fact]
        public void Any_NonGeneric_Default()
        {
            IEnumerable arg = new[] { 1, 2, 3 };
            Ensure.Arg(arg).Any(i => Equals(i, 2));
        }

        [Fact]
        public void Any_Generic_Throws()
        {
            var arg = Array.Empty<int>();
            Assert.Throws<ArgumentException>(() => Ensure.Arg(arg).Any(i => i == 2));
        }

        [Fact]
        public void Any_NonGeneric_Throws()
        {
            IEnumerable arg = Array.Empty<int>();
            Assert.Throws<ArgumentException>(() => Ensure.Arg(arg).Any(i => Equals(i, 2)));
        }

        [Fact]
        public void Contains_Generic_Default()
        {
            int[] arg = [1, 2, 3];
            Ensure.Arg(arg).Contains(2);
        }

        [Fact]
        public void Contains_NonGeneric_Default()
        {
            IEnumerable arg = new[] { 1, 2, 3 };
            Ensure.Arg(arg).Contains(2);
        }

        [Fact]
        public void Contains_Generic_Throws()
        {
            var arg = Array.Empty<int>();
            Assert.Throws<ArgumentException>(() => Ensure.Arg(arg).Contains(2));
        }

        [Fact]
        public void Contains_NonGeneric_Throws()
        {
            IEnumerable arg = Array.Empty<int>();
            Assert.Throws<ArgumentException>(() => Ensure.Arg(arg).Contains(2));
        }

        [Fact]
        public void All_Generic_Default()
        {
            int[] arg = [2, 2, 2];
            Ensure.Arg(arg).All(i => i == 2);
        }

        [Fact]
        public void All_NonGeneric_Default()
        {
            IEnumerable arg = new[] { 2, 2, 2 };
            Ensure.Arg(arg).All(i => Equals(i, 2));
        }

        [Fact]
        public void All_Generic_Empty_Default()
        {
            var arg = Array.Empty<int>();
            Ensure.Arg(arg).All(i => i == 2);
        }

        [Fact]
        public void All_NonGeneric_Empty_Default()
        {
            IEnumerable arg = Array.Empty<int>();
            Ensure.Arg(arg).All(i => Equals(i, 2));
        }

        [Fact]
        public void All_Generic_NotAll_Throws()
        {
            int[] arg = [2, 2, 3];
            Assert.Throws<ArgumentException>(() => Ensure.Arg(arg).All(i => i == 2));
        }

        [Fact]
        public void All_NonGeneric_NotAll_Throws()
        {
            IEnumerable arg = new[] { 2, 2, 3 };
            Assert.Throws<ArgumentException>(() => Ensure.Arg(arg).All(i => Equals(i, 2)));
        }
    }
}