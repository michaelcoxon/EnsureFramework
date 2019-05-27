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
            Assert.Throws<ArgumentException>(() =>
            {
                Ensure.Arg(3, "value").IsGreaterThanOrEqualTo(4);
            });
        }

        [Fact]
        public void IsLessThanOrEqualToTest()
        {
            Ensure.Arg(3, "value").IsLessThanOrEqualTo(4);
            Ensure.Arg(3, "value").IsLessThanOrEqualTo(3);
            Assert.Throws<ArgumentException>(() =>
            {
                Ensure.Arg(3, "value").IsLessThanOrEqualTo(2);
            });
        }

        [Fact]
        public void IsLessThanTest()
        {
            Ensure.Arg(3, "value").IsLessThan(4);
            Assert.Throws<ArgumentException>(() =>
            {
                Ensure.Arg(3, "value").IsLessThan(3);
            });
        }

        [Fact]
        public void IsGreaterThanTest()
        {
            Ensure.Arg(3, "value").IsGreaterThan(2);
            Assert.Throws<ArgumentException>(() =>
            {
                Ensure.Arg(3, "value").IsGreaterThan(3);
            });
        }

        [Fact]
        public void IsEqualToTest()
        {
            Ensure.Arg(3, "value").IsEqualTo(3);
            Assert.Throws<ArgumentException>(() =>
            {
                Ensure.Arg(3, "value").IsEqualTo(2);
            });
        }

        [Fact]
        public void IsWithinRangeTest()
        {
            Ensure.Arg(3, "value").IsWithinRange(2, 4);
            Ensure.Arg(3, "value").IsWithinRange(-3, 100);
            Assert.Throws<ArgumentException>(() =>
            {
                Ensure.Arg(3, "value").IsWithinRange(4, 4);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                Ensure.Arg(3, "value").IsWithinRange(3, 4);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                Ensure.Arg(3, "value").IsWithinRange(2, 3);
            });
        }

        [Fact]
        public void IsWithinAndIncludingRangeTest()
        {
            Ensure.Arg(3, "value").IsWithinAndIncludingRange(2, 4);
            Ensure.Arg(3, "value").IsWithinAndIncludingRange(-3, 100);

            Ensure.Arg(3, "value").IsWithinAndIncludingRange(3, 4);
            Ensure.Arg(3, "value").IsWithinAndIncludingRange(2, 3);

            Assert.Throws<ArgumentException>(() =>
            {
                Ensure.Arg(3, "value").IsWithinAndIncludingRange(4, 4);
            });
        }
    }
}