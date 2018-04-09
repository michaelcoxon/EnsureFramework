using EnsureFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EnsureFramework.Tests
{
    public class EnumerableAssertionsTests
    {
        [Fact]
        public void IsNotNullOrEmptyTest()
        {
            Ensure.Arg(new int[] { 1, 2, 3 }, "value").IsNotNullOrEmpty();
        }

        [Fact]
        public void IsNotNullOrEmpty_Empty_Test()
        {
            Assert.Throws<ArgumentException>(() => Ensure.Arg(new int[] { }, "value").IsNotNullOrEmpty());
        }

        [Fact]
        public void IsNotNullOrEmpty_Null_Test()
        {
            Assert.Throws<ArgumentException>(() => Ensure.Arg<int[]>(null, "value").IsNotNullOrEmpty());
        }
    }
}