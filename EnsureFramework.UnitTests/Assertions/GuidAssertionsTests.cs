using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EnsureFramework.UnitTests.Assertions
{
    public class GuidAssertionsTests
    {
        [Fact]
        public void IsValidGuidTest()
        {
            Ensure.Arg(Guid.NewGuid(), "guid").IsValidGuid();
        }

        [Fact]
        public void IsValidGuidFailTest()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Ensure.Arg(Guid.Empty, "guid").IsValidGuid();
            });
        }

        [Fact]
        public void IsValidGuidNullableTest()
        {
            Guid? guid = Guid.NewGuid();

            Ensure.Arg(guid, "guid").IsValidGuid();
        }

        [Fact]
        public void IsValidGuidNullableEmptyFailTest()
        {
            Guid? guid = Guid.Empty;

            Assert.Throws<ArgumentException>(() =>
            {
                Ensure.Arg(guid, "guid").IsValidGuid();
            });
        }

        [Fact]
        public void IsValidGuidNullableNullFailTest()
        {
            Guid? guid = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                Ensure.Arg(guid, "guid").IsValidGuid();
            });
        }
    }
}
