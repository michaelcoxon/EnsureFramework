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
        public void IsGreaterThanOrEqualTo_Nested_Test()
        {
            var subject = new Dictionary<int, int>
            {
                [1] = 1,
                [2] = 2,
                [3] = 3,
                [4] = 4,
            };

            Ensure.Arg(subject, "value").WithKey(3).IsGreaterThanOrEqualTo(2).Pop();
            Ensure.Arg(subject, "value").WithKey(3).IsGreaterThanOrEqualTo(3).Pop();
            Assert.Throws<ArgumentException>(() =>
            {
                Ensure.Arg(subject, "value").WithKey(3).IsGreaterThanOrEqualTo(4).Pop();
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
        public void IsLessThanOrEqualTo_Nested_Test()
        {
            var subject = new Dictionary<int, int>
            {
                [1] = 1,
                [2] = 2,
                [3] = 3,
                [4] = 4,
            };

            Ensure.Arg(subject, "value").WithKey(3).IsLessThanOrEqualTo(4).Pop();
            Ensure.Arg(subject, "value").WithKey(3).IsLessThanOrEqualTo(3).Pop();
            Assert.Throws<ArgumentException>(() =>
            {
                Ensure.Arg(subject, "value").WithKey(3).IsLessThanOrEqualTo(2).Pop();
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
        public void IsLessThan_Nested_Test()
        {
            var subject = new Dictionary<int, int>
            {
                [1] = 1,
                [2] = 2,
                [3] = 3,
                [4] = 4,
            };

            Ensure.Arg(subject, "value").WithKey(3).IsLessThan(4).Pop();
            Assert.Throws<ArgumentException>(() =>
            {
                Ensure.Arg(subject, "value").WithKey(3).IsLessThan(3).Pop();
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
        public void IsGreaterThan_Nested_Test()
        {
            var subject = new Dictionary<int, int>
            {
                [1] = 1,
                [2] = 2,
                [3] = 3,
                [4] = 4,
            };

            Ensure.Arg(subject, "value").WithKey(3).IsGreaterThan(2).Pop();
            Assert.Throws<ArgumentException>(() =>
            {
                Ensure.Arg(subject, "value").WithKey(3).IsGreaterThan(3).Pop();
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
        public void IsEqualTo_Nested_Test()
        {
            var subject = new Dictionary<int, int>
            {
                [1] = 1,
                [2] = 2,
                [3] = 3,
                [4] = 4,
            };

            Ensure.Arg(subject, "value").WithKey(3).IsEqualTo(3).Pop();
            Assert.Throws<ArgumentException>(() =>
            {
                Ensure.Arg(subject, "value").WithKey(3).IsEqualTo(2).Pop();
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
        public void IsWithinRange_Nested_Test()
        {
            var subject = new Dictionary<int, int>
            {
                [1] = 1,
                [2] = 2,
                [3] = 3,
                [4] = 4,
            };

            Ensure.Arg(subject, "value").WithKey(3).IsWithinRange(2, 4).Pop();
            Ensure.Arg(subject, "value").WithKey(3).IsWithinRange(-3, 100).Pop();
            Assert.Throws<ArgumentException>(() =>
            {
                Ensure.Arg(subject, "value").WithKey(3).IsWithinRange(4, 4).Pop();
            });

            Assert.Throws<ArgumentException>(() =>
            {
                Ensure.Arg(subject, "value").WithKey(3).IsWithinRange(3, 4).Pop();
            });

            Assert.Throws<ArgumentException>(() =>
            {
                Ensure.Arg(subject, "value").WithKey(3).IsWithinRange(2, 3).Pop();
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

        [Fact]
        public void IsWithinAndIncludingRange_Nested_Test()
        {
            var subject = new Dictionary<int, int>
            {
                [1] = 1,
                [2] = 2,
                [3] = 3,
                [4] = 4,
            };
            Ensure.Arg(subject, "value").WithKey(3).IsWithinAndIncludingRange(2, 4).Pop();
            Ensure.Arg(subject, "value").WithKey(3).IsWithinAndIncludingRange(-3, 100).Pop();

            Ensure.Arg(subject, "value").WithKey(3).IsWithinAndIncludingRange(3, 4).Pop();
            Ensure.Arg(subject, "value").WithKey(3).IsWithinAndIncludingRange(2, 3).Pop();

            Assert.Throws<ArgumentException>(() =>
            {
                Ensure.Arg(subject, "value").WithKey(3).IsWithinAndIncludingRange(4, 4).Pop();
            });
        }
    }
}