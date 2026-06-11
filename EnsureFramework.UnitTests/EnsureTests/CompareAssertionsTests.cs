using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EnsureFramework;

using Xunit;

namespace EnsureFramework.UnitTests.EnsureTests
{
    public class CompareAssertionsTests
    {
        [Fact]
        public void IsGreaterThanOrEqualToTest()
        {
            Ensure.Arg(3).IsGreaterThanOrEqualTo(2);
            Ensure.Arg(3).IsGreaterThanOrEqualTo(3);
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Ensure.Arg(3).IsGreaterThanOrEqualTo(4);
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

            Ensure.Arg(subject[3]).IsGreaterThanOrEqualTo(2);
            Ensure.Arg(subject[3]).IsGreaterThanOrEqualTo(3);
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Ensure.Arg(subject[3]).IsGreaterThanOrEqualTo(4);
            });
        }

        [Fact]
        public void IsLessThanOrEqualToTest()
        {
            Ensure.Arg(3).IsLessThanOrEqualTo(4);
            Ensure.Arg(3).IsLessThanOrEqualTo(3);
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Ensure.Arg(3).IsLessThanOrEqualTo(2);
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

            Ensure.Arg(subject[3]).IsLessThanOrEqualTo(4);
            Ensure.Arg(subject[3]).IsLessThanOrEqualTo(3);
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Ensure.Arg(subject[3]).IsLessThanOrEqualTo(2);
            });
        }

        [Fact]
        public void IsLessThanTest()
        {
            Ensure.Arg(3).IsLessThan(4);
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Ensure.Arg(3).IsLessThan(3);
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

            Ensure.Arg(subject[3]).IsLessThan(4);
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Ensure.Arg(subject[3]).IsLessThan(3);
            });
        }


        [Fact]
        public void IsGreaterThanTest()
        {
            Ensure.Arg(3).IsGreaterThan(2);
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Ensure.Arg(3).IsGreaterThan(3);
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

            Ensure.Arg(subject[3]).IsGreaterThan(2);
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Ensure.Arg(subject[3]).IsGreaterThan(3);
            });
        }

        [Fact]
        public void IsEqualToTest()
        {
            Ensure.Arg(3).IsEqualTo(3);
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Ensure.Arg(3).IsEqualTo(2);
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

            Ensure.Arg(subject[3]).IsEqualTo(3);
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Ensure.Arg(subject[3]).IsEqualTo(2);
            });
        }

        [Fact]
        public void IsWithinRangeTest()
        {
            Ensure.Arg(3).IsWithinRange(2, 4);
            Ensure.Arg(3).IsWithinRange(-3, 100);
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Ensure.Arg(3).IsWithinRange(4, 4);
            });

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Ensure.Arg(3).IsWithinRange(3, 4);
            });

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Ensure.Arg(3).IsWithinRange(2, 3);
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

            Ensure.Arg(subject[3]).IsWithinRange(2, 4);
            Ensure.Arg(subject[3]).IsWithinRange(-3, 100);
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Ensure.Arg(subject[3]).IsWithinRange(4, 4);
            });

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Ensure.Arg(subject[3]).IsWithinRange(3, 4);
            });

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Ensure.Arg(subject[3]).IsWithinRange(2, 3);
            });
        }

        [Fact]
        public void IsWithinAndIncludingRangeTest()
        {
            Ensure.Arg(3).IsWithinAndIncludingRange(2, 4);
            Ensure.Arg(3).IsWithinAndIncludingRange(-3, 100);

            Ensure.Arg(3).IsWithinAndIncludingRange(3, 4);
            Ensure.Arg(3).IsWithinAndIncludingRange(2, 3);

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Ensure.Arg(3).IsWithinAndIncludingRange(4, 4);
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

            Ensure.Arg(subject[3]).IsWithinAndIncludingRange(2, 4);
            Ensure.Arg(subject[3]).IsWithinAndIncludingRange(-3, 100);

            Ensure.Arg(subject[3]).IsWithinAndIncludingRange(3, 4);
            Ensure.Arg(subject[3]).IsWithinAndIncludingRange(2, 3);

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Ensure.Arg(subject[3]).IsWithinAndIncludingRange(4, 4);
            });
        }
    }
}