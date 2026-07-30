namespace EnsureFramework.UnitTests.EnsureTests
{
    using System;

    using EnsureFramework;

    using Xunit;

    public class EnsureGuidTests
    {
        [Fact]
        public void IsValidGuid_Default()
        {
            Ensure.Arg(Guid.NewGuid(), "guid").IsValidGuid();
        }

        [Fact]
        public void IsValidGuid_Empty_Throws()
        {
            Assert.Throws<ArgumentException>(() => Ensure.Arg(Guid.Empty, "guid").IsValidGuid());
        }

        [Fact]
        public void IsValidGuidNullable_Default()
        {
            Ensure.Arg((Guid?)Guid.NewGuid(), "guid").IsValidGuid();
        }

        [Fact]
        public void IsValidGuidNullable_Empty_Throws()
        {
            Assert.Throws<ArgumentException>(() => Ensure.Arg((Guid?)Guid.Empty, "guid").IsValidGuid());
        }

        [Fact]
        public void IsValidGuidNullable_Null_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => Ensure.Arg((Guid?)null, "guid").IsValidGuid());
        }
    }
}
