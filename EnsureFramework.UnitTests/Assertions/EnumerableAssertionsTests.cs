using EnsureFramework.Assertions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace EnsureFramework.UnitTests.Assertions
{
    public class EnumerableAssertionsTests
    {

        [Fact]
        public void IsNotNullOrEmptyTest()
        {
            int[] arg = [1, 2, 3];
            Ensure.Arg(arg, "value").IsNotNullOrEmpty();
        }

        [Fact]
        public void IsNotNullOrEmpty_Empty_Test()
        {
            var arg = new int[] { };
            Assert.Throws<ArgumentException>(() => Ensure.Arg(arg).IsNotNullOrEmpty());
        }

        [Fact]
        public void IsNotNullOrEmpty_Null_Test()
        {
            int[]? arg = null;
            Assert.Throws<ArgumentNullException>(() => Ensure.Arg(arg).IsNotNullOrEmpty());
        }
    }
}