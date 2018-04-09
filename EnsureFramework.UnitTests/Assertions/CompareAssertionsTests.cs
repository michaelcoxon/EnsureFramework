using EnsureFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EnsureFramework.Tests
{
    public class CompareAssertionsTests
    {
        [Fact]
        public void IsGreaterThanOrEqualToTest()
        {
            Ensure.Arg(3, "value").IsGreaterThanOrEqualTo(2);
            Ensure.Arg(3, "value").IsGreaterThanOrEqualTo(3);
        }

        [Fact]
        public void IsLessThanOrEqualToTest()
        {
            Ensure.Arg(3, "value").IsLessThanOrEqualTo(4);
            Ensure.Arg(3, "value").IsLessThanOrEqualTo(3);
        }

        [Fact]
        public void IsLessThanTest()
        {
            Ensure.Arg(3, "value").IsLessThan(4);
        }

        [Fact]
        public void IsGreaterThanTest()
        {
            Ensure.Arg(3, "value").IsGreaterThan(2);
        }

        [Fact]
        public void IsEqualToTest()
        {
            Ensure.Arg(3, "value").IsEqualTo(3);
        }
    }
}