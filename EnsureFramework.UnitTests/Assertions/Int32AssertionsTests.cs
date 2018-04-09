using EnsureFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EnsureFramework.Tests
{
    public class Int32AssertionsTests
    {
        [Fact]
        public void IsNotNegative_Positive_Test()
        {
            Ensure.Arg(1, "value").IsNotNegative();
        }

        [Fact]
        public void IsNotNegative_Zero_Test()
        {
            Ensure.Arg(0, "value").IsNotNegative();
        }

        [Fact]
        public void IsNotNegative_Negative_Test()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Ensure.Arg(-1, "value").IsNotNegative());
        }

        [Fact]
        public void IsNotZero_Positive_Test()
        {
            Ensure.Arg(1, "value").IsNotZero();
        }

        [Fact]
        public void IsNotZero_Zero_Test()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Ensure.Arg(0, "value").IsNotZero());
        }

        [Fact]
        public void IsNotZero_Negative_Test()
        {
            Ensure.Arg(-1, "value").IsNotZero();
        }
    }
}