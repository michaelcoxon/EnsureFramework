using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EnsureFramework;

using Xunit;

namespace EnsureFramework.UnitTests.EnsureTests
{
    public class NumberAssertionsTests
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
        public void IsNegative_Positive_Test()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Ensure.Arg(1, "value").IsNegative());
        }

        [Fact]
        public void IsNegative_Zero_Test()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Ensure.Arg(0, "value").IsNegative());
        }

        [Fact]
        public void IsNegative_Negative_Test()
        {
            Ensure.Arg(-1, "value").IsNegative();
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

        [Fact]
        public void IsZero_Positive_Test()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Ensure.Arg(1, "value").IsZero());
        }

        [Fact]
        public void IsZero_Zero_Test()
        {
            Ensure.Arg(0, "value").IsZero();
        }

        [Fact]
        public void IsZero_Negative_Test()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Ensure.Arg(-1, "value").IsZero());
        }

        [Fact]
        public void IsNotNull_NullableIntBecomesInt_Test()
        {
            int? value = -1;
            Ensure.Arg(value, "value").IsNotZero();
        }
    }
}