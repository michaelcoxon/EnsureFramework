namespace EnsureFramework.UnitTests.EnsureTests
{
    using System;

    using Xunit;

    public class EnsureComparisonTests
    {
        [Fact]
        public void IsGreaterThanOrEqualTo_Default()
        {
            Ensure.Arg(3).IsGreaterThanOrEqualTo(2);
        }

        [Fact]
        public void IsGreaterThanOrEqualTo_Throws()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Ensure.Arg(3).IsGreaterThanOrEqualTo(4));
        }

        [Fact]
        public void IsLessThanOrEqualTo_Default()
        {
            Ensure.Arg(3).IsLessThanOrEqualTo(4);
        }

        [Fact]
        public void IsLessThanOrEqualTo_Throws()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Ensure.Arg(3).IsLessThanOrEqualTo(2));
        }

        [Fact]
        public void IsLessThan_Default()
        {
            Ensure.Arg(3).IsLessThan(4);
        }

        [Fact]
        public void IsLessThan_Throws()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Ensure.Arg(3).IsLessThan(3));
        }

        [Fact]
        public void IsGreaterThan_Default()
        {
            Ensure.Arg(3).IsGreaterThan(2);
        }

        [Fact]
        public void IsGreaterThan_Throws()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Ensure.Arg(3).IsGreaterThan(3));
        }

        [Fact]
        public void IsEqualTo_Default()
        {
            Ensure.Arg(3).IsEqualTo(3);
        }

        [Fact]
        public void IsEqualTo_Throws()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Ensure.Arg(3).IsEqualTo(2));
        }

        [Fact]
        public void IsWithinRange_Default()
        {
            Ensure.Arg(3).IsWithinRange(2, 4);
        }

        [Fact]
        public void IsWithinRange_Throws()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Ensure.Arg(3).IsWithinRange(2, 3));
        }

        [Fact]
        public void IsWithinAndIncludingRange_Default()
        {
            Ensure.Arg(3).IsWithinAndIncludingRange(2, 4);
        }

        [Fact]
        public void IsWithinAndIncludingRange_Throws()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Ensure.Arg(3).IsWithinAndIncludingRange(4, 4));
        }
    }
}